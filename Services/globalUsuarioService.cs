using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using apiFactura.Models;
using apiFactura.Models.Dto;
using apiFactura.Repository;
using Common.Exceptions;
using Microsoft.IdentityModel.Tokens;
using static apiFactura.Models.Dto.globalUsuarioDTO;

namespace apiFactura.Services
{
    public interface IglobalUsuarioService
    {
        infoUsuario loginUsuario(globalUsuarioDTO param);
        string[] AuthenticationLogin(globalUsuarioDTO param);
        bool validateToken(string token);
    }

    public class globalUsuarioService:IglobalUsuarioService
    {
        private readonly ExactusContext _context;
        private globalUsuarioRepository _globalUsuarioRepository; 
        public globalUsuarioService(ExactusContext context)
        {
            this._context = context;
            this._globalUsuarioRepository = new globalUsuarioRepository(context);
        }

        public string[] AuthenticationLogin(globalUsuarioDTO param)
        {
            var data = loginUsuario(param);

            var result = jwtAuth(data);

            return result;
        }
        public infoUsuario loginUsuario(globalUsuarioDTO param)
        {
            bool existe = _globalUsuarioRepository.validaCredenciales(param.Usuario,param.Password);
            if(!existe)
                throw new HttpStatusException(HttpStatusCode.NotFound, "Usuario o Contraseña Incorrecto");
                
            var data = _globalUsuarioRepository.obtenerUsuario(param.Usuario);

            return data;
        }
        private string[] jwtAuth(infoUsuario data)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("e0f4d40a922b8814348b2464e48b9f16496476d36b9c56768120921a9919783f")); //formunica2023_it

            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var userClaims = new[] {
                new Claim("userId",data.Descr),
                new Claim("userName", data.Usuario),
                new Claim("email",data.Email)
            };

            var tokenConfiguration = new JwtSecurityToken(
                issuer: "Formuladora Nicaraguense Hanon Talavera",
                audience: "Formunica",
                claims: userClaims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credential
            );
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(tokenConfiguration); 

            var refreshToken = Guid.NewGuid().ToString();

            return new string[] {token, refreshToken, data.Usuario};

        }

        public bool validateToken(string token)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("e0f4d40a922b8814348b2464e48b9f16496476d36b9c56768120921a9919783f"));
            var tokenValidationParameters  = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "Formuladora Nicaraguense Hanon Talavera",
                ValidAudience = "Formunica",
                IssuerSigningKey = securityKey
            };

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var principal = tokenHandler.ValidateToken(token,tokenValidationParameters, out var validatedToken);

                return true;
            }
            catch 
            {
                return false;
            }
        }

    }
}
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using Common.Referencia;
using Common.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json.Linq;

namespace Common.Services
{
    public static class TokenHeader
    {

        public static string usuarioJWT(this HttpRequest request)
        {
            var handler = new JwtSecurityTokenHandler();

            var token = ObtenerTokenHeader(request);
            var jsonToken = handler.ReadJwtToken(token);

            return jsonToken.Payload["unique_name"].ToString();
        }


        public static string ObtenerTokenHeader(this HttpRequest request)
        {
            if (request.Headers.TryGetValue("Authorization", out StringValues authToken))
            {
                return authToken.First().Split("Bearer ")[1];
            }
            else
            {
                throw new ArgumentNullException("Error al tratrar de obtener el Token");
                //return null;
            }
        }
        public static string ObtenerEntidadHeader(this HttpRequest request)
        {
            if (request.Headers.TryGetValue("Entidad", out StringValues entidad))
            {
                return entidad;
            }
            else
            {
                throw new ArgumentNullException("Error al tratrar de obtener la Entidad");
                //return null;
            }
        }

        public static string[] ObtenerArregloEntidadesHearder(this HttpRequest request)
        {
            if (request.Headers.TryGetValue("Entidad", out StringValues entidad))
            {
                return entidad;
            }
            else
            {
                throw new ArgumentNullException("Error al tratrar de obtener la arreglo de Entidad");
            }
        }


        public static Guid ObtenerEntidadGuidHeader(this HttpRequest request)
        {
            return Guid.Parse(ObtenerEntidadHeader(request));
        }

        public static Guid ObtenerUsuarioGuidHeader(this HttpRequest request)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = ObtenerTokenHeader(request);
            var jsonToken = handler.ReadJwtToken(token);

            string usuarioString = jsonToken.Payload["unique_name"].ToString();

            return Guid.Parse(usuarioString);
        }

        //TODO: Debe modificarse
        public static int ObtenerUsuarioIdHeader(this HttpRequest request)
        {
            return 6;
        }

        public static AuditoriaModel CrearModeloAuditoria(this HttpRequest request, IConfiguration configuration, string accion, string pantalla, string[] entidades = null)
        {
            var permiso = new AuditoriaModel(configuration)
            {
                Accion = accion,
                Pantalla = pantalla,
                Entidad = ObtenerEntidadHeader(request),
                Entidades = entidades
            };

            return permiso;
        }

        public static AuditoriaModel CrearModeloAuditoria(this HttpRequest request, string accion, string pantalla, string[] entidades = null)
        {
            var permiso = new AuditoriaModel()
            {
                //Sistema = JsonConfiguracion.myJObject.SelectToken("$.Sistema.name").Value<string>(),
                Accion = accion,
                Pantalla = pantalla,
                Entidad = TokenHeader.ObtenerEntidadHeader(request),
                Entidades = entidades
            };

            return permiso;
        }


    }
}





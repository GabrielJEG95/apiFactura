using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using apiFactura.Models;
using apiFactura.Models.Dto;
using apiFactura.Repository;
using Common.Exceptions;
using static apiFactura.Models.Dto.globalUsuarioDTO;

namespace apiFactura.Services
{
    public interface IglobalUsuarioService
    {
        infoUsuario loginUsuario(globalUsuarioDTO param);
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
        public infoUsuario loginUsuario(globalUsuarioDTO param)
        {
            bool existe = _globalUsuarioRepository.validaCredenciales(param.Usuario,param.Password);
            if(!existe)
                throw new HttpStatusException(HttpStatusCode.NotFound, "Usuario o Contraseña Incorrecto");
                
            var data = _globalUsuarioRepository.obtenerUsuario(param.Usuario);

            return data;
        }

    }
}
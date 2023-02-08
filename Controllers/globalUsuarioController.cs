using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiFactura.Models.Dto;
using apiFactura.Repository;
using apiFactura.Services;
using Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using static apiFactura.Models.Dto.globalSucursalesDTO;

namespace apiFactura.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class globalUsuarioController : ControllerBase
    {
        private IglobalUsuarioService _globalUsuarioService; 
        public globalUsuarioController(IglobalUsuarioService globalUsuarioService)
        {
            this._globalUsuarioService = globalUsuarioService;
        }

        [HttpPost]
        public IActionResult LoginUsers ([FromBody] globalUsuarioDTO param)
        {
            try
            {
                var data = _globalUsuarioService.AuthenticationLogin(param);
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                var error = RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode, error);
            }
        }

        [HttpPost("token")]
        public IActionResult validaToken([FromBody] jwt token)
        {
            try
            {
                bool valido = _globalUsuarioService.validateToken(token.token);
                string mensaje = valido == true ?"Valido": "Invalido";

                return Ok(mensaje);
            }
            catch (System.Exception ex)
            {
                var error = RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode, error);
            }
        }
    }
}
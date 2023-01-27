using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiFactura.Models.Dto;
using apiFactura.Repository;
using apiFactura.Services;
using Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

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
                var data = _globalUsuarioService.loginUsuario(param);
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                var error = RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode, error);
            }
        }
    }
}
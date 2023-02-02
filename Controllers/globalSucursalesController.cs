using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiFactura.Models.Dto;
using apiFactura.Services;
using Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace apiFactura.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class globalSucursalesController : ControllerBase
    {
        private IGlobalSucurusalServices _GlobalSucursalServices;
        public globalSucursalesController( IGlobalSucurusalServices GlobalSucursalServices)
        {
                _GlobalSucursalServices = GlobalSucursalServices;
        }
        [HttpGet]
        public IActionResult getSucursales([FromQuery]globalSucursalesDTO Param)
        {
            try
            {
                var data =  _GlobalSucursalServices.ListSucursal(Param);
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
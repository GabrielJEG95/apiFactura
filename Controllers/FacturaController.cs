using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using apiFactura.Models;
using apiFactura.Models.Dto;
using apiFactura.Services;
using Common.Exceptions;
using Common.Extensions;
using Common.Paginado;
using Common.Referencias;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace apiFactura.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaService _facturaService;
        public FacturaController(IFacturaService facturaService)
        {
            this._facturaService=facturaService;
        }

        [HttpGet]
        public IActionResult GetFactura([FromQuery]facturaDTO param )
        {
            try
            {

                var result = _facturaService.ListarFacturas(param);
            
                if(result==null)
                    return BadRequest(MensajeReferencia.NoData);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                var error = RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode, error);
            }
        }

        [HttpGet("pendienteImprimir")]
        public IActionResult GetPendienteImprimir([FromQuery] FacturaImprimirDTO param)
        {
            try
            {
                var data = _facturaService.ListarFacturasImprimir(param);

                return Ok(data);
            }
            catch (System.Exception ex)
            {
                var error = RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode, error);
            }
        }

        [HttpGet("facturaImprimir")]
        public IActionResult GetFacturaImprimir([FromQuery] FafFActuraImpresorParam param)
        {
            try
            {
                var data = _facturaService.ImprimirFactura(param);
                return  Ok(data);
            }
            catch (System.Exception ex)
            {
                var error = RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode, error);
            }
        }

        [HttpGet("{Factura:int}")]
        public IActionResult GetFacturaById(int Factura)
        {
            try
            {
                string NoFactura = Factura.ToString();
                var data = _facturaService.obtenerFactura(NoFactura);
                return Ok(data);
            }
            catch (Exception ex)
            {
                var error = RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode, error);
            }
        }

        [HttpPut]
        public IActionResult PutFacturaImprimir([FromQuery]FafFActuraImpresorParam param,[FromBody] UpdateFactura obj)
        {
            try
            {
                _facturaService.establecerFacturaImpresa(param,obj);
                return Ok(RespuestaModel.ActualizacionExitosa());
            }
            catch (System.Exception ex)
            {
                var error = RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode, error);
            }
        }
    }
}
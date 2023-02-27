using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiFactura.Models;
using static apiFactura.Models.Dto.solicitudReintegroDTO;

namespace apiFactura.Services
{
    public interface IsolicitudReintegroDePagoService
    {
        List<listSolicitudReintegro> obtenerSolicitudReintegroPago(int IdSolicitud);
        List<listSolicitudReintegroDetalle> obtenerSolicitudReintegroPagoDetalle(int IdSolicitud);
    }

    public class solicitudReintegroDePagoService:IsolicitudReintegroDePagoService
    {
        private readonly ExactusContext _context;
        public solicitudReintegroDePagoService(ExactusContext context)
        {
            this._context = context;
        }

        public List<listSolicitudReintegro> obtenerSolicitudReintegroPago(int IdSolicitud)
        {
            var result = _context.ReiSolicitudReintegroDePagos
            .Where(w => w.IdSolicitud == IdSolicitud)
            .Select(s => new listSolicitudReintegro
            {
               IdSolicitud = s.IdSolicitud,
               valor = s.Monto,
               Concepto=s.Concepto,
               FechaSolicitud = s.FechaSolicitud,
               UnidadSolicitante = s.Centro_Costo,
               Banco = _context.FafBancos.FirstOrDefault(w => w.Codbanco == s.Banco).Descripcion             

            }).ToList();

            return result;
        }

        public List<listSolicitudReintegroDetalle> obtenerSolicitudReintegroPagoDetalle(int IdSolicitud)
        {
            var result = _context.ReiSolicitudReintegroDePagoDetalles
            .Where(w => w.IdSolicitud == IdSolicitud)
            .Select(s => new listSolicitudReintegroDetalle
            {
                IdSolicitud = s.IdSolicitud,
                Centro_Costo = s.Centro_Costo,
                Cuenta_Contable = s.Cuenta_Contable,
                Linea = s.Linea,
                NumeroFactura = s.NumeroFactura,
                NombreEstablecimiento_Persona = s.NombreEstablecimiento_Persona,
                Monto = s.Monto
            }).ToList();

            return result;
        }
        
    }
}
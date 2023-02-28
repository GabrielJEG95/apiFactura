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
               Beneficiario = s.Beneficiario,
               Moneda = s.EsDolar == 0 ? "Cordobas C$" : "Dolares $",
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
                Centro_Costo = $"{s.Centro_Costo} {_context.CentroCostos.FirstOrDefault(w => w.Centro_Costo == s.Centro_Costo).Descripcion}",
                Cuenta_Contable = $"{s.Cuenta_Contable} {_context.CuentaContables.FirstOrDefault(w => w.Cuenta_Contable == s.Cuenta_Contable).Descripcion}",
                Linea = s.Linea,
                NumeroFactura = s.NumeroFactura,
                NombreEstablecimiento_Persona = s.NombreEstablecimiento_Persona,
                Monto = s.Monto,
                Concepto = s.Concepto,
                FechaFactura =s.FechaFactura
            }).ToList();

            return result;
        }
        
    }
}
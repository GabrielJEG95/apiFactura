using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiFactura.Models;
using Microsoft.EntityFrameworkCore;

namespace apiFactura.Repository
{
    public class FacturaRepository
    {
        private readonly ExactusContext _context; 
        public FacturaRepository (ExactusContext context)
        {
            this._context = context;
        }
        public bool  validaExisteFacturaTemp (string Codsucursal, string numeroFactura)
        {
            var result = _context.TmpImpresionFafFcturas
            .Where(w => w.Codsucursal.ToUpper() == Codsucursal.ToUpper() && w.Factura==numeroFactura).FirstOrDefault();

            return result == null ? false : true;
        }

        public FafFactura obtenerFactura(string CodSucursal, string numeroFactura)
        {
            var result = _context.FafFactura
            .FirstOrDefault(w => w.Codsucursal.ToUpper()==CodSucursal.ToUpper() && w.Factura== numeroFactura);

            if(result == null)
                return null!;
            return result;
        }

        public TmpImpresionFafFctura obtenerTempFactura(string Codsucursal, string numeroFactura)
        {
            var result = _context.TmpImpresionFafFcturas
            .Where(w => w.Codsucursal.ToUpper() == Codsucursal.ToUpper() && w.Factura == numeroFactura)
            .FirstOrDefault();

            if(result == null)
                return null!;
            return result;
        }

        public List<TmpImpresionFafFacturaDetalle>  obtenerTempFacturaDetalle(string Codsucursal, string numeroFactura)
        {
            var data = _context.TmpImpresionFafFacturaDetalle.Where(w => w.Factura == numeroFactura && w.CodSucursal.ToUpper() == Codsucursal.ToUpper()).ToList();

            return data;
        }
    }
}
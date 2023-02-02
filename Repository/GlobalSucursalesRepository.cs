using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiFactura.Models;

namespace apiFactura.Repository
{
    public class GlobalSucursalesRepository
    {
        private readonly ExactusContext _context;
        public GlobalSucursalesRepository(ExactusContext context)
        {
            this._context = context;
        }

        public GlobalSucursales sucursal (string CodSucursal)
        {
            GlobalSucursales? result = _context.GlobalSucursales.FirstOrDefault(w => w.Codsucursal.ToUpper() == CodSucursal.ToUpper());

            if(result == null)
                return null!;
            return result;
        }

        
    }
}
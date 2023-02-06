using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiFactura.Models;

namespace apiFactura.Repository
{
    public class globalVendedoresRepository
    {
        private readonly ExactusContext _context;
        public globalVendedoresRepository(ExactusContext context)
        {
            this._context = context;
        }

        public GlobalVendedores obtenerVendedor (string Codvendedor)
        {
            GlobalVendedores? vendedores = _context.GlobalVendedores.FirstOrDefault(w => w.Codvendedor.ToUpper()==Codvendedor.ToUpper());

            return vendedores = vendedores==null?null!:vendedores;
        }
    }
}
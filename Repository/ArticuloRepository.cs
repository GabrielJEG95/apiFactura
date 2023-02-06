using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiFactura.Models;

namespace apiFactura.Repository
{
    public class ArticuloRepository
    {
        private readonly ExactusContext _context;
        public ArticuloRepository(ExactusContext context)
        {
            this._context = context;
        }

        public Articulo obtenerART (string codAarticulo)
        {
            Articulo articulo = _context.Articulo.FirstOrDefault(w => w.ARTICULO.ToUpper()==codAarticulo.ToUpper());

            return articulo = articulo==null?null!:articulo;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiFactura.Models;
using apiFactura.Repository;
using Common.Util;
using static apiFactura.Models.Dto.ArticuloDTO;

namespace apiFactura.Services
{
    public interface IArticuloService
    {
        articuloInfo obtenerArticulo (string codAarticulo);
    }
    public class ArticuloService:IArticuloService
    {
        private readonly ExactusContext _context;
        private ArticuloRepository _articuloRepository;
        public ArticuloService(ExactusContext context)
        {
            this._context = context;
            this._articuloRepository = new ArticuloRepository(context);
        }

        public articuloInfo obtenerArticulo (string codAarticulo)
        {
            Articulo articulo = _articuloRepository.obtenerART(codAarticulo);
            var data = Mapper<Articulo,articuloInfo>.Map(articulo);

            return data;
        }
    }
}
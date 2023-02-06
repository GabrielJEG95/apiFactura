using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiFactura.Models;
using apiFactura.Repository;
using Common.Util;
using static apiFactura.Models.Dto.globalVendedoresDTO;

namespace apiFactura.Services
{
    public interface IglobalVendedoreService
    {
        infoVendedor obtenerVendedor(string Codvendedor);
    }
    public class globalVendedoreService:IglobalVendedoreService
    {
        private readonly ExactusContext _context;
        private globalVendedoresRepository _globalVendedoresRepository;
        public globalVendedoreService(ExactusContext context)
        {
            this._context = context;
            this._globalVendedoresRepository = new globalVendedoresRepository(context);
        }

        public infoVendedor obtenerVendedor(string Codvendedor)
        {
            GlobalVendedores vendedor = _globalVendedoresRepository.obtenerVendedor(Codvendedor);
            var data = Mapper<GlobalVendedores,infoVendedor>.Map(vendedor);

            return data;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiFactura.Models;
using apiFactura.Models.Dto;
using apiFactura.Repository;
using Common.Extensions;
using Common.Util;
using static apiFactura.Models.Dto.globalSucursalesDTO;

namespace apiFactura.Services
{
    public interface IGlobalSucurusalServices
    {
        List<sucursales> ListSucursal(globalSucursalesDTO Param);
        sucursales ObtenerGlobalSucursal(string CodSucursal);
    }
    public class GlobalSucurusalServices:IGlobalSucurusalServices
    {
        private readonly ExactusContext _context;
        private GlobalSucursalesRepository _globalSucursalRepository;
        public GlobalSucurusalServices (ExactusContext context)
        {
            this._context = context;
            this._globalSucursalRepository = new GlobalSucursalesRepository(context);
        }

        public List<sucursales> ListSucursal(globalSucursalesDTO Param)
        {
            var data = _context.GlobalSucursales.Where(a => 
                Param.Codsucursal.IsNullOrEmpty()|| a.Codsucursal.ToUpper()==Param.Codsucursal.ToUpper()
            &&  Param.sucursal.IsNullOrEmpty()|| a.Sucursal.ToUpper()==Param.sucursal.ToUpper()
            )
            .Select(b => new sucursales
            {
                Codsucursal = b.Codsucursal,
                sucursal= b.Sucursal,
                Direccionsucursal=b.Direccionsucursal
            }).ToList();

            if( data == null)
                return null!;
            return data;

        }

        public sucursales ObtenerGlobalSucursal(string CodSucursal)
        {
            GlobalSucursales globalSucursales = _globalSucursalRepository.sucursal(CodSucursal);
            var data = Mapper<GlobalSucursales,sucursales>.Map(globalSucursales);
            return data;
        }
    }
}
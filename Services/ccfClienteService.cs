using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiFactura.Models;
using apiFactura.Repository;
using Common.Util;
using static apiFactura.Models.Dto.ccfClienteDTO;

namespace apiFactura.Services
{
    public interface IccfClienteService
    {
        infoCliente obtenerCliente(string CodCliente);
    }

    public class ccfClienteService:IccfClienteService
    {
        private readonly ExactusContext _context;
        private ccfCLientesRepository _ccfClientesRepository;

        public ccfClienteService(ExactusContext context)
        {
            this._context = context;
            this._ccfClientesRepository = new ccfCLientesRepository(context);
        }

        public infoCliente obtenerCliente(string CodCliente)
        {
            CcfClientes cliente = _ccfClientesRepository.cliente(CodCliente);
            var data = Mapper<CcfClientes,infoCliente>.Map(cliente);
            return data;
        }

    }
}
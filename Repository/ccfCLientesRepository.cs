using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiFactura.Models;

namespace apiFactura.Repository
{
    public class ccfCLientesRepository
    {
        private readonly ExactusContext _context;
        public ccfCLientesRepository(ExactusContext context)
        {
            this._context=context;
        }

        public CcfClientes cliente (string Codcliente)
        {
            CcfClientes? data = _context.CcfClientes.FirstOrDefault(w => w.CodCliente.ToUpper()==Codcliente.ToUpper());

            return data == null?null!:data;
        }
    }
}
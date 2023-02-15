using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Paginado;

namespace apiFactura.Models.Dto
{
    public class ccfClienteDTO:Paginado
    {
        public ccfClienteDTO()
        {

        }

        public string Codcliente {get;set;} = null!;
        public string Codsucursal {get;set;} = null!;

        public class infoCliente
        {
            public string Codcliente {get;set;} = null!;
            public string ApellidosCliente {get;set;} = null!;
            public string NombresCliente {get;set;} = null!;
            public string CodSucursal {get;set;} = null!;
            public string Sucursal {get;set;} = null!;
            public string Direccion {get;set;} = null!;
            public string Telefono1 {get;set;} = null!;
            public string Moroso {get;set;} = null!;
            public string? Cedula { get; set; } = null!;
        
        }
    }
}
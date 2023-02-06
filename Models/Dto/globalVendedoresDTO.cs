using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Paginado;

namespace apiFactura.Models.Dto
{
    public class globalVendedoresDTO:Paginado
    {
        public globalVendedoresDTO()
        {

        }

        public string Codvendedor {get;set;} = null!;
        public string Codsucursal {get;set;} = null!;

        public class infoVendedor
        {
            public string Codvendedor {get;set;} = null!;
            public string Codsucursal {get;set;} = null!;
            public string NombresVendedor {get;set;} = null!;
            public string ApellidosVendedor {get;set;} = null!;
        }

    }
}
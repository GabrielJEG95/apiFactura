using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Paginado;

namespace apiFactura.Models.Dto
{
    public class globalSucursalesDTO:Paginado
    {
        public globalSucursalesDTO()
        {
            
        }

        public string Codsucursal {get;set;}=null!;
        public string sucursal {get;set;}=null!;
        public class sucursales
        {
            public string Codsucursal {get;set;}=null!;
            public string sucursal {get;set;}=null!;
            public string Direccionsucursal {get;set;}=null!;
        }

        public class jwt 
        {
            public string token {get;set;} = null!;
        }
    }
}
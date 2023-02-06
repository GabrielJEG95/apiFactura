using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Paginado;

namespace apiFactura.Models.Dto
{
    public class ArticuloDTO:Paginado
    {
        public ArticuloDTO()
        {

        }

        public string ARTICULO {get;set;} = null!;
        public string Unidad_Venta {get;set;} = null!;
        public string Descripcion {get;set;} = null!;

        public class articuloInfo
        {
            public string ARTICULO {get;set;} = null!;
            public string Plantilla_Serie {get;set;} = null!;
            public string Descripcion {get;set;} = null!;
            public string Unidad_Almacen {get;set;} = null!;
            public string Unidad_Empaque {get;set;} = null!;
            public string Unidad_Venta {get;set;} = null!;
        }
    }
}
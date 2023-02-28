using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFactura.Models
{
    public class CentroCosto
    {
        public string Centro_Costo {get;set;} = null!;
        public string Descripcion {get;set;} = null!;
        public string Acepta_Datos {get;set;} = null!;
        public string Tipo {get;set;} = null!;
    }
}
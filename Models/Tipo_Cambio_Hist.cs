using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFactura.Models
{
    public class Tipo_Cambio_Hist
    {
        public string Tipo_Cambio {get;set;} = null!;
        public DateTime Fecha {get;set;}
        public string Usuario {get;set;} = null!;
        public decimal Monto {get;set;}
    }
}
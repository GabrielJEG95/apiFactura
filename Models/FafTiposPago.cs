using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFactura.Models
{
    public class FafTiposPago
    {
        public string TipoPago {get;set;} = null!;
        public string Descripcion {get;set;} = null!;
        public int AplicaFactura {get;set;}
        public int Prioridad {get;set;}
    }
}
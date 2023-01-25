using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFactura.Models
{
    public class FafGetFacturasImprimir
    {
        public DateTime FechaFactura {get;set;}
        public string Factura {get;set;} = null!;
        public string Codsucursal {get;set;} = null!;
        public string Sucursal {get;set;} = null!;
        public string CodCliente {get;set;} = null!;

        public string Cliente {get;set;} = null!;
        public decimal Subtotal {get;set;}
        public decimal TotalFactura {get;set;}
        
    }
}
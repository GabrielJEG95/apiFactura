using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFactura.Models
{
    public class TmpImpresionFafFacturaDetalle
    {
        public string CodSucursal {get;set;} = null!;
        public string Tipo {get;set;} = null!;
        public string TipoFormato {get;set;} = null!;
        public string Factura {get;set;} = null!;
        public string Articulo {get;set;} = null!;
        public DateTime FechaFactura {get;set;}
        public string CodCliente {get;set;} = null!;
        public string Autorizacion {get;set;} =null!;
        public int Cantidad {get;set;}
        public decimal PrecioUnitario {get;set;}
        public decimal PrecioUnitarioDolar {get;set;}
        public decimal Subtotal {get;set;}
        public decimal SubtotalDolar {get;set;}
        public decimal Descuento {get;set;}
        public decimal DescuentoDolar {get;set;}
        public decimal Iva {get;set;}
        public decimal IvaDolar {get;set;}
        public decimal Total {get;set;}
        public decimal TotalDolar {get;set;}
        public string CodCultivo {get;set;} = null!;
        public string Numeroserie {get;set;} = null!;
        public decimal CostoLocal {get;set;}
        public decimal CostoDolar {get;set;}
        public string Combo {get;set;} = null!;
        public string Lote {get;set;} = null!;

    }
}
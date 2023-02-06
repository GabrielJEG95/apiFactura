using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFactura.Models
{
    public class TmpImpresionFafFctura
    {
        public string? Codsucursal {get;set;} = null!;
        public string? Tipo {get;set;} = null!;
        public string? TipoFormato {get;set;} = null!;
        public string? Factura {get;set;} = null!;
        public DateTime FechaFactura {get;set;}
        public string? CodCliente {get;set;} = null!;
        public string? Cliente {get;set;} = null!;
        public DateTime FechaVencimiento {get;set;}
        public string? Codvendedor {get;set;} = null!;
        public string? Remision {get;set;} = null!;
        public string? TipoPago {get;set;} = null!;
        public decimal Subtotal {get;set;} 
        public decimal Descuento {get;set;}
        public decimal IVA {get;set;}
        public decimal TotalFactura {get;set;}
        public short Impresa {get;set;}
        public short Anulada {get;set;}
        public short Exonerada {get;set;}
        public short PendienteEnvio {get;set;}
        public short FacturaSinExistencia {get;set;}
        public string? StatusFactura {get;set;} = null!;
        public decimal StatusMonto {get;set;}
        public string? Usuario {get;set;} = null!;
        public DateTime FechaRegistro {get;set;}
        public string? Usuario1 {get;set;} = null!;
        public DateTime FechaUpdate {get;set;}
        public decimal TipoCambio {get;set;}
        public short Enespera {get;set;}
        public string? Proforma {get;set;} = null!;
        public string? Asientocg {get;set;} = null!;
        public string? Asientocc {get;set;} = null!;
        public decimal MontoFlete {get;set;}


    }
}
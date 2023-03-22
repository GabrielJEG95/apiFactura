using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Paginado;

namespace apiFactura.Models.Dto
{
    public class facturaDTO:Paginado
    {
        public facturaDTO()
        {
            OrdenarPor="FECHAREGISTRO";
            OrientarPor="DESC";
        }
        public int? Factura {get;set;}
        public string? Codcliente {get;set;}
        public string? Codsucursal {get;set;}
        public string? Codvendedor {get;set;}

        private string? _ordenarPor{get;set;}
        public new string? OrdenarPor
        {
            get {return _ordenarPor;}
            set 
            {
                if (value.ToUpper()=="FECHAREGISTRO".ToUpper())
                {
                    _ordenarPor="FECHAREGISTRO";
                }
                else
                {
                    _ordenarPor=value;
                }
            }
        }

    }

    public class ListFactura
        {
            public string? Factura {get;set;}
            public string? Cliente {get;set;}
            public string? CodCliente {get;set;}
            public string? Codvendedor {get;set;}
            public string? Vendedor {get;set;}
            public decimal Subtotal {get;set;}
            public decimal Descuento {get;set;}
            public string? Anulada {get;set;}
            public string? Tipo {get;set;} // si es credito o contado
            public DateTime Fechafactura {get;set;}

        }

    public class UpdateFactura
    {
        public short Impresa {get;set;}
    }

    public partial class FacturaUpdate
    {
        public static FafFactura Map(FafFactura original, UpdateFactura actualizacion)
        {
            original.Impresa = actualizacion.Impresa;

            return original;
        }
    }
}
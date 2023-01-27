using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Paginado;
using System.ComponentModel.DataAnnotations;

namespace apiFactura.Models.Dto
{
    public class FacturaImprimirDTO:Paginado
    {
        public FacturaImprimirDTO()
        {
            OrdenarPor = "FECHAFACTURA";
            OrientarPor = "DESC";
        }
        [Required(ErrorMessage = "Favor proporcionar el usuario")]
        public string? Usuario {get;set;}
        [Required(ErrorMessage = "Favor establecer una fecha de iniciio")]
        public DateTime FechaInicial {get;set;}
        [Required(ErrorMessage = "Favor establecer una fecha final")]
        public DateTime FechaFinal {get;set;}
        [Required(ErrorMessage = "Favor indicar si desea consultar factura impresa o pendiente de imprimir")]
        public int? PendienteImprimir {get;set;}

        private string _ordenarPor {get;set;}
        public new string OrdenarPor
        {
            get {return _ordenarPor;}
            set 
            {
                if (value.ToUpper() == "FECHAFACTURA".ToUpper())
                {
                    _ordenarPor = "FECHAFACTURA";
                }

                else
                {
                    _ordenarPor = value;
                }
            }
        }
    }

    public class FafFActuraImpresorParam
    {
        [Required(ErrorMessage="Favor ingrese una sucursal")]
        public string CodSucursal {get;set;} = null!;
        [Required(ErrorMessage = "Favor ingrese un numero de factura")]
        public string numeroFactura {get;set;} = null!;
        [Required(ErrorMessage = "Favor indique si es reimpresión")]
        public int impresa {get;set;}
        public int ImprimirLote {get;set;}
    }
    
    public class headerFacturaImprimir
    {
        public string CodSucursal {get;set;} = null!;
        public string Sucursal {get;set;} = null!;
        public string Tipo {get;set;} = null!;
        public string TipoFormato {get;set;} = null!;
        public string Factura {get;set;} = null!;
        public DateTime FechaFactura {get;set;}
        public string CodCliente {get;set;} = null!;
        public string Cliente {get;set;} = null!;
        public DateTime FechaVencimiento {get;set;}
        public string Codvendedor {get;set;} = null!;
        public string NombreVendedor {get;set;} = null!;
        public string Remision {get;set;} = null!;
        public string TipoPago {get;set;} = null!;
        public string DescriptoPago {get;set;} = null!;
        public decimal Subtotal {get;set;}
        public decimal Descuento {get;set;}
        public decimal Iva {get;set;}
        public decimal TotalFactura {get;set;}
        public decimal TipoCambio {get;set;}
        public string Expr1 {get;set;} = null!;
        public string NumAutorizadoDgi {get;set;} = null!;
        public string NombreCliente {get;set;} = null!;
        public bool AllowEditName {get;set;}
        public string MontoLetrasDolar {get;set;} = null!;
        public decimal TipoCambioParalelo {get;set;}
        public decimal MontoFlete {get;set;}
        public List<detailFacturaImprimir>  detailFacturaImprimirs{get;set;}=new List<detailFacturaImprimir>();
        

    }

    public class detailFacturaImprimir
    {
        public decimal Cantidad {get;set;}
        public decimal PrecioUnitario {get;set;}
        public decimal Subtotal {get;set;}
        public decimal Descuento {get;set;}
        public decimal Iva {get;set;}
        public decimal Total {get;set;}
        public string CodCultivo {get;set;} = null!;
        public string Numeroserie {get;set;} = null!;
        public string Articulo {get;set;} = null!;
        public string Combo {get;set;} = null!;
        public string? Descripcion {get;set;} = null!;
        public string? Unidad_Almacen {get;set;} = null!;
        public decimal Factor_Empaque {get;set;}
        public string Lote {get;set;} = null!;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFactura.Models
{
    public class ReiSolicitudReintegroDePago
    {
        public int IdSolicitud {get;set;}
        public string Centro_Costo {get;set;} = null!;
        public DateTime FechaSolicitud {get;set;}
        public decimal Monto {get;set;}
        public Int16 EsDolar {get;set;}
        public string CodEstado {get;set;} = null!;
        public Int16 TipoPago {get;set;}
        public string Beneficiario {get;set;} = null!;
        public string Concepto {get;set;} = null!;
        public string Cuenta_Banco {get;set;} = null!;
        public string NumCheque {get;set;} = null!;
        public Int16 Anulada {get;set;}
        public int Pais {get;set;}
        public string Banco {get;set;} = null!;
    }
}
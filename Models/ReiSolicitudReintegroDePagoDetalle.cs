using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFactura.Models
{
    public class ReiSolicitudReintegroDePagoDetalle
    {
        public int IdSolicitud {get;set;}
        public string Centro_Costo {get;set;} = null!;
        public string Cuenta_Contable {get;set;} = null!;
        public int Linea {get;set;}
        public string Concepto {get;set;} = null!;
        public DateTime FechaFactura {get;set;}
        public string NumeroFactura {get;set;} = null!;
        public string NombreEstablecimiento_Persona {get;set;} = null!;
        public decimal Monto {get;set;}

    }
}
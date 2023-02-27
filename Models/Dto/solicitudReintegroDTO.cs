using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiFactura.Models.Dto
{
    public class solicitudReintegroDTO
    {
        [Required(ErrorMessage = "Favor introducir un numero de solicitud")]
        public  int IdSolicitud {get;set;}

        public class listSolicitudReintegro
        {
            public int IdSolicitud {get;set;}
            public string UnidadSolicitante {get;set;} = null!;
            public decimal valor {get;set;}
            public string Concepto {get;set;} = null!;
            public DateTime FechaSolicitud {get;set;}
            public string Banco {get;set;} = null!;
        }

        public class listSolicitudReintegroDetalle
        {
            public int IdSolicitud {get;set;}
            public string Centro_Costo {get;set;} = null!;
            public string Cuenta_Contable {get;set;} = null!;
            public int Linea {get;set;} 
            public string NumeroFactura {get;set;} = null!;
            public string NombreEstablecimiento_Persona {get;set;} = null!;
            public decimal Monto {get;set;}
        }
    }
    
}
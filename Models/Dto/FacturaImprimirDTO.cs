using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Paginado;

namespace apiFactura.Models.Dto
{
    public class FacturaImprimirDTO:Paginado
    {
        public FacturaImprimirDTO()
        {
            OrdenarPor = "FECHAFACTURA";
            OrientarPor = "DESC";
        }
        public string? Usuario {get;set;}
        public DateTime FechaInicial {get;set;}
        public DateTime FechaFinal {get;set;}
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
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFactura.Models
{
    public class FafParametrosGenerales
    {
        public int DiasVigencia {get;set;}
        public int PermitirParcial {get;set;}
        public string Titulo {get;set;} = null!;
        public string Promocion1 {get;set;} = null!;
        public string Promocion2 {get;set;} = null!;
        public string NumAutorizadoDgi {get;set;} = null!;
        public string VersionApp {get;set;} = null!;
        public string CtaFleteOfPlanta {get;set;} = null!;
        
    }
}
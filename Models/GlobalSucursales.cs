using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFactura.Models
{
    public class GlobalSucursales
    {
        public string Codsucursal {get;set;} = null!;
        public string Sucursal {get;set;} = null!;
        public decimal Transporte {get;set;}
        public string Usuario {get;set;} = null!;
        public DateTime Fecharegistro {get;set;}
        public string Usuario1 {get;set;} = null!;
        public DateTime Fechaupdate {get;set;}
        public bool Activa {get;set;}
        public string Email {get;set;} = null!;
        public string Passwordemail {get;set;} = null!;
        public DateTime ultimodiacerrado {get;set;}
        public DateTime Fechaultimocierre {get;set;}
        public DateTime Fechaultimocorteccf {get;set;}
        public decimal Tcambioultimocorteccf {get;set;}
        public string Direccionsucursal {get;set;} = null!;
    }
}
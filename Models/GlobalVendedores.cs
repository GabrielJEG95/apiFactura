using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFactura.Models
{
    public partial class GlobalVendedores
    {
        public string Codvendedor {get;set;} = null!;
        public string Codsucursal {get;set;} = null!;
        public string NombresVendedor {get;set;} = null!;
        public string ApellidosVendedor {get;set;} = null!;
        public string Usuario {get;set;} = null!;
        public DateTime Fecharegistro {get;set;}
        public string Usuario1 { get; set; } = null!;
        public DateTime Fechaupdate { get; set; }
        public string Activo {get;set;} = null!;
        public int? Prioridad {get;set;}
        public int? EsAtv {get;set;}

    }
}
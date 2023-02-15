using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFactura.Models
{
    public class CcfClientes
    {
        public string CodCliente {get;set;} = null!;
        public string ApellidosCliente {get;set;} = null!;
        public string NombresCliente {get;set;} = null!;
        public DateTime FechaIngreso {get;set;}
        public string Direccion {get;set;} = null!;
        public string Telefono1 {get;set;} = null!;
        public string Fax1 {get;set;} = null!;
        public string CodSucursal {get;set;} = null!;
        public string Codvendedor {get;set;} = null!; 
        public Int16 Moroso {get;set;} 
        public decimal Saldo {get;set;}
        public bool AllowEditName {get;set;}
        public string? Cedula { get; set; } = null!;
        
    }
}
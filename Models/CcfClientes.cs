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
        public int Telefono1 {get;set;}
        public int Fax1 {get;set;}
        public string CodSucursal {get;set;} = null!;
        public string Codvendedor {get;set;} = null!; 
        public bool Moroso {get;set;}
        public decimal Saldo {get;set;}
        public bool AllowEditName {get;set;}
        
    }
}
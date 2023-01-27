using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFactura.Models
{
    public class globalUsuario
    {
        public string Usuario{get;set;}=null!;

        public string Descr{get;set;}=null!;

        public bool Activo{get;set;}

        public string Password{get;set;}=null!;

        public string Sucursal{get;set;}=null!;

        public string Email{get;set;}=null!;
        
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiFactura.Models.Dto
{
    public class globalUsuarioDTO
    {
        [Required(ErrorMessage = "Favor ingresar su Usuario")]
        public string Usuario{get;set;}=null!;
        [Required(ErrorMessage = "Favor ingresar su contraseña")]

        public string Password{get;set;}=null!;

        public class infoUsuario
        {
            public string Usuario {get;set;} =null!;
            public string Email {get;set;} = null!;
            public string Descr {get;set;} = null!;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFactura.Models
{
    public class CuentaContable
    {
        public string Cuenta_Contable {get;set;} = null!;
        public string Seccion_Cuenta {get;set;} = null!;
        public string Unidad {get;set;} = null!;
        public string Descripcion {get;set;} = null!;
        public string Tipo {get;set;} = null!;
        public string Tipo_Detallado {get;set;} = null!;
        public string Tipo_Oaf {get;set;} = null!;
    }
}
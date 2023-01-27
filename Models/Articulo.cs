using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFactura.Models
{
    public class Articulo
    {
        public string ARTICULO {get;set;} = null!;
        public string Plantilla_Serie {get;set;} = null!;
        public string Descripcion {get;set;} = null!;
        public string Clasificacion_1 {get;set;} = null!;
        public string Clasificacion_2 {get;set;} = null!;
        public string Clasificacion_3 {get;set;} = null!;
        public string Clasificacion_4 {get;set;} = null!;
        public string Clasificacion_5 {get;set;} = null!;
        public string Clasificacion_6 {get;set;} = null!;
        public decimal Factor_Empaque {get;set;}
        public string Unidad_Almacen {get;set;} = null!;
        public string Unidad_Empaque {get;set;} = null!;
        public string Unidad_Venta {get;set;} = null!;
        
    }
}
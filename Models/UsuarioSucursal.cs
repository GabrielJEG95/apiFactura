using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFactura.Models
{
    public class UsuarioSucursal
    {
        public string IdUsuario {get;set;} = null!;
        public string CodSucursal {get;set;} = null!;
        public bool Activo {get;set;}
        public int NoteExistFlag {get;set;}
        public DateTime RecordDate {get;set;}
        public Guid RowPointer {get;set;}
        public string CreatedBy {get;set;} = null!;
        public DateTime CreateDate {get;set;}
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Common.Attributes;
using Common.Interfaces;

namespace Common.Services.Models
{


    public class Anulacion : IDeleteAuditoria
    {

        public int Id { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {0} debe ser mayor que {1}")]
        public int IdUsuarioAnulacion { get; set; }
        [Required]
        [MayorFechaActualAttribute]
        public DateTime FechaAnulacion => DateTime.Now;
    }

    public class AnulacionMotivo : IDeleteAuditoria
    {
        [Required]
        public int IdUsuarioAnulacion { get; set; }
        [Required]
        [MayorFechaActualAttribute]
        public DateTime FechaAnulacion => DateTime.Now;
        [Required]
        public DateTime Movito { get; set; }
    }


}

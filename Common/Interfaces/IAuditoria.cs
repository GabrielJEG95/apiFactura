
using System;
using System.ComponentModel.DataAnnotations;
using Common.Referencias;
using Microsoft.AspNetCore.Mvc;

namespace Common.Interfaces
{
    interface IAutidoria : ICreateAuditoria, IUpdateAuditoria, IDeleteAuditoria
    {

    }

    interface ICreateAuditoria
    {
        int IdUsuarioCreacion { get; set; }
        DateTime FechaCreacion {get;}


    }

    interface IUpdateAuditoria
    {
        int IdUsuarioModificacion { get; set; }

        DateTime FechaModificacion {get;}

    }


    interface IDeleteAuditoria
    {
        [Display(Name = "Usuario Eliminacion")]
        [Required(ErrorMessage = MensajeReferencia.CampoRequerido)]
        int IdUsuarioAnulacion { get; set; }

        DateTime FechaAnulacion {get;}

    }


}
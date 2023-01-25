using System;
using System.Collections.Generic;

namespace apiFactura.Models;

public partial class FafConexionProcesoSucursal
{
    public string Idproceso { get; set; } = null!;

    public string? Codsucursal { get; set; }

    public DateTime? Fecha { get; set; }

    public byte NoteExistsFlag { get; set; }

    public DateTime RecordDate { get; set; }

    public Guid RowPointer { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string UpdatedBy { get; set; } = null!;

    public DateTime CreateDate { get; set; }
}

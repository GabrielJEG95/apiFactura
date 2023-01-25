using System;
using System.Collections.Generic;

namespace apiFactura.Models;

public partial class FafConexionProcesoSucursal1
{
    public string Idproceso { get; set; } = null!;

    public string? Codsucursal { get; set; }

    public DateTime? Fecha { get; set; }
}

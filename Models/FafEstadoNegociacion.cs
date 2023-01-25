using System;
using System.Collections.Generic;

namespace apiFactura.Models;

public partial class FafEstadoNegociacion
{
    public int CodEstado { get; set; }

    public string Descr { get; set; } = null!;

    public bool? Activo { get; set; }
}

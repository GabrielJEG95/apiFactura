using System;
using System.Collections.Generic;

namespace apiFactura.Models;

public partial class FafDescuentos
{
    public int Iddescuento { get; set; }

    public string NivelPrecio { get; set; } = null!;

    public string Articulo { get; set; } = null!;

    public int? Desde { get; set; }

    public int? Hasta { get; set; }

    public decimal? PorcDesc { get; set; }
}

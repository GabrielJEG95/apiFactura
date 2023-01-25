using System;
using System.Collections.Generic;

namespace apiFactura.Models;

public partial class FafCombo
{
    public int Idcombo { get; set; }

    public string Descr { get; set; } = null!;

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public string Articulo { get; set; } = null!;

    public decimal? CantidadLimite { get; set; }

    public string? TipoValidacion { get; set; }

    public decimal? PrecioDolar { get; set; }
}

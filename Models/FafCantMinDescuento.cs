using System;
using System.Collections.Generic;

namespace apiFactura.Models;

public partial class FafCantMinDescuento
{
    public string Articulo { get; set; } = null!;

    public decimal? CantMinDescMostrador { get; set; }

    public decimal? CantMinDescCliente { get; set; }

    public decimal? CantMinDescDistribuidor { get; set; }
}

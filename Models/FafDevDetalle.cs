using System;
using System.Collections.Generic;

namespace apiFactura.Models;

public partial class FafDevDetalle
{
    public long IddevDetalle { get; set; }

    public long Iddevolucion { get; set; }

    public string Articulo { get; set; } = null!;

    public string Lote { get; set; } = null!;

    public decimal? Cantidad { get; set; }

    public decimal? PrecioLocal { get; set; }

    public decimal? PrecioDolar { get; set; }

    public decimal? CostoLocal { get; set; }

    public decimal? CostoDolar { get; set; }

    public decimal? MontoLocal { get; set; }

    public decimal? MontoDolar { get; set; }

    public virtual FafDevolucion IddevolucionNavigation { get; set; } = null!;
}

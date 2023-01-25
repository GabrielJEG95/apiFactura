using System;
using System.Collections.Generic;

namespace apiFactura.Models;

public partial class FafDescuentoFactura
{
    public int Iddescuento { get; set; }

    public string CodSucursal { get; set; } = null!;

    public string Factura { get; set; } = null!;

    public string? Referencia { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Usuario { get; set; }

    public decimal? TipoCambio { get; set; }

    public decimal? TipoCambioParal { get; set; }

    public decimal? DescuentoLocal { get; set; }

    public decimal? DescuentoDolar { get; set; }

    public bool? EsContado { get; set; }

    public string? AsientoContado { get; set; }

    public string? NotaCredito { get; set; }

    public bool? AprobVenta { get; set; }

    public bool? AprobFinanza { get; set; }

    public bool? AprobOperacion { get; set; }

    public virtual FafFactura FafFactura { get; set; } = null!;
}

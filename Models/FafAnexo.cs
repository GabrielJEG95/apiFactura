using System;
using System.Collections.Generic;

namespace apiFactura.Models;

public partial class FafAnexo
{
    public string Factura { get; set; } = null!;

    public string? Recibo { get; set; }

    public DateTime? FechaCorte { get; set; }

    public DateTime FechaEmision { get; set; }

    public DateTime? FechaEmision2 { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public DateTime? FechaVencimiento2 { get; set; }

    public string? TipoDocumento { get; set; }

    public int? Dia { get; set; }

    public decimal? Original { get; set; }

    public decimal? Valor { get; set; }

    public decimal? Nominal { get; set; }

    public double? Vencido { get; set; }

    public double? NoVencido { get; set; }

    public decimal? Deslizamiento { get; set; }

    public decimal? Deslizamientoaplicado { get; set; }

    public decimal? Principal { get; set; }

    public decimal? Interes { get; set; }

    public decimal? InteresAplicado { get; set; }

    public decimal? Total { get; set; }

    public decimal? Debe { get; set; }

    public decimal? Haber { get; set; }

    public int? Orden { get; set; }

    public string? Codcliente { get; set; }

    public bool? Abono { get; set; }

    public bool? Cancelada { get; set; }

    public string Usuario { get; set; } = null!;

    public string? Codvendedor { get; set; }

    public string? CodSucursalFactura { get; set; }

    public decimal? TipoCambioFactura { get; set; }
}

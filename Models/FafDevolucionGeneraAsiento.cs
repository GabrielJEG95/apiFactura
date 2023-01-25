using System;
using System.Collections.Generic;

namespace apiFactura.Models;

public partial class FafDevolucionGeneraAsiento
{
    public string? CodSucursal { get; set; }

    public short? Dia { get; set; }

    public string? Tipo { get; set; }

    public string? TipoFormato { get; set; }

    public string? Factura { get; set; }

    public DateTime? FechaFactura { get; set; }

    public string? CodCliente { get; set; }

    public decimal? TipoCambio { get; set; }

    public string? Articulo { get; set; }

    public string? TipoArticulo { get; set; }

    public decimal? Cantidad { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public decimal? PrecioUnitarioDolar { get; set; }

    public decimal? SubTotal { get; set; }

    public decimal? SubTotalDolar { get; set; }

    public decimal? Iva { get; set; }

    public decimal? Ivadolar { get; set; }

    public decimal? Total { get; set; }

    public decimal? TotalDolar { get; set; }

    public string? DocumentoInv { get; set; }

    public bool? IsHeader { get; set; }

    public bool? IsFinish { get; set; }

    public string? Paquete { get; set; }

    public string? Documento { get; set; }

    public int Id { get; set; }

    public string? Lote { get; set; }

    public decimal? Tipocambiopar { get; set; }
}

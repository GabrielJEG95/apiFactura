using System;
using System.Collections.Generic;

namespace apiFactura.Models;

public partial class FafFacturadetalle
{
    public string Codsucursal { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public string Tipoformato { get; set; } = null!;

    public string Factura { get; set; } = null!;

    /// <summary>
    /// anteriormente codproducto en siscobro
    /// </summary>
    public string Articulo { get; set; } = null!;

    public DateTime Fechafactura { get; set; }

    public string Codcliente { get; set; } = null!;

    public string Autorizacion { get; set; } = null!;

    public decimal Cantidad { get; set; }

    public decimal Preciounitario { get; set; }

    public decimal Preciounitariodolar { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Subtotaldolar { get; set; }

    public decimal Descuento { get; set; }

    public decimal Descuentodolar { get; set; }

    public decimal Iva { get; set; }

    public decimal Ivadolar { get; set; }

    public decimal Total { get; set; }

    public decimal Totaldolar { get; set; }

    public string Codcultivo { get; set; } = null!;

    public string? Numeroserie { get; set; }

    public decimal Costolocal { get; set; }

    public decimal Costodolar { get; set; }

    public short Exonerada { get; set; }

    public int? Idnegociacion { get; set; }

    public decimal? PrecioDolarLista { get; set; }

    public string Lote { get; set; } = null!;

    public string? Combo { get; set; }

    public string? DocDevolucion { get; set; }

    public decimal? CantDevolucion { get; set; }

    public short? FactorDevolucion { get; set; }

    public string? AsientoDev { get; set; }

    public string? Categoria { get; set; }

    public decimal? PrecioPiso { get; set; }

    public virtual FafFactura FafFactura { get; set; } = null!;
}

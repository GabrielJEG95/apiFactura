using System;
using System.Collections.Generic;

namespace apiFactura.Models;

public partial class FafDevolucionborrar
{
    public int Iddevolucion { get; set; }

    public string CodSucursal { get; set; } = null!;

    public string DocDevolucion { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public string? Concepto { get; set; }

    public string Factura { get; set; } = null!;

    public string? AsientoDev { get; set; }

    public string? DocumentoInv { get; set; }

    public string? NumeroNotaCredito { get; set; }

    public string? NumeroNotaDebito { get; set; }
}

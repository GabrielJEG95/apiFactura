using System;
using System.Collections.Generic;

namespace apiFactura.Models;

public partial class FafFacturacorrecion
{
    public string Codsucursal { get; set; } = null!;

    public string Factura { get; set; } = null!;

    public string Tipodocumento { get; set; } = null!;

    public string Concepto { get; set; } = null!;

    public DateTime Fechacorrecion { get; set; }

    public int Codtipocorrecion { get; set; }

    public string Usuario { get; set; } = null!;

    public DateTime Fecharegistro { get; set; }
}

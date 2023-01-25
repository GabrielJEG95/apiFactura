using System;
using System.Collections.Generic;

namespace apiFactura.Models;

public partial class FafContadohistorico
{
    public string CodSucursal { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public string NFactura { get; set; } = null!;

    public string CodVend { get; set; } = null!;

    public DateTime FIngreso { get; set; }

    public string Nombres { get; set; } = null!;

    public string Remision { get; set; } = null!;

    public decimal TFactura { get; set; }

    public decimal Igv { get; set; }

    public bool Anulada { get; set; }

    public bool Exonerada { get; set; }

    public string Autoriza { get; set; } = null!;

    public string Cultivo { get; set; } = null!;
}

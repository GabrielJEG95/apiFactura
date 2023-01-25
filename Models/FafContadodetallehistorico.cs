using System;
using System.Collections.Generic;

namespace apiFactura.Models;

public partial class FafContadodetallehistorico
{
    public string CodSucursal { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public string NFactura { get; set; } = null!;

    public decimal Cantidad { get; set; }

    public string CodProd { get; set; } = null!;

    public decimal PreUnit { get; set; }

    public decimal Valor { get; set; }

    public string Codcultivo { get; set; } = null!;
}

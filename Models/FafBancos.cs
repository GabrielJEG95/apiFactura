using System;
using System.Collections.Generic;

namespace apiFactura.Models;

public partial class FafBancos
{
    public string Codbanco { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string? CuentaBancoDol { get; set; }

    public string? CuentaBancoLoc { get; set; }
}

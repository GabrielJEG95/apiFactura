using System;
using System.Collections.Generic;

namespace apiFactura.Models;

public partial class FafCategoriaProdSucursal
{
    public string Articulo { get; set; } = null!;

    public string CodSucursal { get; set; } = null!;

    public string? Categoria { get; set; }
}

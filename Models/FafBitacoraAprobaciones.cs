using System;
using System.Collections.Generic;

namespace apiFactura.Models;

public partial class FafBitacoraAprobaciones
{
    public int Idnegociacion { get; set; }

    public string Usuario { get; set; } = null!;

    public int? CodEstado { get; set; }

    public DateTime Fecha { get; set; }
}

using System;
using System.Collections.Generic;

namespace apiFactura.Models;

public partial class FafDiariodetalle
{
    public int Linea { get; set; }

    public string Codsucursal { get; set; } = null!;

    public DateTime Fechacierre { get; set; }

    public string Numeroconsecutivo { get; set; } = null!;

    public string Tipopago { get; set; } = null!;

    public string Bancoemisor { get; set; } = null!;

    public string Numerodocumento { get; set; } = null!;

    public string Nombrecliente { get; set; } = null!;

    public string Bancoreceptor { get; set; } = null!;

    public string Numerodeposito { get; set; } = null!;

    public decimal Montocordoba { get; set; }

    public decimal Montodolar { get; set; }

    public string? AsientoContable { get; set; }

    public virtual FafDiario FafDiario { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace apiFactura.Models;

public partial class FafDiario
{
    public string Codsucursal { get; set; } = null!;

    public DateTime Fechacierre { get; set; }

    public string Numeroconsecutivo { get; set; } = null!;

    public decimal Efectivocordoba { get; set; }

    public decimal Efectivodolar { get; set; }

    public decimal Chequecordoba { get; set; }

    public decimal Chequedolar { get; set; }

    public decimal Otros { get; set; }

    public decimal Retencion { get; set; }

    public decimal Tipocambio { get; set; }

    public short Diacerrado { get; set; }

    public string Usuario { get; set; } = null!;

    public DateTime Fecharegistro { get; set; }

    public string Usuario1 { get; set; } = null!;

    public DateTime Fechaupdate { get; set; }

    public decimal Otrosdolar { get; set; }

    public virtual ICollection<FafDiariodetalle> FafDiariodetalle { get; } = new List<FafDiariodetalle>();
}

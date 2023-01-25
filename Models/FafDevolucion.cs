using System;
using System.Collections.Generic;

namespace apiFactura.Models;

public partial class FafDevolucion
{
    public long Iddevolucion { get; set; }

    public string Codsucursal { get; set; } = null!;

    public string Factura { get; set; } = null!;

    public DateTime? Fecha { get; set; }

    public string? DocumentoInv { get; set; }

    public string? Referencia { get; set; }

    public string? Usuario { get; set; }

    public decimal? TipoCambio { get; set; }

    public decimal? TipoCambioParal { get; set; }

    public bool? Anulada { get; set; }

    public string? Asiento { get; set; }

    public string? NotaCredito { get; set; }

    public bool? AprobVenta { get; set; }

    public bool? AprobFinanza { get; set; }

    public bool? AprobOperacion { get; set; }

    public virtual ICollection<FafDevDetalle> FafDevDetalle { get; } = new List<FafDevDetalle>();

    public virtual FafFactura FafFactura { get; set; } = null!;
}

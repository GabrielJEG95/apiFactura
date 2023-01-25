using System;
using System.Collections.Generic;

namespace apiFactura.Models;

public partial class FafDepartamento
{
    public int Iddepartamento { get; set; }

    public string Descr { get; set; } = null!;

    public bool? Activo { get; set; }

    public virtual ICollection<FafFactura> FafFacturaIddepartamentoDestinoNavigation { get; } = new List<FafFactura>();

    public virtual ICollection<FafFactura> FafFacturaIddepartamentoOrigenNavigation { get; } = new List<FafFactura>();
}

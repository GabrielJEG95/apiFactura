using System;
using System.Collections.Generic;

namespace apiFactura.Models;

public partial class FafFactura
{
    public string Codsucursal { get; set; } = null!;

    /// <summary>
    /// Contado=1  o Credito=2
    /// </summary>
    public string Tipo { get; set; } = null!;

    /// <summary>
    /// formato historico de facturas pequena=1, grande=2, actual unica sera =0
    /// </summary>
    public string Tipoformato { get; set; } = null!;

    public string Factura { get; set; } = null!;

    public DateTime Fechafactura { get; set; }

    public string Codcliente { get; set; } = null!;

    public string Cliente { get; set; } = null!;

    public DateTime Fechavencimiento { get; set; }

    public string Codvendedor { get; set; } = null!;

    public string Remision { get; set; } = null!;

    /// <summary>
    /// correspondia al campo condicion , formas de pago(EF.GB,CK,CR)
    /// </summary>
    public string Tipopago { get; set; } = null!;

    public decimal Subtotal { get; set; }

    public decimal Descuento { get; set; }

    public decimal Iva { get; set; }

    public decimal Totalfactura { get; set; }

    public short Impresa { get; set; }

    public short Anulada { get; set; }

    public short Exonerada { get; set; }

    /// <summary>
    /// indica si se ha generado el paquete tipofacturacion para exactus
    /// </summary>
    public short Pendienteenvio { get; set; }

    public short Facturasinexistencia { get; set; }

    /// <summary>
    /// 0 by default, 1 = modificada
    /// </summary>
    public string Statusfactura { get; set; } = null!;

    public decimal Statusmonto { get; set; }

    public string Usuario { get; set; } = null!;

    public DateTime Fecharegistro { get; set; }

    public string Usuario1 { get; set; } = null!;

    public DateTime Fechaupdate { get; set; }

    public decimal Tipocambio { get; set; }

    public short Enespera { get; set; }

    public string Proforma { get; set; } = null!;

    public string? Asientocg { get; set; }

    public string? Asientocc { get; set; }

    public string? Asiento { get; set; }

    public bool? FlgCierreDia { get; set; }

    public bool? IsLoteGenerado { get; set; }

    public string? AsientoReversion { get; set; }

    public bool? FlgAveria { get; set; }

    public string? AsientoDevolucion { get; set; }

    public decimal? TipoCambioParalelo { get; set; }

    public decimal? TarifaFlete { get; set; }

    public decimal? TarifaFleteUsuario { get; set; }

    public decimal MontoFlete { get; set; }

    public int? IddepartamentoDestino { get; set; }

    public int? IddepartamentoOrigen { get; set; }

    public int? Idzona { get; set; }

    public virtual FafDescuentoFactura? FafDescuentoFactura { get; set; }

    public virtual FafDevolucion? FafDevolucion { get; set; }

    public virtual ICollection<FafFacturadetalle> FafFacturadetalle { get; } = new List<FafFacturadetalle>();

    public virtual FafDepartamento? IddepartamentoDestinoNavigation { get; set; }

    public virtual FafDepartamento? IddepartamentoOrigenNavigation { get; set; }
    public virtual GlobalVendedores? CodVendedorNavigation {get;set;}
}

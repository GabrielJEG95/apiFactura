using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace apiFactura.Models;

public partial class ExactusContext : DbContext
{
    public ExactusContext()
    {
    }

    public ExactusContext(DbContextOptions<ExactusContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FafAnexo> FafAnexo { get; set; }

    public virtual DbSet<FafAnexoGlobalUltimoCorteCcf> FafAnexoGlobalUltimoCorteCcf { get; set; }

    public virtual DbSet<FafAnexoglobal> FafAnexoglobal { get; set; }

    public virtual DbSet<FafArticuloPoliticaPrecio> FafArticuloPoliticaPrecio { get; set; }

    public virtual DbSet<FafBancos> FafBancos { get; set; }

    public virtual DbSet<FafBitacoraAprobaciones> FafBitacoraAprobaciones { get; set; }

    public virtual DbSet<FafCantMinDescuento> FafCantMinDescuento { get; set; }

    public virtual DbSet<FafCategoriaProdSucursal> FafCategoriaProdSucursal { get; set; }

    public virtual DbSet<FafCombo> FafCombo { get; set; }

    public virtual DbSet<FafComboClientes> FafComboClientes { get; set; }

    public virtual DbSet<FafComboCultivos> FafComboCultivos { get; set; }

    public virtual DbSet<FafComboSucursales> FafComboSucursales { get; set; }

    public virtual DbSet<FafConexionProcesoSucursal> FafConexionProcesoSucursal { get; set; }

    public virtual DbSet<FafConexionProcesoSucursal1> FafConexionProcesoSucursal1 { get; set; }

    public virtual DbSet<FafContadodetallehistorico> FafContadodetallehistorico { get; set; }

    public virtual DbSet<FafContadohistorico> FafContadohistorico { get; set; }

    public virtual DbSet<FafCultivoProductosControlados> FafCultivoProductosControlados { get; set; }

    public virtual DbSet<FafDepartamento> FafDepartamento { get; set; }

    public virtual DbSet<FafDescuentoFactura> FafDescuentoFactura { get; set; }

    public virtual DbSet<FafDescuentos> FafDescuentos { get; set; }

    public virtual DbSet<FafDevDetalle> FafDevDetalle { get; set; }

    public virtual DbSet<FafDevolucion> FafDevolucion { get; set; }

    public virtual DbSet<FafDevolucionGeneraAsiento> FafDevolucionGeneraAsiento { get; set; }

    public virtual DbSet<FafDevolucionborrar> FafDevolucionborrar { get; set; }

    public virtual DbSet<FafDiario> FafDiario { get; set; }

    public virtual DbSet<FafDiariodetalle> FafDiariodetalle { get; set; }

    public virtual DbSet<FafEstadoNegociacion> FafEstadoNegociacion { get; set; }

    public virtual DbSet<FafFactura> FafFactura { get; set; }

    public virtual DbSet<FafFacturacorrecion> FafFacturacorrecion { get; set; }
    public virtual DbSet<FafFacturadetalle> FafFacturadetalle { get; set; }
    public virtual DbSet<GlobalVendedores> GlobalVendedores {get;set;}
    public virtual DbSet<TmpImpresionFafFctura> TmpImpresionFafFcturas {get;set;}
    public virtual DbSet<TmpImpresionFafFacturaDetalle> TmpImpresionFafFacturaDetalle {get;set;}
    public virtual DbSet<UsuarioSucursal> UsuarioSucursal {get;set;}
    public virtual DbSet<GlobalSucursales> GlobalSucursales {get;set;}
    public virtual DbSet<CcfClientes> CcfClientes {get;set;}
    public virtual DbSet<FafTiposPago> FafTiposPago {get;set;}
    public virtual DbSet<FafParametrosGenerales> FafParametrosGenerales {get;set;}
    public virtual DbSet<Articulo> Articulo {get;set;}
    public virtual DbSet<Tipo_Cambio_Hist> Tipo_Cambio_Hist {get;set;}
    public virtual DbSet<globalUsuario> globalusuario{get;set;}
    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=10.10.0.10;Database=EXACTUS; Trusted_Connection=True;TrustServerCertificate=true");*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FafAnexo>(entity =>
        {
            entity.HasKey(e => new { e.Factura, e.FechaEmision, e.Usuario });

            entity.ToTable("fafANEXO", "fnica");

            entity.Property(e => e.Factura).HasMaxLength(20);
            entity.Property(e => e.FechaEmision)
                .HasDefaultValueSql("('19700101')")
                .HasColumnType("datetime");
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .HasColumnName("usuario");
            entity.Property(e => e.Abono).HasDefaultValueSql("((0))");
            entity.Property(e => e.Cancelada)
                .HasDefaultValueSql("((0))")
                .HasColumnName("cancelada");
            entity.Property(e => e.CodSucursalFactura).HasMaxLength(20);
            entity.Property(e => e.Codcliente)
                .HasMaxLength(20)
                .HasColumnName("CODCLIENTE");
            entity.Property(e => e.Codvendedor)
                .HasMaxLength(20)
                .HasColumnName("CODVENDEDOR");
            entity.Property(e => e.Debe)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)")
                .HasColumnName("debe");
            entity.Property(e => e.Deslizamiento)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)");
            entity.Property(e => e.Deslizamientoaplicado)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)");
            entity.Property(e => e.Dia)
                .HasDefaultValueSql("((0))")
                .HasColumnName("dia");
            entity.Property(e => e.FechaCorte)
                .HasDefaultValueSql("('19700101')")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaEmision2)
                .HasDefaultValueSql("('19700101')")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaVencimiento)
                .HasDefaultValueSql("('19700101')")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaVencimiento2)
                .HasDefaultValueSql("('19700101')")
                .HasColumnType("datetime");
            entity.Property(e => e.Haber)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)");
            entity.Property(e => e.Interes)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)");
            entity.Property(e => e.InteresAplicado)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)");
            entity.Property(e => e.NoVencido).HasDefaultValueSql("((0))");
            entity.Property(e => e.Nominal)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)");
            entity.Property(e => e.Orden)
                .HasDefaultValueSql("((0))")
                .HasColumnName("orden");
            entity.Property(e => e.Original)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)")
                .HasColumnName("original");
            entity.Property(e => e.Principal)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)");
            entity.Property(e => e.Recibo).HasMaxLength(20);
            entity.Property(e => e.TipoCambioFactura)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 8)");
            entity.Property(e => e.TipoDocumento).HasMaxLength(2);
            entity.Property(e => e.Total)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)")
                .HasColumnName("total");
            entity.Property(e => e.Valor)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)");
            entity.Property(e => e.Vencido).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<GlobalVendedores>(entity => 
        {
            entity.HasKey(e => e.Usuario).HasName("PK_Usuario");
            entity.ToTable("globalVENDEDORES","fnica");
            entity.Property(e => e.Codvendedor).HasMaxLength(4);
            entity.Property(e => e.Fecharegistro).HasColumnType("datetime");
            entity.Property(e => e.Fechaupdate).HasColumnType("datetime");
            entity.Property(e => e.EsAtv).HasDefaultValueSql("(0)");
        });

        modelBuilder.Entity<TmpImpresionFafFctura>(entity =>
        {
            entity.HasKey(e => new {e.Codsucursal,e.Factura,e.CodCliente,e.Codvendedor, e.FechaFactura});
            entity.ToTable("tmpImpresionfafFactura", "fnica");

        });

        modelBuilder.Entity<TmpImpresionFafFacturaDetalle>(entity =>
        {
            entity.HasKey(e => new {e.CodSucursal,e.Factura, e.CodCliente});
            entity.ToTable("tmpImpresionfafFACTURADetalle", "fnica");
        });
        modelBuilder.Entity<Articulo>(entity =>
        {
            entity.HasKey(e => e.ARTICULO).HasName("PK_ARTICULO");
            entity.ToTable("ARTICULO","fnica");
        });

        modelBuilder.Entity<Tipo_Cambio_Hist>(entity =>
        {
            entity.HasKey(e => new {e.Tipo_Cambio, e.Fecha, e.Monto});
            entity.ToTable("Tipo_Cambio_Hist","fnica");
        });

        modelBuilder.Entity<UsuarioSucursal>(entity =>
        {
            entity.HasKey(e => new {e.IdUsuario,e.CodSucursal});
            entity.ToTable("UsuarioSucursal", "fnica");

        });

        modelBuilder.Entity<GlobalSucursales>(entity =>
        {
            entity.HasKey(e => e.Codsucursal).HasName("PK_Codsucursal");
            entity.Property(e => e.Codsucursal).HasColumnType("varchar");
            entity.ToTable("GlobalSucursales","fnica");
        });

        modelBuilder.Entity<globalUsuario>(entity =>
        {
            entity.HasKey(e=> e.Usuario).HasName("PK_Usuario");
            entity.ToTable("globalusuario","fnica");
        });

        modelBuilder.Entity<CcfClientes>(entity =>
        {
            entity.HasKey(e => e.CodCliente).HasName("PK_CodCliente");
            entity.ToTable("CcfClientes","fnica");
        });

        modelBuilder.Entity<FafTiposPago>(entity => 
        {
            entity.HasKey(e => e.TipoPago).HasName("PK_TiposPago");
            entity.ToTable("fafTiposPago","fnica");
        });

        modelBuilder.Entity<FafParametrosGenerales>(entity =>
        {
            entity.HasKey(e => new {e.Titulo,e.Promocion1}).HasName("PK_ParametrosGenerales");
            entity.ToTable("fafParametrosGenerales","fnica");
        });

        modelBuilder.Entity<FafAnexoGlobalUltimoCorteCcf>(entity =>
        {
            entity.HasKey(e => new { e.Factura, e.FechaEmision, e.Codcliente, e.Usuario });

            entity.ToTable("fafAnexoGlobalUltimoCorteCCF", "fnica");

            entity.Property(e => e.Factura).HasMaxLength(20);
            entity.Property(e => e.FechaEmision)
                .HasDefaultValueSql("('19700101')")
                .HasColumnType("datetime");
            entity.Property(e => e.Codcliente)
                .HasMaxLength(20)
                .HasColumnName("CODCLIENTE");
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .HasColumnName("usuario");
            entity.Property(e => e.Abono).HasDefaultValueSql("((0))");
            entity.Property(e => e.Cancelada)
                .HasDefaultValueSql("((0))")
                .HasColumnName("cancelada");
            entity.Property(e => e.CodSucursalFactura).HasMaxLength(20);
            entity.Property(e => e.Codvendedor)
                .HasMaxLength(20)
                .HasColumnName("CODVENDEDOR");
            entity.Property(e => e.Debe)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)")
                .HasColumnName("debe");
            entity.Property(e => e.Deslizamiento)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)");
            entity.Property(e => e.Deslizamientoaplicado)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)");
            entity.Property(e => e.Dia)
                .HasDefaultValueSql("((0))")
                .HasColumnName("dia");
            entity.Property(e => e.FechaCorte)
                .HasDefaultValueSql("('19700101')")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaEmision2)
                .HasDefaultValueSql("('19700101')")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaVencimiento)
                .HasDefaultValueSql("('19700101')")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaVencimiento2)
                .HasDefaultValueSql("('19700101')")
                .HasColumnType("datetime");
            entity.Property(e => e.Haber)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)");
            entity.Property(e => e.Interes)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)");
            entity.Property(e => e.InteresAplicado)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)");
            entity.Property(e => e.NoVencido).HasDefaultValueSql("((0))");
            entity.Property(e => e.Nominal)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)");
            entity.Property(e => e.Orden)
                .HasDefaultValueSql("((0))")
                .HasColumnName("orden");
            entity.Property(e => e.Original)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)")
                .HasColumnName("original");
            entity.Property(e => e.Principal)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)");
            entity.Property(e => e.Recibo).HasMaxLength(20);
            entity.Property(e => e.TipoCambioFactura)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 8)");
            entity.Property(e => e.TipoDocumento).HasMaxLength(2);
            entity.Property(e => e.Total)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)")
                .HasColumnName("total");
            entity.Property(e => e.Valor)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)");
            entity.Property(e => e.Vencido).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<FafAnexoglobal>(entity =>
        {
            entity.HasKey(e => new { e.Factura, e.FechaEmision, e.Codcliente, e.Usuario });

            entity.ToTable("fafANEXOGLOBAL", "fnica");

            entity.Property(e => e.Factura).HasMaxLength(20);
            entity.Property(e => e.FechaEmision)
                .HasDefaultValueSql("('19700101')")
                .HasColumnType("datetime");
            entity.Property(e => e.Codcliente)
                .HasMaxLength(20)
                .HasColumnName("CODCLIENTE");
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .HasColumnName("usuario");
            entity.Property(e => e.Abono).HasDefaultValueSql("((0))");
            entity.Property(e => e.Cancelada)
                .HasDefaultValueSql("((0))")
                .HasColumnName("cancelada");
            entity.Property(e => e.CodSucursalFactura).HasMaxLength(20);
            entity.Property(e => e.Codvendedor)
                .HasMaxLength(20)
                .HasColumnName("CODVENDEDOR");
            entity.Property(e => e.Debe)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)")
                .HasColumnName("debe");
            entity.Property(e => e.Deslizamiento)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)");
            entity.Property(e => e.Deslizamientoaplicado)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)");
            entity.Property(e => e.Dia)
                .HasDefaultValueSql("((0))")
                .HasColumnName("dia");
            entity.Property(e => e.FechaCorte)
                .HasDefaultValueSql("('19700101')")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaEmision2)
                .HasDefaultValueSql("('19700101')")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaVencimiento)
                .HasDefaultValueSql("('19700101')")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaVencimiento2)
                .HasDefaultValueSql("('19700101')")
                .HasColumnType("datetime");
            entity.Property(e => e.Haber)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)");
            entity.Property(e => e.Interes)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)");
            entity.Property(e => e.InteresAplicado)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)");
            entity.Property(e => e.NoVencido).HasDefaultValueSql("((0))");
            entity.Property(e => e.Nominal)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)");
            entity.Property(e => e.Orden)
                .HasDefaultValueSql("((0))")
                .HasColumnName("orden");
            entity.Property(e => e.Original)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)")
                .HasColumnName("original");
            entity.Property(e => e.Principal)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)");
            entity.Property(e => e.Recibo).HasMaxLength(20);
            entity.Property(e => e.TipoCambioFactura)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 8)");
            entity.Property(e => e.TipoDocumento).HasMaxLength(2);
            entity.Property(e => e.Total)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)")
                .HasColumnName("total");
            entity.Property(e => e.Valor)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)");
            entity.Property(e => e.Vencido).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<FafArticuloPoliticaPrecio>(entity =>
        {
            entity.HasKey(e => e.ClasificacionArticulo).HasName("pkfafArticuloPoliticaPrecio");

            entity.ToTable("fafArticuloPoliticaPrecio", "fnica");

            entity.Property(e => e.ClasificacionArticulo).HasMaxLength(20);
        });

        modelBuilder.Entity<FafBancos>(entity =>
        {
            entity.HasKey(e => e.Codbanco);

            entity.ToTable("fafBANCOS", "fnica");

            entity.Property(e => e.Codbanco)
                .HasMaxLength(10)
                .HasColumnName("CODBANCO");
            entity.Property(e => e.CuentaBancoDol)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("(' ')");
            entity.Property(e => e.CuentaBancoLoc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("(' ')");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .HasColumnName("DESCRIPCION");
        });

        modelBuilder.Entity<FafBitacoraAprobaciones>(entity =>
        {
            entity.HasKey(e => new { e.Idnegociacion, e.Usuario, e.Fecha }).HasName("pkfafBitacoraAprobaciones");

            entity.ToTable("fafBitacoraAprobaciones", "fnica");

            entity.Property(e => e.Idnegociacion).HasColumnName("IDNegociacion");
            entity.Property(e => e.Usuario).HasMaxLength(50);
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<FafCantMinDescuento>(entity =>
        {
            entity.HasKey(e => e.Articulo).HasName("pkfafCantMinDescuento");

            entity.ToTable("fafCantMinDescuento", "fnica");

            entity.Property(e => e.Articulo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CantMinDescCliente)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 4)");
            entity.Property(e => e.CantMinDescDistribuidor)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 4)");
            entity.Property(e => e.CantMinDescMostrador)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 4)");
        });

        modelBuilder.Entity<FafCategoriaProdSucursal>(entity =>
        {
            entity.HasKey(e => new { e.Articulo, e.CodSucursal }).HasName("pkcatprodsuc");

            entity.ToTable("fafCategoriaProdSucursal", "fnica");

            entity.Property(e => e.Articulo).HasMaxLength(20);
            entity.Property(e => e.CodSucursal)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.Categoria).HasMaxLength(1);
        });

        modelBuilder.Entity<FafCombo>(entity =>
        {
            entity.HasKey(e => e.Idcombo).HasName("pkfafCombo");

            entity.ToTable("fafCombo", "fnica");

            entity.HasIndex(e => e.Articulo, "ukfafCombo").IsUnique();

            entity.Property(e => e.Idcombo).HasColumnName("IDCombo");
            entity.Property(e => e.Articulo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CantidadLimite)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 4)");
            entity.Property(e => e.Descr).HasMaxLength(250);
            entity.Property(e => e.FechaFin).HasColumnType("datetime");
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.PrecioDolar)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 4)");
            entity.Property(e => e.TipoValidacion)
                .HasMaxLength(1)
                .HasDefaultValueSql("('F')");
        });

        modelBuilder.Entity<FafComboClientes>(entity =>
        {
            entity.HasKey(e => new { e.Idcombo, e.CodCliente });

            entity.ToTable("fafComboClientes", "fnica");

            entity.Property(e => e.Idcombo).HasColumnName("IDCombo");
            entity.Property(e => e.CodCliente).HasMaxLength(10);
        });

        modelBuilder.Entity<FafComboCultivos>(entity =>
        {
            entity.HasKey(e => new { e.Idcombo, e.CodCultivo });

            entity.ToTable("fafComboCultivos", "fnica");

            entity.Property(e => e.Idcombo).HasColumnName("IDCombo");
            entity.Property(e => e.CodCultivo).HasMaxLength(3);
        });

        modelBuilder.Entity<FafComboSucursales>(entity =>
        {
            entity.HasKey(e => new { e.Idcombo, e.CodSucursal });

            entity.ToTable("fafComboSucursales", "fnica");

            entity.Property(e => e.Idcombo).HasColumnName("IDCombo");
            entity.Property(e => e.CodSucursal).HasMaxLength(4);
        });

        modelBuilder.Entity<FafConexionProcesoSucursal>(entity =>
        {
            entity.HasKey(e => e.Idproceso);

            entity.ToTable("fafConexionProcesoSucursal", tb =>
                {
                    tb.HasTrigger("EXFAFCONEXIONPROCESOSUCURSALDel");
                    tb.HasTrigger("EXFAFCONEXIONPROCESOSUCURSALIup");
                });

            entity.HasIndex(e => e.RowPointer, "FAFCONEXIONPROCESOSUCURSALRPIx").IsUnique();

            entity.Property(e => e.Idproceso)
                .HasMaxLength(50)
                .HasColumnName("IDPROCESO");
            entity.Property(e => e.Codsucursal)
                .HasMaxLength(50)
                .HasColumnName("CODSUCURSAL");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("(suser_sname())");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.RecordDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.RowPointer).HasDefaultValueSql("(newid())");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("(suser_sname())");
        });

        modelBuilder.Entity<FafConexionProcesoSucursal1>(entity =>
        {
            entity.HasKey(e => e.Idproceso);

            entity.ToTable("fafConexionProcesoSucursal", "fnica");

            entity.Property(e => e.Idproceso)
                .HasMaxLength(50)
                .HasColumnName("IDPROCESO");
            entity.Property(e => e.Codsucursal)
                .HasMaxLength(50)
                .HasColumnName("CODSUCURSAL");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
        });

        modelBuilder.Entity<FafContadodetallehistorico>(entity =>
        {
            entity.HasKey(e => new { e.CodSucursal, e.Tipo, e.NFactura });

            entity.ToTable("fafCONTADODETALLEHISTORICO", "fnica");

            entity.Property(e => e.CodSucursal)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cod_sucursal");
            entity.Property(e => e.Tipo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tipo");
            entity.Property(e => e.NFactura)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("n_factura");
            entity.Property(e => e.Cantidad)
                .HasColumnType("numeric(9, 2)")
                .HasColumnName("cantidad");
            entity.Property(e => e.CodProd)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cod_prod");
            entity.Property(e => e.Codcultivo)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("codcultivo");
            entity.Property(e => e.PreUnit)
                .HasColumnType("numeric(11, 4)")
                .HasColumnName("pre_unit");
            entity.Property(e => e.Valor)
                .HasColumnType("numeric(11, 2)")
                .HasColumnName("valor");
        });

        modelBuilder.Entity<FafContadohistorico>(entity =>
        {
            entity.HasKey(e => new { e.CodSucursal, e.Tipo, e.NFactura });

            entity.ToTable("fafCONTADOHISTORICO", "fnica");

            entity.Property(e => e.CodSucursal)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cod_sucursal");
            entity.Property(e => e.Tipo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tipo");
            entity.Property(e => e.NFactura)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("n_factura");
            entity.Property(e => e.Anulada).HasColumnName("anulada");
            entity.Property(e => e.Autoriza)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("autoriza");
            entity.Property(e => e.CodVend)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cod_vend");
            entity.Property(e => e.Cultivo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cultivo");
            entity.Property(e => e.Exonerada).HasColumnName("exonerada");
            entity.Property(e => e.FIngreso)
                .HasColumnType("datetime")
                .HasColumnName("f_ingreso");
            entity.Property(e => e.Igv)
                .HasColumnType("numeric(7, 2)")
                .HasColumnName("igv");
            entity.Property(e => e.Nombres)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("nombres");
            entity.Property(e => e.Remision)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("remision");
            entity.Property(e => e.TFactura)
                .HasColumnType("numeric(11, 2)")
                .HasColumnName("t_factura");
        });

        modelBuilder.Entity<FafCultivoProductosControlados>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("fafCultivoProductosControlados", "fnica");

            entity.Property(e => e.Articulo).HasMaxLength(20);
            entity.Property(e => e.Cultivo).HasMaxLength(10);
        });

        modelBuilder.Entity<FafDepartamento>(entity =>
        {
            entity.HasKey(e => e.Iddepartamento).HasName("pkfafDepartamento");

            entity.ToTable("fafDepartamento", "fnica");

            entity.Property(e => e.Iddepartamento)
                .ValueGeneratedNever()
                .HasColumnName("IDDepartamento");
            entity.Property(e => e.Activo).HasDefaultValueSql("((1))");
            entity.Property(e => e.Descr).HasMaxLength(256);
        });

        modelBuilder.Entity<FafDescuentoFactura>(entity =>
        {
            entity.HasKey(e => e.Iddescuento).HasName("pkfafDescuentoFactura");

            entity.ToTable("fafDescuentoFactura", "fnica");

            entity.HasIndex(e => new { e.CodSucursal, e.Factura }, "pkfafDescuentoSucFactura").IsUnique();

            entity.Property(e => e.Iddescuento).HasColumnName("IDDescuento");
            entity.Property(e => e.AsientoContado).HasMaxLength(20);
            entity.Property(e => e.CodSucursal).HasMaxLength(4);
            entity.Property(e => e.DescuentoDolar)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 4)");
            entity.Property(e => e.DescuentoLocal)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 4)");
            entity.Property(e => e.EsContado).HasDefaultValueSql("((0))");
            entity.Property(e => e.Factura).HasMaxLength(10);
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.NotaCredito).HasMaxLength(20);
            entity.Property(e => e.Referencia).HasMaxLength(256);
            entity.Property(e => e.TipoCambio)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 4)");
            entity.Property(e => e.TipoCambioParal)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 4)");
            entity.Property(e => e.Usuario).HasMaxLength(20);

            entity.HasOne(d => d.FafFactura).WithOne(p => p.FafDescuentoFactura)
                .HasForeignKey<FafDescuentoFactura>(d => new { d.CodSucursal, d.Factura })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pkfafDevoluionFactFact");
        });

        modelBuilder.Entity<FafDescuentos>(entity =>
        {
            entity.HasKey(e => new { e.Iddescuento, e.NivelPrecio, e.Articulo }).HasName("pkfafDescuento");

            entity.ToTable("fafDescuentos", "fnica");

            entity.HasIndex(e => new { e.NivelPrecio, e.Articulo, e.Desde, e.Hasta }, "ukfafDescuento").IsUnique();

            entity.Property(e => e.Iddescuento)
                .ValueGeneratedOnAdd()
                .HasColumnName("IDDescuento");
            entity.Property(e => e.NivelPrecio).HasMaxLength(20);
            entity.Property(e => e.Articulo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Desde).HasDefaultValueSql("((0))");
            entity.Property(e => e.Hasta).HasDefaultValueSql("((0))");
            entity.Property(e => e.PorcDesc)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 2)");
        });

        modelBuilder.Entity<FafDevDetalle>(entity =>
        {
            entity.HasKey(e => e.IddevDetalle).HasName("pkfafDevDetalle");

            entity.ToTable("fafDevDetalle", "fnica");

            entity.HasIndex(e => new { e.Iddevolucion, e.Articulo, e.Lote }, "ukfafDevDetalle").IsUnique();

            entity.Property(e => e.IddevDetalle).HasColumnName("IDDevDetalle");
            entity.Property(e => e.Articulo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Cantidad)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 4)");
            entity.Property(e => e.CostoDolar)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 4)");
            entity.Property(e => e.CostoLocal)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 4)");
            entity.Property(e => e.Iddevolucion).HasColumnName("IDDevolucion");
            entity.Property(e => e.Lote)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.MontoDolar)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 4)");
            entity.Property(e => e.MontoLocal)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 4)");
            entity.Property(e => e.PrecioDolar)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 4)");
            entity.Property(e => e.PrecioLocal)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 4)");

            entity.HasOne(d => d.IddevolucionNavigation).WithMany(p => p.FafDevDetalle)
                .HasForeignKey(d => d.Iddevolucion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ukfafDevDetalleDev");
        });

        modelBuilder.Entity<FafDevolucion>(entity =>
        {
            entity.HasKey(e => e.Iddevolucion).HasName("pkfafDevoluion");

            entity.ToTable("fafDevolucion", "fnica");

            entity.HasIndex(e => new { e.Codsucursal, e.Factura }, "ukfafDevoluion").IsUnique();

            entity.Property(e => e.Iddevolucion).HasColumnName("IDDevolucion");
            entity.Property(e => e.Anulada).HasDefaultValueSql("((0))");
            entity.Property(e => e.Asiento).HasMaxLength(20);
            entity.Property(e => e.Codsucursal).HasMaxLength(4);
            entity.Property(e => e.DocumentoInv)
                .HasMaxLength(20)
                .HasColumnName("Documento_Inv");
            entity.Property(e => e.Factura).HasMaxLength(10);
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.NotaCredito)
                .HasMaxLength(20)
                .HasDefaultValueSql("((0))");
            entity.Property(e => e.Referencia).HasMaxLength(256);
            entity.Property(e => e.TipoCambio)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 4)");
            entity.Property(e => e.TipoCambioParal)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 4)");
            entity.Property(e => e.Usuario).HasMaxLength(20);

            entity.HasOne(d => d.FafFactura).WithOne(p => p.FafDevolucion)
                .HasForeignKey<FafDevolucion>(d => new { d.Codsucursal, d.Factura })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pkfafDevoluionFact");
        });

        modelBuilder.Entity<FafDevolucionGeneraAsiento>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("fafDevolucionGeneraAsiento", "fnica");

            entity.Property(e => e.Articulo).HasMaxLength(20);
            entity.Property(e => e.Cantidad)
                .HasDefaultValueSql("((0))")
                .HasColumnType("numeric(12, 4)");
            entity.Property(e => e.CodCliente).HasMaxLength(10);
            entity.Property(e => e.CodSucursal).HasMaxLength(10);
            entity.Property(e => e.Documento).HasMaxLength(100);
            entity.Property(e => e.DocumentoInv).HasMaxLength(20);
            entity.Property(e => e.Factura).HasMaxLength(50);
            entity.Property(e => e.FechaFactura).HasColumnType("smalldatetime");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.IsFinish).HasDefaultValueSql("((0))");
            entity.Property(e => e.IsHeader).HasDefaultValueSql("((0))");
            entity.Property(e => e.Iva)
                .HasDefaultValueSql("((0))")
                .HasColumnType("numeric(12, 4)")
                .HasColumnName("IVA");
            entity.Property(e => e.Ivadolar)
                .HasDefaultValueSql("((0))")
                .HasColumnType("numeric(12, 4)")
                .HasColumnName("IVADolar");
            entity.Property(e => e.Lote)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Paquete).HasMaxLength(10);
            entity.Property(e => e.PrecioUnitario)
                .HasDefaultValueSql("((0))")
                .HasColumnType("numeric(12, 4)");
            entity.Property(e => e.PrecioUnitarioDolar)
                .HasDefaultValueSql("((0))")
                .HasColumnType("numeric(12, 4)");
            entity.Property(e => e.SubTotal)
                .HasDefaultValueSql("((0))")
                .HasColumnType("numeric(12, 4)");
            entity.Property(e => e.SubTotalDolar)
                .HasDefaultValueSql("((0))")
                .HasColumnType("numeric(12, 4)");
            entity.Property(e => e.Tipo)
                .HasMaxLength(1)
                .HasDefaultValueSql("((0))");
            entity.Property(e => e.TipoArticulo).HasMaxLength(1);
            entity.Property(e => e.TipoCambio)
                .HasDefaultValueSql("((0))")
                .HasColumnType("numeric(13, 4)");
            entity.Property(e => e.TipoFormato).HasMaxLength(1);
            entity.Property(e => e.Tipocambiopar)
                .HasDefaultValueSql("((0))")
                .HasColumnType("numeric(13, 4)")
                .HasColumnName("TIPOCAMBIOPAR");
            entity.Property(e => e.Total)
                .HasDefaultValueSql("((0))")
                .HasColumnType("numeric(12, 4)");
            entity.Property(e => e.TotalDolar)
                .HasDefaultValueSql("((0))")
                .HasColumnType("numeric(12, 4)");
        });

        modelBuilder.Entity<FafDevolucionborrar>(entity =>
        {
            entity.HasKey(e => e.Iddevolucion).HasName("pkDevolucion");

            entity.ToTable("fafDevolucionborrar", "fnica");

            entity.Property(e => e.Iddevolucion).HasColumnName("IDDevolucion");
            entity.Property(e => e.AsientoDev)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CodSucursal).HasMaxLength(4);
            entity.Property(e => e.Concepto).HasMaxLength(250);
            entity.Property(e => e.DocDevolucion)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DocumentoInv)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Documento_Inv");
            entity.Property(e => e.Factura).HasMaxLength(10);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.NumeroNotaCredito).HasMaxLength(20);
            entity.Property(e => e.NumeroNotaDebito).HasMaxLength(20);
        });

        modelBuilder.Entity<FafDiario>(entity =>
        {
            entity.HasKey(e => new { e.Codsucursal, e.Fechacierre, e.Numeroconsecutivo });

            entity.ToTable("fafDIARIO", "fnica", tb =>
                {
                    tb.HasTrigger("EXFAFDIARIODel");
                    tb.HasTrigger("EXFAFDIARIOIup");
                });

            entity.Property(e => e.Codsucursal)
                .HasMaxLength(4)
                .HasColumnName("CODSUCURSAL");
            entity.Property(e => e.Fechacierre)
                .HasColumnType("datetime")
                .HasColumnName("FECHACIERRE");
            entity.Property(e => e.Numeroconsecutivo)
                .HasMaxLength(10)
                .HasColumnName("NUMEROCONSECUTIVO");
            entity.Property(e => e.Chequecordoba)
                .HasColumnType("numeric(12, 4)")
                .HasColumnName("CHEQUECORDOBA");
            entity.Property(e => e.Chequedolar)
                .HasColumnType("numeric(12, 4)")
                .HasColumnName("CHEQUEDOLAR");
            entity.Property(e => e.Diacerrado).HasColumnName("DIACERRADO");
            entity.Property(e => e.Efectivocordoba)
                .HasColumnType("numeric(12, 4)")
                .HasColumnName("EFECTIVOCORDOBA");
            entity.Property(e => e.Efectivodolar)
                .HasColumnType("numeric(12, 4)")
                .HasColumnName("EFECTIVODOLAR");
            entity.Property(e => e.Fecharegistro)
                .HasColumnType("datetime")
                .HasColumnName("FECHAREGISTRO");
            entity.Property(e => e.Fechaupdate)
                .HasColumnType("datetime")
                .HasColumnName("FECHAUPDATE");
            entity.Property(e => e.Otros)
                .HasColumnType("numeric(12, 4)")
                .HasColumnName("OTROS");
            entity.Property(e => e.Otrosdolar)
                .HasColumnType("numeric(12, 4)")
                .HasColumnName("OTROSDOLAR");
            entity.Property(e => e.Retencion)
                .HasColumnType("numeric(12, 4)")
                .HasColumnName("RETENCION");
            entity.Property(e => e.Tipocambio)
                .HasColumnType("numeric(13, 4)")
                .HasColumnName("TIPOCAMBIO");
            entity.Property(e => e.Usuario)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("USUARIO");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(20)
                .HasColumnName("USUARIO1");
        });

        modelBuilder.Entity<FafDiariodetalle>(entity =>
        {
            entity.HasKey(e => new { e.Linea, e.Codsucursal, e.Fechacierre, e.Numeroconsecutivo });

            entity.ToTable("fafDIARIODETALLE", "fnica", tb =>
                {
                    tb.HasTrigger("EXFAFDIARIODETALLEDel");
                    tb.HasTrigger("EXFAFDIARIODETALLEIup");
                });

            entity.Property(e => e.Linea).HasColumnName("LINEA");
            entity.Property(e => e.Codsucursal)
                .HasMaxLength(4)
                .HasColumnName("CODSUCURSAL");
            entity.Property(e => e.Fechacierre)
                .HasColumnType("datetime")
                .HasColumnName("FECHACIERRE");
            entity.Property(e => e.Numeroconsecutivo)
                .HasMaxLength(10)
                .HasColumnName("NUMEROCONSECUTIVO");
            entity.Property(e => e.AsientoContable).HasMaxLength(20);
            entity.Property(e => e.Bancoemisor)
                .HasMaxLength(20)
                .HasColumnName("BANCOEMISOR");
            entity.Property(e => e.Bancoreceptor)
                .HasMaxLength(20)
                .HasColumnName("BANCORECEPTOR");
            entity.Property(e => e.Montocordoba)
                .HasColumnType("numeric(12, 4)")
                .HasColumnName("MONTOCORDOBA");
            entity.Property(e => e.Montodolar)
                .HasColumnType("numeric(12, 4)")
                .HasColumnName("MONTODOLAR");
            entity.Property(e => e.Nombrecliente)
                .HasMaxLength(50)
                .HasColumnName("NOMBRECLIENTE");
            entity.Property(e => e.Numerodeposito)
                .HasMaxLength(20)
                .HasColumnName("NUMERODEPOSITO");
            entity.Property(e => e.Numerodocumento)
                .HasMaxLength(20)
                .HasColumnName("NUMERODOCUMENTO");
            entity.Property(e => e.Tipopago)
                .HasMaxLength(2)
                .HasColumnName("TIPOPAGO");

            entity.HasOne(d => d.FafDiario).WithMany(p => p.FafDiariodetalle)
                .HasForeignKey(d => new { d.Codsucursal, d.Fechacierre, d.Numeroconsecutivo })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_fafDIARIODETALLE_fafDIARIO");
        });

        modelBuilder.Entity<FafEstadoNegociacion>(entity =>
        {
            entity.HasKey(e => e.CodEstado).HasName("pkfafEstadoNegociacion");

            entity.ToTable("fafEstadoNegociacion", "fnica");

            entity.Property(e => e.CodEstado).ValueGeneratedNever();
            entity.Property(e => e.Activo).HasDefaultValueSql("((0))");
            entity.Property(e => e.Descr).HasMaxLength(50);
        });

        modelBuilder.Entity<FafFactura>(entity =>
        {
            entity.HasKey(e => new { e.Codsucursal, e.Factura }).HasName("PK_fafFACTURA_1");

            entity.ToTable("fafFACTURA", "fnica");

            entity.Property(e => e.Codsucursal)
                .HasMaxLength(4)
                .HasColumnName("CODSUCURSAL");
            entity.Property(e => e.Factura)
                .HasMaxLength(10)
                .HasColumnName("FACTURA");
            entity.Property(e => e.Anulada).HasColumnName("ANULADA");
            entity.Property(e => e.Asiento).HasMaxLength(10);
            entity.Property(e => e.AsientoDevolucion).HasMaxLength(20);
            entity.Property(e => e.AsientoReversion).HasMaxLength(20);
            entity.Property(e => e.Asientocc)
                .HasMaxLength(10)
                .HasColumnName("ASIENTOCC");
            entity.Property(e => e.Asientocg)
                .HasMaxLength(10)
                .HasColumnName("ASIENTOCG");
            entity.Property(e => e.Cliente)
                .HasMaxLength(100)
                .HasColumnName("CLIENTE");
            entity.Property(e => e.Codcliente)
                .HasMaxLength(10)
                .HasColumnName("CODCLIENTE");
            entity.Property(e => e.Codvendedor)
                .HasMaxLength(4)
                .HasColumnName("CODVENDEDOR");
            entity.Property(e => e.Descuento)
                .HasColumnType("numeric(23, 13)")
                .HasColumnName("DESCUENTO");
            entity.Property(e => e.Enespera).HasColumnName("ENESPERA");
            entity.Property(e => e.Exonerada).HasColumnName("EXONERADA");
            entity.Property(e => e.Facturasinexistencia).HasColumnName("FACTURASINEXISTENCIA");
            entity.Property(e => e.Fechafactura)
                .HasComment("")
                .HasColumnType("smalldatetime")
                .HasColumnName("FECHAFACTURA");
            entity.Property(e => e.Fecharegistro)
                .HasColumnType("datetime")
                .HasColumnName("FECHAREGISTRO");
            entity.Property(e => e.Fechaupdate)
                .HasColumnType("datetime")
                .HasColumnName("FECHAUPDATE");
            entity.Property(e => e.Fechavencimiento)
                .HasColumnType("smalldatetime")
                .HasColumnName("FECHAVENCIMIENTO");
            entity.Property(e => e.FlgAveria)
                .HasDefaultValueSql("((0))")
                .HasColumnName("flgAveria");
            entity.Property(e => e.FlgCierreDia)
                .HasDefaultValueSql("((0))")
                .HasColumnName("flgCierreDia");
            entity.Property(e => e.IddepartamentoDestino).HasColumnName("IDDepartamentoDestino");
            entity.Property(e => e.IddepartamentoOrigen).HasColumnName("IDDepartamentoOrigen");
            entity.Property(e => e.Idzona).HasColumnName("IDZona");
            entity.Property(e => e.Impresa).HasColumnName("IMPRESA");
            entity.Property(e => e.IsLoteGenerado).HasDefaultValueSql("((0))");
            entity.Property(e => e.Iva)
                .HasColumnType("numeric(12, 4)")
                .HasColumnName("IVA");
            entity.Property(e => e.MontoFlete)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 4)");
            entity.Property(e => e.Pendienteenvio)
                .HasComment("indica si se ha generado el paquete tipofacturacion para exactus")
                .HasColumnName("PENDIENTEENVIO");
            entity.Property(e => e.Proforma)
                .HasMaxLength(10)
                .HasDefaultValueSql("((0))")
                .HasColumnName("PROFORMA");
            entity.Property(e => e.Remision)
                .HasMaxLength(10)
                .HasColumnName("REMISION");
            entity.Property(e => e.Statusfactura)
                .HasMaxLength(1)
                .HasDefaultValueSql("((0))")
                .HasComment("0 by default, 1 = modificada")
                .HasColumnName("STATUSFACTURA");
            entity.Property(e => e.Statusmonto)
                .HasColumnType("numeric(12, 4)")
                .HasColumnName("STATUSMONTO");
            entity.Property(e => e.Subtotal)
                .HasColumnType("numeric(12, 4)")
                .HasColumnName("SUBTOTAL");
            entity.Property(e => e.TarifaFlete)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 4)");
            entity.Property(e => e.TarifaFleteUsuario)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 4)");
            entity.Property(e => e.Tipo)
                .HasMaxLength(1)
                .HasComment("Contado=1  o Credito=2")
                .HasColumnName("TIPO");
            entity.Property(e => e.TipoCambioParalelo).HasColumnType("numeric(12, 4)");
            entity.Property(e => e.Tipocambio)
                .HasColumnType("numeric(13, 4)")
                .HasColumnName("TIPOCAMBIO");
            entity.Property(e => e.Tipoformato)
                .HasMaxLength(1)
                .HasComment("formato historico de facturas pequena=1, grande=2, actual unica sera =0")
                .HasColumnName("TIPOFORMATO");
            entity.Property(e => e.Tipopago)
                .HasMaxLength(50)
                .HasComment("correspondia al campo condicion , formas de pago(EF.GB,CK,CR)")
                .HasColumnName("TIPOPAGO");
            entity.Property(e => e.Totalfactura)
                .HasColumnType("numeric(12, 4)")
                .HasColumnName("TOTALFACTURA");
            entity.Property(e => e.Usuario)
                .HasMaxLength(20)
                .HasColumnName("USUARIO");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(20)
                .HasColumnName("USUARIO1");

            entity.HasOne(d => d.IddepartamentoDestinoNavigation).WithMany(p => p.FafFacturaIddepartamentoDestinoNavigation)
                .HasForeignKey(d => d.IddepartamentoDestino)
                .HasConstraintName("fk_fafFactura_fafDeptoDestino");

            entity.HasOne(d => d.IddepartamentoOrigenNavigation).WithMany(p => p.FafFacturaIddepartamentoOrigenNavigation)
                .HasForeignKey(d => d.IddepartamentoOrigen)
                .HasConstraintName("fk_fafFactura_fafDeptoOrigen");
        });

        modelBuilder.Entity<FafFacturacorrecion>(entity =>
        {
            entity.HasKey(e => new { e.Codsucursal, e.Factura }).HasName("PK_FAFCORRECION");

            entity.ToTable("fafFACTURACORRECION", "fnica");

            entity.Property(e => e.Codsucursal)
                .HasMaxLength(4)
                .HasColumnName("CODSUCURSAL");
            entity.Property(e => e.Factura)
                .HasMaxLength(10)
                .HasColumnName("FACTURA");
            entity.Property(e => e.Codtipocorrecion).HasColumnName("CODTIPOCORRECION");
            entity.Property(e => e.Concepto)
                .HasMaxLength(500)
                .HasColumnName("CONCEPTO");
            entity.Property(e => e.Fechacorrecion)
                .HasColumnType("datetime")
                .HasColumnName("FECHACORRECION");
            entity.Property(e => e.Fecharegistro)
                .HasColumnType("datetime")
                .HasColumnName("FECHAREGISTRO");
            entity.Property(e => e.Tipodocumento)
                .HasMaxLength(2)
                .HasColumnName("TIPODOCUMENTO");
            entity.Property(e => e.Usuario)
                .HasMaxLength(10)
                .HasColumnName("USUARIO");
        });

        modelBuilder.Entity<FafFacturadetalle>(entity =>
        {
            entity.HasKey(e => new { e.Codsucursal, e.Factura, e.Articulo, e.Lote });

            entity.ToTable("fafFACTURADETALLE", "fnica", tb => tb.HasTrigger("UptCostosToDetail"));

            entity.Property(e => e.Codsucursal)
                .HasMaxLength(4)
                .HasColumnName("CODSUCURSAL");
            entity.Property(e => e.Factura)
                .HasMaxLength(10)
                .HasColumnName("FACTURA");
            entity.Property(e => e.Articulo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("anteriormente codproducto en siscobro")
                .HasColumnName("ARTICULO");
            entity.Property(e => e.Lote)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('NA')")
                .HasColumnName("LOTE");
            entity.Property(e => e.AsientoDev)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Autorizacion)
                .HasMaxLength(25)
                .HasColumnName("AUTORIZACION");
            entity.Property(e => e.CantDevolucion)
                .HasDefaultValueSql("((0))")
                .HasColumnType("numeric(12, 4)");
            entity.Property(e => e.Cantidad)
                .HasColumnType("numeric(12, 4)")
                .HasColumnName("CANTIDAD");
            entity.Property(e => e.Categoria).HasMaxLength(1);
            entity.Property(e => e.Codcliente)
                .HasMaxLength(10)
                .HasColumnName("CODCLIENTE");
            entity.Property(e => e.Codcultivo)
                .HasMaxLength(3)
                .HasColumnName("CODCULTIVO");
            entity.Property(e => e.Combo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Costodolar)
                .HasColumnType("decimal(28, 8)")
                .HasColumnName("COSTODOLAR");
            entity.Property(e => e.Costolocal)
                .HasColumnType("decimal(28, 8)")
                .HasColumnName("COSTOLOCAL");
            entity.Property(e => e.Descuento)
                .HasColumnType("numeric(23, 13)")
                .HasColumnName("DESCUENTO");
            entity.Property(e => e.Descuentodolar)
                .HasColumnType("numeric(23, 13)")
                .HasColumnName("DESCUENTODOLAR");
            entity.Property(e => e.DocDevolucion)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Exonerada).HasColumnName("EXONERADA");
            entity.Property(e => e.FactorDevolucion).HasDefaultValueSql("((1))");
            entity.Property(e => e.Fechafactura)
                .HasColumnType("smalldatetime")
                .HasColumnName("FECHAFACTURA");
            entity.Property(e => e.Idnegociacion).HasColumnName("IDNegociacion");
            entity.Property(e => e.Iva)
                .HasColumnType("numeric(23, 13)")
                .HasColumnName("IVA");
            entity.Property(e => e.Ivadolar)
                .HasColumnType("numeric(23, 13)")
                .HasColumnName("IVADOLAR");
            entity.Property(e => e.Numeroserie)
                .HasMaxLength(250)
                .HasColumnName("NUMEROSERIE");
            entity.Property(e => e.PrecioDolarLista)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(28, 8)");
            entity.Property(e => e.PrecioPiso).HasColumnType("decimal(28, 8)");
            entity.Property(e => e.Preciounitario)
                .HasColumnType("numeric(12, 4)")
                .HasColumnName("PRECIOUNITARIO");
            entity.Property(e => e.Preciounitariodolar)
                .HasColumnType("numeric(23, 13)")
                .HasColumnName("PRECIOUNITARIODOLAR");
            entity.Property(e => e.Subtotal)
                .HasColumnType("numeric(12, 4)")
                .HasColumnName("SUBTOTAL");
            entity.Property(e => e.Subtotaldolar)
                .HasColumnType("numeric(23, 13)")
                .HasColumnName("SUBTOTALDOLAR");
            entity.Property(e => e.Tipo)
                .HasMaxLength(1)
                .HasColumnName("TIPO");
            entity.Property(e => e.Tipoformato)
                .HasMaxLength(1)
                .HasColumnName("TIPOFORMATO");
            entity.Property(e => e.Total)
                .HasColumnType("numeric(23, 13)")
                .HasColumnName("TOTAL");
            entity.Property(e => e.Totaldolar)
                .HasColumnType("numeric(23, 13)")
                .HasColumnName("TOTALDOLAR");

            entity.HasOne(d => d.FafFactura).WithMany(p => p.FafFacturadetalle)
                .HasForeignKey(d => new { d.Codsucursal, d.Factura })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_fafFACTURADETALLE_fafFACTURA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

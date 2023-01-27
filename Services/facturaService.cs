using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiFactura.Models.Dto;
using Common.Extensions;
using Common.Paginado;
using apiFactura.Models;
using System.Linq.Dynamic.Core;
using static apiFactura.Models.Dto.facturaDTO;
using apiFactura.Repository;
using Humanizer;
using NumberToWords;
using apiFactura.Common.Util;
using Common.Exceptions;
using System.Net;

namespace apiFactura.Services
{
    public interface IFacturaService
    {
        PaginaCollection<ListFactura> ListarFacturas (facturaDTO param);
        dynamic ListarFacturasImprimir (FacturaImprimirDTO param);
        dynamic ImprimirFactura(FafFActuraImpresorParam param);
        Task establecerFacturaImpresa (FafFActuraImpresorParam param);
    }

    public class FacturaService:IFacturaService
    {
        private readonly ExactusContext _context;
        private UsuarioSucursalRepository _usuarioSucursalRepository;
        private numeroALetras _numLetra;
        private FacturaRepository _facturaRepository;
        public FacturaService(ExactusContext context)
        {
            this._context = context;
            this._usuarioSucursalRepository = new UsuarioSucursalRepository(context);
            this._facturaRepository = new FacturaRepository(context);
            this._numLetra = new numeroALetras();
        }
        
        public PaginaCollection<ListFactura> ListarFacturas (facturaDTO param)
        {
            var result = _context.FafFactura.Where(w => (param.Factura.IsNullOrDefault() || Convert.ToInt32(w.Factura) == param.Factura)
                && (param.Codvendedor.IsNullOrEmpty() || w.Codvendedor.ToUpper() == param.Codvendedor.ToUpper())
                && (param.Codsucursal.IsNullOrEmpty() || w.Codsucursal.ToUpper() == param.Codsucursal.ToUpper())
                && (param.Codcliente.IsNullOrEmpty()||w.Codcliente.ToUpper()==param.Codcliente.ToUpper())            
                )
                .OrderBy(param.OrdenarPor + " "+ param.OrientarPor)
                .Select(s => new ListFactura 
                {
                    Factura=s.Factura,
                    Cliente=s.Cliente,
                    CodCliente=s.Codcliente,
                    Codvendedor=s.Codvendedor,
                    Vendedor=_context.GlobalVendedores.Where(w => w.Codsucursal == s.Codvendedor).Select(s => s.NombresVendedor).FirstOrDefault(),
                    Subtotal=s.Subtotal,
                    Descuento=s.Descuento,
                    Anulada=s.Anulada==1?"SI":s.Anulada==0?"NO":null,
                    Fechafactura=(DateTime)s.Fechafactura
                }).Paginar(param.pagina,param.registroPorPagina);

            return result;
        }

        public dynamic ListarFacturasImprimir (FacturaImprimirDTO param)
        {
            var data =  param.PendienteImprimir == 1 ? PendientesImprimir(param):FacturaImpresas(param);

            return data;
        }

        private PaginaCollection<FafGetFacturasImprimir> PendientesImprimir (FacturaImprimirDTO param)
        {
            var data = _usuarioSucursalRepository.obtenerUsuarioSucursal(param.Usuario);

            var result = _context.TmpImpresionFafFcturas.Where(w =>  data.Contains(w.Codsucursal) && w.Impresa==0 )
            .Select(s => new FafGetFacturasImprimir
            {
                Factura = s.Factura,
                FechaFactura = s.FechaFactura,
                Codsucursal=s.Codsucursal,
                Sucursal=_context.GlobalSucursales.FirstOrDefault(w => w.Codsucursal.ToUpper() == s.Codsucursal.ToUpper()).Sucursal,
                CodCliente=s.CodCliente,
                Cliente = _context.CcfClientes.Where(w => w.CodCliente.ToUpper() == s.CodCliente.ToUpper()).Select(s => $"{s.NombresCliente} {s.ApellidosCliente}").FirstOrDefault()
            }).Paginar(param.pagina,param.registroPorPagina);

            return result;
        }
            
        private PaginaCollection<FafGetFacturasImprimir> FacturaImpresas (FacturaImprimirDTO param)
        {
            var data = _usuarioSucursalRepository.obtenerUsuarioSucursal(param.Usuario);

            var result = _context.FafFactura.Where(w =>  data.Contains(w.Codsucursal) 
            && w.Impresa== 1
            && w.Fechafactura >= param.FechaInicial && w.Fechafactura <=  param.FechaFinal)
            .Select(s => new FafGetFacturasImprimir
            {
                Factura = s.Factura,
                FechaFactura = s.Fechafactura,
                Codsucursal=s.Codsucursal,
                Sucursal= _context.GlobalSucursales.FirstOrDefault(w => w.Codsucursal.ToUpper() == s.Codsucursal.ToUpper()).Sucursal,
                CodCliente=s.Codcliente,
                Cliente = _context.CcfClientes.Where(w => w.CodCliente.ToUpper() == s.Codcliente.ToUpper()).Select(s => $"{s.NombresCliente} {s.ApellidosCliente}").FirstOrDefault()
            }).Paginar(param.pagina,param.registroPorPagina);

            return result;
        }

        public dynamic ImprimirFactura(FafFActuraImpresorParam param)
        {
            var result = param.impresa == 1?FafImprimirFactura(param):tmpImprimirFactura(param);
            return result;
        }
        private List<headerFacturaImprimir> FafImprimirFactura(FafFActuraImpresorParam param)
        {
            var result = _context.FafFactura.Where(w => w.Codsucursal.ToUpper() == param.CodSucursal.ToUpper() && w.Factura == param.numeroFactura)
            .Select(s => new headerFacturaImprimir
            {
                CodSucursal=s.Codsucursal,
                Sucursal= _context.GlobalSucursales.FirstOrDefault(w => w.Codsucursal.ToUpper() == param.CodSucursal.ToUpper()).Sucursal,
                Tipo=s.Tipo,
                TipoFormato=s.Tipoformato,
                Factura=s.Factura,
                FechaFactura=s.Fechafactura,
                CodCliente=s.Codcliente,
                Cliente = s.Cliente,
                FechaVencimiento = s.Fechavencimiento,
                Codvendedor=s.Codvendedor,
                NombreVendedor=_context.GlobalVendedores.Where(w => w.Codvendedor.ToUpper()==s.Codvendedor.ToUpper()).Select(s => $"{s.NombresVendedor} {s.ApellidosVendedor}").FirstOrDefault(),
                Remision=s.Remision,
                TipoPago=s.Tipopago,
                DescriptoPago=_context.FafTiposPago.FirstOrDefault(w => w.TipoPago.ToUpper()==s.Tipopago.ToUpper()).Descripcion,
                Subtotal = s.Subtotal,
                Iva=s.Iva,
                TotalFactura=s.Totalfactura,
                TipoCambio=s.Tipocambio,
                TipoCambioParalelo=_context.Tipo_Cambio_Hist.FirstOrDefault(w => w.Fecha == s.Fechafactura && w.Tipo_Cambio.ToUpper() == "TCOM").Monto,
                NumAutorizadoDgi=_context.FafParametrosGenerales.FirstOrDefault(w => w.PermitirParcial == 1).NumAutorizadoDgi,
                NombreCliente=_context.CcfClientes.Where(w => w.Codvendedor.ToUpper() == s.Codvendedor.ToUpper()).Select(s => $"{s.NombresCliente} {s.ApellidosCliente}").FirstOrDefault(),
                AllowEditName=_context.CcfClientes.FirstOrDefault(w => w.CodCliente.ToUpper()==s.Codcliente.ToUpper()).AllowEditName,
                Expr1=$"{_numLetra.NumeroALetras(s.Totalfactura)} con {s.Totalfactura % 1}",
                MontoLetrasDolar=$"{_numLetra.NumeroALetras((s.Totalfactura+s.MontoFlete)/s.Tipocambio)} con {((s.Totalfactura+s.MontoFlete)/s.Tipocambio) % 1}",
                detailFacturaImprimirs=_context.FafFacturadetalle
                .Where(w => w.Factura == s.Factura && w.Codsucursal.ToUpper() == s.Codsucursal.ToUpper())
                .Select(se => new detailFacturaImprimir
                {
                    Cantidad = se.Cantidad,
                    PrecioUnitario=se.Preciounitario,
                    Subtotal=se.Subtotal,
                    Descuento=se.Descuento,
                    Iva=se.Iva,
                    Total=se.Total,
                    CodCultivo=se.Codcultivo,
                    Numeroserie=se.Numeroserie,
                    Articulo=se.Articulo,
                    Combo=se.Combo,
                    Descripcion = _context.Articulo.FirstOrDefault(w => w.ARTICULO.ToUpper()==se.Articulo.ToUpper()).Descripcion,
                    Factor_Empaque=_context.Articulo.FirstOrDefault(w => w.ARTICULO.ToUpper()==se.Articulo.ToUpper()).Factor_Empaque,
                    Unidad_Almacen=_context.Articulo.FirstOrDefault(w => w.ARTICULO.ToUpper() == se.Articulo.ToUpper()).Unidad_Almacen,
                    Lote= se.Lote 
                }).ToList()
            })
            .ToList();

            return result;
        }
        private List<headerFacturaImprimir> tmpImprimirFactura(FafFActuraImpresorParam param)
        {
            var result = _context.TmpImpresionFafFcturas.Where(w => (param.CodSucursal.IsNullOrEmpty() || w.Codsucursal.ToUpper() == param.CodSucursal.ToUpper())
                && (param.numeroFactura.IsNullOrEmpty() || w.Factura == param.numeroFactura)
            ).Select(s => new headerFacturaImprimir
            {
                CodSucursal= s.Codsucursal,
                Sucursal= _context.GlobalSucursales.FirstOrDefault(w => w.Codsucursal.ToUpper() == s.Codsucursal.ToUpper()).Sucursal,
                Tipo=s.Tipo,
                TipoFormato=s.TipoFormato,
                Factura=s.Factura,
                FechaFactura=s.FechaFactura,
                CodCliente=s.CodCliente,
                Cliente=s.Cliente,
                FechaVencimiento=s.FechaVencimiento,
                Codvendedor=s.Codvendedor,
                NombreVendedor=_context.GlobalVendedores.Where(w => w.Codvendedor.ToUpper() == s.Codvendedor.ToUpper()).Select(s => $"{s.NombresVendedor} {s.ApellidosVendedor}").FirstOrDefault(),
                Remision=s.Remision,
                TipoPago=s.TipoPago,
                DescriptoPago=_context.FafTiposPago.FirstOrDefault(w => w.TipoPago.ToUpper()==s.TipoPago.ToUpper()).Descripcion,
                Subtotal=s.Subtotal,
                Descuento=s.Descuento,
                Iva=s.IVA,
                TotalFactura=s.TotalFactura,
                TipoCambio=s.TipoCambio,
                TipoCambioParalelo=_context.Tipo_Cambio_Hist.FirstOrDefault(w => w.Fecha == s.FechaFactura && w.Tipo_Cambio.ToUpper() == "TCOM").Monto,
                NumAutorizadoDgi=_context.FafParametrosGenerales.FirstOrDefault(w => w.PermitirParcial == 1).NumAutorizadoDgi,
                NombreCliente=_context.CcfClientes.Where(w => w.Codvendedor.ToUpper() == s.Codvendedor.ToUpper()).Select(s => $"{s.NombresCliente} {s.ApellidosCliente}").FirstOrDefault(),
                AllowEditName=_context.CcfClientes.FirstOrDefault(w => w.CodCliente.ToUpper()==s.CodCliente.ToUpper()).AllowEditName,
                Expr1=$"{_numLetra.NumeroALetras(s.TotalFactura)} con {s.TotalFactura % 1}",
                MontoLetrasDolar=$"{_numLetra.NumeroALetras((s.TotalFactura+s.MontoFlete)/s.TipoCambio)} con {((s.TotalFactura+s.MontoFlete)/s.TipoCambio) % 1}",
                detailFacturaImprimirs=_context.TmpImpresionFafFacturaDetalle
                .Where(w => w.Factura == s.Factura && w.CodSucursal.ToUpper() == s.Codsucursal.ToUpper())
                .Select(se => new detailFacturaImprimir
                {
                    Cantidad = se.Cantidad,
                    PrecioUnitario=se.PrecioUnitario,
                    Subtotal=se.Subtotal,
                    Descuento=se.Descuento,
                    Iva=se.Iva,
                    Total=se.Total,
                    CodCultivo=se.CodCultivo,
                    Numeroserie=se.Numeroserie,
                    Articulo=se.Articulo,
                    Combo=se.Combo,
                    Descripcion = _context.Articulo.FirstOrDefault(w => w.ARTICULO.ToUpper()==se.Articulo.ToUpper()).Descripcion,
                    Factor_Empaque=_context.Articulo.FirstOrDefault(w => w.ARTICULO.ToUpper()==se.Articulo.ToUpper()).Factor_Empaque,
                    Unidad_Almacen=_context.Articulo.FirstOrDefault(w => w.ARTICULO.ToUpper() == se.Articulo.ToUpper()).Unidad_Almacen,
                    Lote= se.Lote 
                }).ToList()
            }).ToList();

            return result;
        }
        public async Task establecerFacturaImpresa (FafFActuraImpresorParam param)
        { 
            bool existe = _facturaRepository.validaExisteFacturaTemp(param.CodSucursal, param.numeroFactura);

            if(!existe)
                throw new HttpStatusException(HttpStatusCode.NotFound, "La factura solicitada no existe");

            await updateFacturaImpresa(param.CodSucursal,param.numeroFactura);
            await eliminarTmpFactura(param.CodSucursal,param.numeroFactura);
            await eliminarTempFacturaDetalle(param.CodSucursal,param.numeroFactura);

        }

        private async Task updateFacturaImpresa(string CodSucursal, string numeroFactura)
        {
            FafFactura factura = _facturaRepository.obtenerFactura(CodSucursal,numeroFactura);

            _context.FafFactura.Update(factura);
            await _context.SaveChangesAsync();
        }

        private async Task eliminarTmpFactura(string Codsucursal, string numeroFactura)
        {
            TmpImpresionFafFctura tmpFactura = _facturaRepository.obtenerTempFactura(Codsucursal,numeroFactura);

            _context.TmpImpresionFafFcturas.Remove(tmpFactura);
            await _context.SaveChangesAsync();
        }

        private async Task eliminarTempFacturaDetalle(string Codsucursal, string numeroFactura)
        {
            var tmpDetalle = _facturaRepository.obtenerTempFacturaDetalle(Codsucursal,numeroFactura);

            _context.TmpImpresionFafFacturaDetalle.RemoveRange(tmpDetalle);
            await _context.SaveChangesAsync();

        }
        
    }
}
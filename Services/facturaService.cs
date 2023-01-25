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

namespace apiFactura.Services
{
    public interface IFacturaService
    {
        PaginaCollection<ListFactura> ListarFacturas (facturaDTO param);
        PaginaCollection<FafGetFacturasImprimir> ListarFacturasImprimir (FacturaImprimirDTO param);
    }

    public class FacturaService:IFacturaService
    {
        private readonly ExactusContext _context;
        private UsuarioSucursalRepository _usuarioSucursalRepository;
        public FacturaService(ExactusContext context)
        {
            this._context = context;
            this._usuarioSucursalRepository = new UsuarioSucursalRepository(context);
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

        public PaginaCollection<FafGetFacturasImprimir> ListarFacturasImprimir (FacturaImprimirDTO param)
        {
            var data =  param.PendienteImprimir == 1 ? PendientesImprimir(param):FacturaImpresas(param);

            return data;
        }

        public PaginaCollection<FafGetFacturasImprimir> PendientesImprimir (FacturaImprimirDTO param)
        {


            var data = _usuarioSucursalRepository.obtenerUsuarioSucursal(param.Usuario);

            var result = _context.TmpImpresionFafFcturas.Where(w =>  data.Contains(w.Codsucursal) && w.Impresa==0 )
            .Select(s => new FafGetFacturasImprimir
            {
                Factura = s.Factura,
                FechaFactura = s.FechaFactura,
                Codsucursal=s.Codsucursal,
                CodCliente=s.CodCliente
            }).Paginar(param.pagina,param.registroPorPagina);

            return result;
        }
            
        public PaginaCollection<FafGetFacturasImprimir> FacturaImpresas (FacturaImprimirDTO param)
        {
            var data = _usuarioSucursalRepository.obtenerUsuarioSucursal(param.Usuario);

            var result = _context.TmpImpresionFafFcturas.Where(w =>  data.Contains(w.Codsucursal) 
            && w.Impresa==1 
            && w.FechaFactura >= param.FechaInicial 
            && w.FechaFactura <= param.FechaFinal )
            .Select(s => new FafGetFacturasImprimir
            {
                Factura = s.Factura,
                FechaFactura = s.FechaFactura,
                Codsucursal=s.Codsucursal,
                CodCliente=s.CodCliente
            }).Paginar(param.pagina,param.registroPorPagina);

            return result;
        }
    }
}
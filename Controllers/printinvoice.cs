using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiFactura.Models.Dto;
using apiFactura.Services;
using Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using apiFactura.Models;
using iTextSharp.text.pdf.draw;
using System.Globalization;

namespace apiFactura.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class printinvoice : ControllerBase
    {
        private readonly IFacturaService _facturaService;
        private readonly IGlobalSucurusalServices _globalSucurusalServices;
        private readonly IccfClienteService _ccfClienteService;
        private readonly IglobalVendedoreService _globalVendedorService;
        private readonly IArticuloService _articuloService;
        private readonly InumeroLetraService _numeroLetraService;
        public printinvoice(IFacturaService facturaService, IGlobalSucurusalServices globalSucurusalServices, IccfClienteService ccfClienteService,
            IglobalVendedoreService globalVendedorService, IArticuloService articuloService, InumeroLetraService numeroLetraService)
        {
            this._facturaService = facturaService;
            this._globalSucurusalServices = globalSucurusalServices;
            this._ccfClienteService = ccfClienteService;
            this._globalVendedorService = globalVendedorService;
            this._articuloService = articuloService;
            this._numeroLetraService = numeroLetraService;
        }


        [HttpGet]
        public IActionResult PrintFactura([FromQuery] FafFActuraImpresorParam param)
        {
            try
            {
                List<headerFacturaImprimir> data = _facturaService.ImprimirFactura(param);
                List<detailFacturaImprimir> detalle = _facturaService.ImprimirDetalleFactura(param);

                using (MemoryStream ms = new MemoryStream())
                {   
                    float widthPoints = 71 * 72 / 25.4f;
                    Document document = new Document(new Rectangle(widthPoints, 1440f),10f,10f,10f,0f);
                    PdfWriter writer = PdfWriter.GetInstance(document, ms);
                    
                    //document.SetMargins(30,0,20,0);
                    document.Open();
                    PdfContentByte canva = writer.DirectContent;

                    Paragraph header = new Paragraph("FORMULADORA NICARAGUENSE", FontFactory.GetFont(FontFactory.HELVETICA,BaseFont.CP1252, 11, Font.BOLD));
                    header.Alignment = Element.ALIGN_CENTER;
                    document.Add(header);

                    Paragraph header2 = new Paragraph("HANON TALAVERA", FontFactory.GetFont(FontFactory.HELVETICA, 11, Font.BOLD));
                    header2.Alignment = Element.ALIGN_CENTER;
                    document.Add(header2);

                    Paragraph ruc = new Paragraph("RUC: J03100000162113", FontFactory.GetFont(FontFactory.HELVETICA, 11, Font.BOLD));
                    ruc.Alignment = Element.ALIGN_CENTER;
                    document.Add(ruc);
                    foreach (var item in data)
                    {
                        
                        var sucursalObj = _globalSucurusalServices.ObtenerGlobalSucursal(item.CodSucursal);
                        var clienteObj = _ccfClienteService.obtenerCliente(item.CodCliente);
                        var vendedorObj = _globalVendedorService.obtenerVendedor(item.Codvendedor);
                        string tipo = "";

                        Paragraph tipoFac = new Paragraph("Tipo de Factura:", FontFactory.GetFont(FontFactory.HELVETICA, 11, Font.BOLD));
                        tipoFac.Alignment = Element.ALIGN_CENTER;
                        tipoFac.Add(tipo=item.Tipo=="1"?"CONTADO":"CREDITO");
                        document.Add(tipoFac);

                        Paragraph tipoCambio = new Paragraph("(T/C= ", FontFactory.GetFont(FontFactory.HELVETICA, 11, Font.BOLD));
                        tipoCambio.Alignment = Element.ALIGN_CENTER;
                        tipoCambio.Add($"{item.TipoCambio.ToString("#.##")})");
                        document.Add(tipoCambio);

                        
                        PdfPTable tableSuc = new PdfPTable(2);
                        tableSuc.WidthPercentage = 100;
                        tableSuc.DefaultCell.Border = Rectangle.TOP_BORDER;
                        tableSuc.DefaultCell.BorderWidth = 0;

                        tableSuc.AddCell(new PdfPCell(new Phrase(new Phrase("Sucursal:",FontFactory.GetFont(FontFactory.HELVETICA,11,Font.BOLD)))){Border = 0});
                        tableSuc.AddCell(new Phrase(new Phrase($"{item.CodSucursal}-{item.Sucursal}",FontFactory.GetFont(FontFactory.HELVETICA,10,Font.NORMAL)))); 
                        tableSuc.AddCell("");
                        tableSuc.AddCell("");
                        float[] widthsSuc = new float[] {30,70};
                        tableSuc.SetWidths(widthsSuc);

                        document.Add(tableSuc);

                        PdfPTable tableDir = new PdfPTable(2);
                        tableDir.WidthPercentage = 100;
                        tableDir.DefaultCell.Border = Rectangle.TOP_BORDER;
                        tableDir.DefaultCell.BorderWidth = 0;

                        tableDir.AddCell(new PdfPCell(new Phrase(new Phrase("Dirección:",FontFactory.GetFont(FontFactory.HELVETICA,11,Font.BOLD)))){Border = 0});
                        tableDir.AddCell(new Phrase(new Phrase(sucursalObj.Direccionsucursal,FontFactory.GetFont(FontFactory.HELVETICA,10,Font.NORMAL)))); 
                        tableDir.AddCell("");
                        tableDir.AddCell("");
                        float[] widthsDir = new float[] {32,68};
                        tableDir.SetWidths(widthsDir);

                        document.Add(tableDir);

                        PdfPTable tableNumFact = new PdfPTable(2);
                        tableNumFact.WidthPercentage = 100;
                        tableNumFact.DefaultCell.Border = Rectangle.TOP_BORDER;
                        tableNumFact.DefaultCell.BorderWidth = 0;

                        tableNumFact.AddCell(new PdfPCell(new Phrase(new Phrase("No Factura:",FontFactory.GetFont(FontFactory.HELVETICA,11,Font.BOLD)))){Border = 0});
                        tableNumFact.AddCell(new Phrase(new Phrase($"D {item.Factura}",FontFactory.GetFont(FontFactory.HELVETICA,10,Font.NORMAL)))); 
                        tableNumFact.AddCell("");
                        tableNumFact.AddCell("");
                        float[] widthNumFact = new float[] {40,60};
                        tableNumFact.SetWidths(widthNumFact);

                        document.Add(tableNumFact);

                        PdfPTable tableVend = new PdfPTable(2);
                        tableVend.WidthPercentage = 100;
                        tableVend.DefaultCell.Border = Rectangle.TOP_BORDER;
                        tableVend.DefaultCell.BorderWidth = 0;

                        tableVend.AddCell(new PdfPCell(new Phrase(new Phrase("Vendedor:",FontFactory.GetFont(FontFactory.HELVETICA,11,Font.BOLD)))){Border = 0});
                        tableVend.AddCell(new Phrase(new Phrase($"{vendedorObj.NombresVendedor} {vendedorObj.ApellidosVendedor}",FontFactory.GetFont(FontFactory.HELVETICA,10,Font.NORMAL)))); 
                        tableVend.AddCell("");
                        tableVend.AddCell("");
                        float[] widthVend = new float[] {35,65};
                        tableVend.SetWidths(widthVend);

                        document.Add(tableVend);

                        PdfPTable tableClient = new PdfPTable(2);
                        tableClient.WidthPercentage = 100;
                        tableClient.DefaultCell.Border = Rectangle.TOP_BORDER;
                        tableClient.DefaultCell.BorderWidth = 0;

                        tableClient.AddCell(new PdfPCell(new Phrase(new Phrase("Cliente:",FontFactory.GetFont(FontFactory.HELVETICA,11,Font.BOLD)))){Border = 0});
                        tableClient.AddCell(new Phrase(new Phrase($"{item.CodCliente} {clienteObj.NombresCliente} {clienteObj.ApellidosCliente}",FontFactory.GetFont(FontFactory.HELVETICA,10,Font.NORMAL)))); 
                        tableClient.AddCell("");
                        tableClient.AddCell("");
                        float[] widthClient = new float[] {30,70};
                        tableClient.SetWidths(widthClient);

                        document.Add(tableClient);

                        PdfPTable tableFechaFact = new PdfPTable(2);
                        tableFechaFact.WidthPercentage = 100;
                        tableFechaFact.DefaultCell.Border = Rectangle.TOP_BORDER;
                        tableFechaFact.DefaultCell.BorderWidth = 0;

                        tableFechaFact.AddCell(new PdfPCell(new Phrase(new Phrase("Fecha Fact:",FontFactory.GetFont(FontFactory.HELVETICA,11,Font.BOLD)))){Border = 0});
                        tableFechaFact.AddCell(new Phrase(new Phrase($"{item.FechaFactura.ToString("m",CultureInfo.GetCultureInfo("es-NI"))} de {item.FechaFactura.ToString("yyyy")}",FontFactory.GetFont(FontFactory.HELVETICA,10,Font.NORMAL)))); 
                        tableFechaFact.AddCell("");
                        tableFechaFact.AddCell("");
                        float[] widthFechaFact = new float[] {40,60};
                        tableFechaFact.SetWidths(widthFechaFact);

                        document.Add(tableFechaFact);

                        PdfPTable tableVence = new PdfPTable(2);
                        tableVence.WidthPercentage = 100;
                        tableVence.DefaultCell.Border = Rectangle.TOP_BORDER;
                        tableVence.DefaultCell.BorderWidth = 0;

                        tableVence.AddCell(new PdfPCell(new Phrase(new Phrase("Vence el:",FontFactory.GetFont(FontFactory.HELVETICA,11,Font.BOLD)))){Border = 0});
                        tableVence.AddCell(new Phrase(new Phrase("No Aplica",FontFactory.GetFont(FontFactory.HELVETICA,10,Font.NORMAL)))); 
                        tableVence.AddCell("");
                        tableVence.AddCell("");
                        float[] widthVence = new float[] {30,70};
                        tableVence.SetWidths(widthVence);

                        document.Add(tableVence);
                    }
                    

                    PdfPTable table = new PdfPTable(5);
                    table.WidthPercentage = 100;
                    table.DefaultCell.Border = Rectangle.TOP_BORDER;
                    table.DefaultCell.BorderWidth = 1;

                    LineSeparator  line = new LineSeparator(1,100, BaseColor.BLACK, Element.ALIGN_CENTER,0);
                    document.Add(line);


                    table.AddCell(new PdfPCell(new Phrase(new Phrase("Producto",FontFactory.GetFont(FontFactory.HELVETICA,7,Font.BOLD)))){Border = 0});
                    table.AddCell(new PdfPCell(new Phrase(new Phrase("Cantidad",FontFactory.GetFont(FontFactory.HELVETICA,7,Font.BOLD)))){Border = 0});
                    table.AddCell(new PdfPCell(new Phrase(new Phrase("Precio",FontFactory.GetFont(FontFactory.HELVETICA,7,Font.BOLD)))){Border = 0});
                    table.AddCell(new PdfPCell(new Phrase(new Phrase("IVA",FontFactory.GetFont(FontFactory.HELVETICA,7,Font.BOLD)))){Border = 0});
                    table.AddCell(new PdfPCell(new Phrase(new Phrase("TOTAL",FontFactory.GetFont(FontFactory.HELVETICA,7,Font.BOLD)))){Border = 0});
                    
                    table.AddCell("");
                    table.AddCell("");
                    table.AddCell("");
                    table.AddCell("");
                    table.AddCell("");

                    LineSeparator  line2 = new LineSeparator(1,100, BaseColor.BLACK, Element.ALIGN_CENTER,0);
                    document.Add(line2);
                    string iva = "";
                    string fleteMonto = "";
                    DateTime fechaImp = DateTime.Now;

                    float[] widths = new float[] { 33, 25, 25 ,25, 25 };
                    table.SetWidths(widths);
                    
                    foreach (detailFacturaImprimir item in detalle)
                    {
                        var articuloObj = _articuloService.obtenerArticulo(item.Articulo);

                        iva = item.Iva == 0? "0.00":item.Iva.ToString("#.##");
                        table.AddCell(new PdfPCell(new Phrase($"{item.Articulo}-{articuloObj.Descripcion}",FontFactory.GetFont(FontFactory.HELVETICA,7,Font.NORMAL))){Border = 0});
                        table.AddCell(new PdfPCell(new Phrase($"{item.Cantidad.ToString("#.##")}",FontFactory.GetFont(FontFactory.HELVETICA,7,Font.NORMAL))){Border = 0});
                        table.AddCell(new PdfPCell(new Phrase($"C$ {item.PrecioUnitario.ToString("#.##")}",FontFactory.GetFont(FontFactory.HELVETICA,7,Font.NORMAL))){Border = 0});
                        table.AddCell(new PdfPCell(new Phrase($"C$ {iva}",FontFactory.GetFont(FontFactory.HELVETICA,7,Font.BOLD))){Border = 0});
                        table.AddCell(new PdfPCell(new Phrase($"C$ {item.Total.ToString("#.##")}",FontFactory.GetFont(FontFactory.HELVETICA,7,Font.NORMAL))){Border = 0});
                    }
                   
                    document.Add(table);

                    LineSeparator line3 = new LineSeparator(1,100, BaseColor.BLACK, Element.ALIGN_CENTER,0);
                    document.Add(line3);

                    foreach (var item in data)
                    {
                        iva = item.Iva == 0? "0.00":item.Iva.ToString("N",new CultureInfo("es-NI"));
                        fleteMonto = item.MontoFlete == 0? "0.00":item.MontoFlete.ToString("N",new CultureInfo("es-NI"));
                        string numero = _numeroLetraService.numeroLetra(item.TotalFactura);

                        Paragraph subT = new Paragraph("SubTotal:  ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL));
                        subT.Alignment = Element.ALIGN_RIGHT;
                        subT.Add($"C${item.Subtotal.ToString("N",new CultureInfo("es-NI"))}");
                        document.Add(subT);

                        Paragraph impuesto = new Paragraph("IVA:  ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL));
                        impuesto.Alignment = Element.ALIGN_RIGHT;
                        impuesto.Add($"C$ {iva}");
                        document.Add(impuesto);

                        Paragraph flete = new Paragraph("FLETE:  ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL));
                        flete.Alignment = Element.ALIGN_RIGHT;
                        flete.Add($"C$ {fleteMonto}");
                        document.Add(flete);

                        Paragraph total = new Paragraph("TOTAL:  ", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL));
                        total.Alignment = Element.ALIGN_RIGHT;
                        total.Add($"C$ {item.TotalFactura.ToString("N", new CultureInfo("es-NI"))}");
                        document.Add(total);

                        Paragraph espacio = new Paragraph(" ", FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.BOLD));
                        espacio.Alignment = Element.ALIGN_LEFT;
                        document.Add(espacio);

                        Paragraph totalLetras = new Paragraph($"{numero} con {item.TotalFactura % 1}", FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.BOLD));
                        totalLetras.Alignment = Element.ALIGN_LEFT;
                        document.Add(totalLetras);
                    }

                    Paragraph IR = new Paragraph("Somos sujetos del 2% de IR", FontFactory.GetFont(FontFactory.HELVETICA, 7, Font.BOLD));
                    IR.Alignment = Element.ALIGN_LEFT;
                    document.Add(IR);

                    Paragraph saltoDeLinea = new Paragraph("                                                                                                                                                                                                                                                                                                                                                                                   ");
                    document.Add(saltoDeLinea);

                    
                    if(param.impresa == 1) 
                    {
                        LineSeparator line4 = new LineSeparator(1,60, BaseColor.BLACK, Element.ALIGN_CENTER,0);
                        document.Add(line4);

                        Paragraph firma = new Paragraph("FIRMA", FontFactory.GetFont(FontFactory.HELVETICA,BaseFont.CP1252, 7, Font.NORMAL));
                        firma.Alignment = Element.ALIGN_CENTER;
                        document.Add(firma);

                        Paragraph espacio4 = new Paragraph(" ", FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.BOLD));
                        espacio4.Alignment = Element.ALIGN_LEFT;
                        document.Add(espacio4);

                        Paragraph espacio5 = new Paragraph(" ", FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.BOLD));
                        espacio5.Alignment = Element.ALIGN_LEFT;
                        document.Add(espacio5);

                        LineSeparator line5 = new LineSeparator(1,60, BaseColor.BLACK, Element.ALIGN_CENTER,0);
                        document.Add(line5);

                        Paragraph firmaAut = new Paragraph("FIRMA AUTORIZADO", FontFactory.GetFont(FontFactory.HELVETICA,BaseFont.CP1252, 7, Font.NORMAL));
                        firmaAut.Alignment = Element.ALIGN_CENTER;
                        document.Add(firmaAut);

                        Paragraph espacio2 = new Paragraph(" ", FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.BOLD));
                        espacio2.Alignment = Element.ALIGN_LEFT;
                        document.Add(espacio2);

                        Paragraph reimp = new Paragraph("REIMPRESA", FontFactory.GetFont(FontFactory.HELVETICA,BaseFont.CP1252, 9, Font.NORMAL));
                        reimp.Alignment = Element.ALIGN_CENTER;
                        document.Add(reimp);

                        Paragraph espacio3 = new Paragraph(" ", FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.BOLD));
                        espacio3.Alignment = Element.ALIGN_LEFT;
                        document.Add(espacio3);
                    }

                    Paragraph autorizado = new Paragraph("AUT-DGI:ASFC 04/0097/08/2015/7", FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.BOLD));
                    autorizado.Alignment = Element.ALIGN_CENTER;
                    document.Add(autorizado);

                    Paragraph horaImp = new Paragraph("Fecha y Hora de Imp:  ", FontFactory.GetFont(FontFactory.HELVETICA, 7, Font.NORMAL));
                    horaImp.Alignment = Element.ALIGN_CENTER;
                    horaImp.Add(fechaImp.ToString());
                    document.Add(horaImp);

                    document.Close();
                    writer.Close();

                    return File(ms.ToArray(),"application/pdf");
                }
                
            }
            catch (System.Exception ex)
            {
                var error = RespuestaModel.ProcesarExcepción(ex);
                return StatusCode(error.statusCode, error);
            }
        }

    }
}
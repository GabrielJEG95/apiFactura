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

namespace apiFactura.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class printinvoice : ControllerBase
    {
        private readonly IFacturaService _facturaService;
        private readonly IGlobalSucurusalServices _globalSucurusalServices;
        private readonly IccfClienteService _ccfClienteService;
        public printinvoice(IFacturaService facturaService, IGlobalSucurusalServices globalSucurusalServices, IccfClienteService ccfClienteService)
        {
            this._facturaService = facturaService;
            this._globalSucurusalServices = globalSucurusalServices;
            this._ccfClienteService = ccfClienteService;
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

                        Paragraph tipoFac = new Paragraph("Tipo de Factura:", FontFactory.GetFont(FontFactory.HELVETICA, 11, Font.BOLD));
                        tipoFac.Alignment = Element.ALIGN_CENTER;
                        tipoFac.Add(item.DescriptoPago);
                        document.Add(tipoFac);

                        Paragraph tipoCambio = new Paragraph("(T/C= ", FontFactory.GetFont(FontFactory.HELVETICA, 11, Font.BOLD));
                        tipoCambio.Alignment = Element.ALIGN_CENTER;
                        tipoCambio.Add($"{item.TipoCambio.ToString("#.##")})");
                        document.Add(tipoCambio);

                        Paragraph sucursal = new Paragraph("Sucursal: ", FontFactory.GetFont(FontFactory.HELVETICA, 11, Font.BOLD));
                        sucursal.Alignment = Element.ALIGN_LEFT;         
                        sucursal.Add($"{item.CodSucursal}-{item.Sucursal}");           
                        document.Add(sucursal);

                        
                        /*Rectangle dir = new Rectangle(36,36,50,36);
                        ColumnText dirCol = new ColumnText(canva);
                        dirCol.SetSimpleColumn(dir);
                        dirCol.AddElement(new Paragraph("Direccion:",FontFactory.GetFont(FontFactory.HELVETICA,11,Font.BOLD)));
                        dirCol.Go();*/

                        Paragraph direccion = new Paragraph("Dirección: ", FontFactory.GetFont(FontFactory.HELVETICA, 11, Font.BOLD));
                        direccion.Alignment = Element.ALIGN_LEFT;
                        document.Add(direccion);

                        Paragraph direccionDesc = new Paragraph(sucursalObj.Direccionsucursal, FontFactory.GetFont(FontFactory.HELVETICA,10,Font.NORMAL));
                        direccionDesc.Alignment = Element.ALIGN_LEFT;
                        document.Add(direccionDesc);

                        Paragraph numFact = new Paragraph("No Factura:  ", FontFactory.GetFont(FontFactory.HELVETICA, 11, Font.BOLD));
                        numFact.Alignment = Element.ALIGN_LEFT;
                        numFact.Add(item.Factura);
                        document.Add(numFact);

                        Paragraph vendedor = new Paragraph("Vendedor:  ", FontFactory.GetFont(FontFactory.HELVETICA, 11, Font.BOLD));
                        vendedor.Alignment = Element.ALIGN_LEFT;
                        vendedor.Add(item.Codvendedor);
                        document.Add(vendedor);

                        Paragraph cliente = new Paragraph("Cliente:  ", FontFactory.GetFont(FontFactory.HELVETICA, 11, Font.BOLD));
                        cliente.Alignment = Element.ALIGN_LEFT;
                        document.Add(cliente);

                        Paragraph clienteName = new Paragraph($"{item.CodCliente} {clienteObj.NombresCliente} {clienteObj.ApellidosCliente}",FontFactory.GetFont(FontFactory.HELVETICA,9,Font.NORMAL));
                        clienteName.Alignment = Element.ALIGN_RIGHT;
                        document.Add(clienteName);

                        Paragraph fechaFact = new Paragraph("Fecha Fact:  ", FontFactory.GetFont(FontFactory.HELVETICA, 11, Font.BOLD));
                        fechaFact.Alignment = Element.ALIGN_LEFT;
                        fechaFact.Add(item.FechaFactura.ToString("yyyy-MM-dd"));
                        document.Add(fechaFact);

                        Paragraph venceEL = new Paragraph("Vence el:  ", FontFactory.GetFont(FontFactory.HELVETICA, 11, Font.BOLD));
                        venceEL.Alignment = Element.ALIGN_LEFT;
                        document.Add(venceEL);
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

                    float[] widths = new float[] { 25, 25, 25 ,25, 25 };
                    table.SetWidths(widths);
                    
                    foreach (detailFacturaImprimir item in detalle)
                    {
                        iva = item.Iva == 0? "0.00":item.Iva.ToString("#.##");
                        table.AddCell(new PdfPCell(new Phrase(item.Articulo,FontFactory.GetFont(FontFactory.HELVETICA,7,Font.NORMAL))){Border = 0});
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
                        iva = item.Iva == 0? "0.00":item.Iva.ToString("#.##");
                        fleteMonto = item.MontoFlete == 0? "0.00":item.MontoFlete.ToString("#.##");

                        Paragraph subT = new Paragraph("SubTotal:  ", FontFactory.GetFont(FontFactory.HELVETICA, 11, Font.BOLD));
                        subT.Alignment = Element.ALIGN_RIGHT;
                        subT.Add(item.Subtotal.ToString("#.##"));
                        document.Add(subT);

                        Paragraph impuesto = new Paragraph("IVA:  ", FontFactory.GetFont(FontFactory.HELVETICA, 11, Font.BOLD));
                        impuesto.Alignment = Element.ALIGN_RIGHT;
                        impuesto.Add($"C$ {iva}");
                        document.Add(impuesto);

                        Paragraph flete = new Paragraph("FLETE:  ", FontFactory.GetFont(FontFactory.HELVETICA, 11, Font.BOLD));
                        flete.Alignment = Element.ALIGN_RIGHT;
                        flete.Add($"C$ {fleteMonto}");
                        document.Add(flete);

                        Paragraph total = new Paragraph("TOTAL:  ", FontFactory.GetFont(FontFactory.HELVETICA, 11, Font.BOLD));
                        total.Alignment = Element.ALIGN_RIGHT;
                        total.Add(item.TotalFactura.ToString("#.##"));
                        document.Add(total);
                    }

                    Paragraph saltoDeLinea = new Paragraph("                                                                                                                                                                                                                                                                                                                                                                                   ");
                    document.Add(saltoDeLinea);

                    Paragraph autorizado = new Paragraph("AUT-DGI:ASFC 04/0097/08/2015/7", FontFactory.GetFont(FontFactory.HELVETICA, 7, Font.BOLD));
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
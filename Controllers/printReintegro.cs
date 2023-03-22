using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiFactura.Services;
using Microsoft.AspNetCore.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using apiFactura.Models;
using iTextSharp.text.pdf.draw;
using System.Globalization;
using Common.Exceptions;

namespace apiFactura.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class printReintegro : ControllerBase
    {
        private readonly IsolicitudReintegroDePagoService _solicitudReintegroDePagoService;
        public printReintegro(IsolicitudReintegroDePagoService solicitudReintegroDePagoService)
        {
            this._solicitudReintegroDePagoService = solicitudReintegroDePagoService;
        }


        [HttpGet("{IdSolicitud:int}")]
        public IActionResult GetprintReintegro(int IdSolicitud)
        {
            try
            {
                var solicitud = _solicitudReintegroDePagoService.obtenerSolicitudReintegroPago(IdSolicitud);
                var solicitudDetalle = _solicitudReintegroDePagoService.obtenerSolicitudReintegroPagoDetalle(IdSolicitud);

                using (MemoryStream ms = new MemoryStream())
                {
                    Document document = new Document(PageSize.A4);
                    PdfWriter writer = PdfWriter.GetInstance(document, ms);

                    document.Open();
                    PdfContentByte canva = writer.DirectContent;

                    Paragraph header = new Paragraph("FORMUNICA", FontFactory.GetFont(FontFactory.HELVETICA,BaseFont.CP1252, 12, Font.BOLD));
                    header.Alignment = Element.ALIGN_CENTER;
                    document.Add(header);

                    Paragraph header2 = new Paragraph("SOLICITUD DE PAGO", FontFactory.GetFont(FontFactory.HELVETICA,BaseFont.CP1252, 12, Font.BOLD));
                    header2.Alignment = Element.ALIGN_CENTER;
                    document.Add(header2);

                    Paragraph saltoDeLinea = new Paragraph("                                                                                                                                                                                                                                                                                                                                                                                   ");
                    document.Add(saltoDeLinea);

                    

                    foreach (var item in solicitud)
                    {

                        PdfPTable tableIDSol = new PdfPTable(4);
                        tableIDSol.WidthPercentage = 100;
                        tableIDSol.DefaultCell.Border = Rectangle.TOP_BORDER;
                        tableIDSol.DefaultCell.BorderWidth = 0;

                        tableIDSol.AddCell(new PdfPCell(new Phrase(new Phrase("Id Solicitud:",FontFactory.GetFont(FontFactory.HELVETICA,9,Font.BOLD)))){Border = 0});
                        tableIDSol.AddCell(new Phrase(new Phrase(IdSolicitud.ToString(),FontFactory.GetFont(FontFactory.HELVETICA,9,Font.NORMAL)))); 
                        tableIDSol.AddCell(new PdfPCell(new Phrase(new Phrase("Fecha de Emision:",FontFactory.GetFont(FontFactory.HELVETICA,9,Font.BOLD)))){Border = 0});
                        tableIDSol.AddCell(new Phrase(new Phrase(item.FechaSolicitud.ToString(),FontFactory.GetFont(FontFactory.HELVETICA,9,Font.NORMAL)))); 
                        float[] widthIDSol = new float[] {56,50, 30,50};
                        tableIDSol.SetWidths(widthIDSol);

                        document.Add(tableIDSol);

                        PdfPTable tableUnidad = new PdfPTable(2);
                        tableUnidad.WidthPercentage = 100;
                        tableUnidad.DefaultCell.Border = Rectangle.TOP_BORDER;
                        tableUnidad.DefaultCell.BorderWidth = 0;

                        tableUnidad.AddCell(new PdfPCell(new Phrase(new Phrase("Unidad Solicitante:",FontFactory.GetFont(FontFactory.HELVETICA,9,Font.BOLD)))){Border = 0});
                        tableUnidad.AddCell(new Phrase(new Phrase(item.UnidadSolicitante,FontFactory.GetFont(FontFactory.HELVETICA,9,Font.NORMAL)))); 
                        tableUnidad.AddCell("");
                        tableUnidad.AddCell("");
                        float[] widthUnidad = new float[] {30,70};
                        tableUnidad.SetWidths(widthUnidad);

                        document.Add(tableUnidad);

                        PdfPTable tablBeneficiario = new PdfPTable(2);
                        tablBeneficiario.WidthPercentage = 100;
                        tablBeneficiario.DefaultCell.Border = Rectangle.TOP_BORDER;
                        tablBeneficiario.DefaultCell.BorderWidth = 0;

                        tablBeneficiario.AddCell(new PdfPCell(new Phrase(new Phrase("A Favor de:",FontFactory.GetFont(FontFactory.HELVETICA,9,Font.BOLD)))){Border = 0});
                        tablBeneficiario.AddCell(new Phrase(new Phrase(item.Beneficiario,FontFactory.GetFont(FontFactory.HELVETICA,9,Font.NORMAL)))); 
                        tablBeneficiario.AddCell("");
                        tablBeneficiario.AddCell("");
                        float[] widthBeneficiario = new float[] {30,70};
                        tablBeneficiario.SetWidths(widthBeneficiario);

                        document.Add(tablBeneficiario);

                        PdfPTable tableValor = new PdfPTable(2);
                        tableValor.WidthPercentage = 100;
                        tableValor.DefaultCell.Border = Rectangle.TOP_BORDER;
                        tableValor.DefaultCell.BorderWidth = 0;

                        tableValor.AddCell(new PdfPCell(new Phrase(new Phrase("Por el valor de:",FontFactory.GetFont(FontFactory.HELVETICA,9,Font.BOLD)))){Border = 0});
                        tableValor.AddCell(new Phrase(new Phrase($"{item.valor.ToString("N2", new CultureInfo("es-NI"))} ({item.Moneda})",FontFactory.GetFont(FontFactory.HELVETICA,9,Font.NORMAL)))); 
                        tableValor.AddCell("");
                        tableValor.AddCell("");
                        float[] widthValor = new float[] {30,70};
                        tableValor.SetWidths(widthValor);

                        document.Add(tableValor);

                        PdfPTable tableConcepto = new PdfPTable(2);
                        tableConcepto.WidthPercentage = 100;
                        tableConcepto.DefaultCell.Border = Rectangle.TOP_BORDER;
                        tableConcepto.DefaultCell.BorderWidth = 0;

                        tableConcepto.AddCell(new PdfPCell(new Phrase(new Phrase("En Concepto de:",FontFactory.GetFont(FontFactory.HELVETICA,9,Font.BOLD)))){Border = 0});
                        tableConcepto.AddCell(new Phrase(new Phrase(item.Concepto,FontFactory.GetFont(FontFactory.HELVETICA,9,Font.NORMAL)))); 
                        tableConcepto.AddCell("");
                        tableConcepto.AddCell("");
                        float[] widthConcepto = new float[] {30,70};
                        tableConcepto.SetWidths(widthConcepto);

                        document.Add(tableConcepto);
                    }
                    Paragraph saltoDeLinea2 = new Paragraph("                                                                                                                                                                                                                                                                                                                                                                                   ");
                    document.Add(saltoDeLinea2);

                    PdfPTable table = new PdfPTable(7);
                    table.WidthPercentage = 100;
                    table.DefaultCell.Border = Rectangle.TOP_BORDER;
                    table.DefaultCell.BorderWidth = 1;

                    LineSeparator  line = new LineSeparator(1,100, BaseColor.BLACK, Element.ALIGN_CENTER,0);
                    document.Add(line);


                    table.AddCell(new PdfPCell(new Phrase(new Phrase("Concepto",FontFactory.GetFont(FontFactory.HELVETICA,7,Font.BOLD)))){Border = 1, BorderWidthBottom = 1, BorderWidthLeft = 1});
                    table.AddCell(new PdfPCell(new Phrase(new Phrase("Fecha",FontFactory.GetFont(FontFactory.HELVETICA,7,Font.BOLD)))){Border = 1, BorderWidthBottom = 1, BorderWidthLeft = 1});
                    table.AddCell(new PdfPCell(new Phrase(new Phrase("Doc",FontFactory.GetFont(FontFactory.HELVETICA,7,Font.BOLD)))){Border = 1, BorderWidthBottom = 1,BorderWidthLeft = 1});
                    table.AddCell(new PdfPCell(new Phrase(new Phrase("Beneficiario",FontFactory.GetFont(FontFactory.HELVETICA,7,Font.BOLD)))){Border = 1, BorderWidthBottom = 1,BorderWidthLeft = 1});
                    table.AddCell(new PdfPCell(new Phrase(new Phrase("Monto",FontFactory.GetFont(FontFactory.HELVETICA,7,Font.BOLD)))){Border = 1, BorderWidthBottom = 1,BorderWidthLeft = 1});
                    table.AddCell(new PdfPCell(new Phrase(new Phrase("Centro de Costo",FontFactory.GetFont(FontFactory.HELVETICA,7,Font.BOLD)))){Border = 1, BorderWidthBottom = 1,BorderWidthLeft = 1});
                    table.AddCell(new PdfPCell(new Phrase(new Phrase("Cuenta Contable",FontFactory.GetFont(FontFactory.HELVETICA,7,Font.BOLD)))){Border = 1, BorderWidthBottom = 1,BorderWidthLeft = 1, BorderWidthRight = 1});

                    float[] widths = new float[] { 40, 15, 10 ,25, 15 ,30,30};
                    table.SetWidths(widths);

                    decimal suma = 0;

                    foreach (var item in solicitudDetalle)
                    {
                        table.AddCell(new PdfPCell(new Phrase(item.Concepto,FontFactory.GetFont(FontFactory.HELVETICA,BaseFont.CP1252,7,Font.NORMAL))){Border = 0, BorderWidthLeft = 1, BorderWidthBottom = 0.5F });
                        table.AddCell(new PdfPCell(new Phrase(item.FechaFactura.ToShortDateString(),FontFactory.GetFont(FontFactory.HELVETICA,BaseFont.CP1252,7,Font.NORMAL))){Border = 0, BorderWidthLeft = 1, BorderWidthBottom = 0.5F});
                        table.AddCell(new PdfPCell(new Phrase(item.NumeroFactura,FontFactory.GetFont(FontFactory.HELVETICA,BaseFont.CP1252,7,Font.NORMAL))){Border = 0, BorderWidthLeft = 1, BorderWidthBottom = 0.5F});
                        table.AddCell(new PdfPCell(new Phrase(item.NombreEstablecimiento_Persona,FontFactory.GetFont(FontFactory.HELVETICA,BaseFont.CP1252,7,Font.NORMAL))){Border = 0, BorderWidthLeft = 1, BorderWidthBottom = 0.5F});
                        table.AddCell(new PdfPCell(new Phrase(item.Monto.ToString("#.##"),FontFactory.GetFont(FontFactory.HELVETICA,BaseFont.CP1252,7,Font.NORMAL))){Border = 0, BorderWidthLeft = 1, BorderWidthBottom = 0.5F});
                        table.AddCell(new PdfPCell(new Phrase(item.Centro_Costo.ToString(),FontFactory.GetFont(FontFactory.HELVETICA,BaseFont.CP1252,7,Font.NORMAL))){Border = 0, BorderWidthLeft = 1, BorderWidthBottom = 0.5F});
                        table.AddCell(new PdfPCell(new Phrase(item.Cuenta_Contable.ToString(),FontFactory.GetFont(FontFactory.HELVETICA,BaseFont.CP1252,7,Font.NORMAL))){Border = 0, BorderWidthLeft = 1, BorderWidthRight = 1, BorderWidthBottom = 0.5F});

                        suma += item.Monto;
                    }

                    document.Add(table);

                    Paragraph saltoDeLinea3 = new Paragraph("                                                                                                                                                                                                                                                                                                                                                                                   ");
                    document.Add(saltoDeLinea3);

                    PdfPTable tableSumatoria = new PdfPTable(3);
                    tableSumatoria.WidthPercentage = 100;
                    tableSumatoria.DefaultCell.Border = Rectangle.TOP_BORDER;
                    tableSumatoria.DefaultCell.BorderWidth = 0;

                    tableSumatoria.AddCell("");
                    tableSumatoria.AddCell(new PdfPCell(new Phrase(new Phrase("SUMATORIA ==>",FontFactory.GetFont(FontFactory.HELVETICA,9,Font.BOLD)))){Border = 0});
                    tableSumatoria.AddCell(new PdfPCell(new Phrase(new Phrase(suma.ToString("N2", new CultureInfo("es-NI")),FontFactory.GetFont(FontFactory.HELVETICA,9,Font.BOLD)))){Border = 0});
                    float[] widthSuma = new float[] {100,30,60};
                    tableSumatoria.SetWidths(widthSuma);

                    document.Add(tableSumatoria);

                    PdfPTable tableElaboracion = new PdfPTable(3);
                    tableElaboracion.WidthPercentage = 100;
                    tableElaboracion.DefaultCell.Border = Rectangle.TOP_BORDER;
                    tableElaboracion.DefaultCell.BorderWidth = 0;

                    tableElaboracion.AddCell(new PdfPCell(new Phrase(new Phrase("Elaborado Por",FontFactory.GetFont(FontFactory.HELVETICA,9,Font.BOLD)))){Border = 0});
                    tableElaboracion.AddCell(new PdfPCell(new Phrase(new Phrase("Rvisado Por",FontFactory.GetFont(FontFactory.HELVETICA,9,Font.BOLD)))){Border = 0});
                    tableElaboracion.AddCell(new PdfPCell(new Phrase(new Phrase("Autorizado Por",FontFactory.GetFont(FontFactory.HELVETICA,9,Font.BOLD)))){Border = 0});
                    float[] widthElaboracion = new float[] {60,60,60};
                    tableElaboracion.SetWidths(widthElaboracion);

                    document.Add(tableElaboracion);

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
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

                    PdfPTable tableIDSol = new PdfPTable(2);
                    tableIDSol.WidthPercentage = 100;
                    tableIDSol.DefaultCell.Border = Rectangle.TOP_BORDER;
                    tableIDSol.DefaultCell.BorderWidth = 0;

                    tableIDSol.AddCell(new PdfPCell(new Phrase(new Phrase("Id Solicitud:",FontFactory.GetFont(FontFactory.HELVETICA,9,Font.BOLD)))){Border = 0});
                    tableIDSol.AddCell(new Phrase(new Phrase(IdSolicitud.ToString(),FontFactory.GetFont(FontFactory.HELVETICA,9,Font.NORMAL)))); 
                    tableIDSol.AddCell("");
                    tableIDSol.AddCell("");
                    float[] widthIDSol = new float[] {30,70};
                    tableIDSol.SetWidths(widthIDSol);

                    document.Add(tableIDSol);

                    foreach (var item in solicitud)
                    {
                        PdfPTable tableUnidad = new PdfPTable(2);
                        tableIDSol.WidthPercentage = 100;
                        tableIDSol.DefaultCell.Border = Rectangle.TOP_BORDER;
                        tableIDSol.DefaultCell.BorderWidth = 0;

                        tableUnidad.AddCell(new PdfPCell(new Phrase(new Phrase("Unidad Solicitante:",FontFactory.GetFont(FontFactory.HELVETICA,9,Font.BOLD)))){Border = 0});
                        tableUnidad.AddCell(new Phrase(new Phrase(item.UnidadSolicitante,FontFactory.GetFont(FontFactory.HELVETICA,9,Font.NORMAL)))); 
                        tableUnidad.AddCell("");
                        tableUnidad.AddCell("");
                        float[] widthUnidad = new float[] {30,70};
                        tableUnidad.SetWidths(widthUnidad);

                        document.Add(tableUnidad);
                    }
                    

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
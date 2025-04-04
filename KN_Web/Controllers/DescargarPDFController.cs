using iTextSharp.text;
using iTextSharp.text.pdf;
using KN_Web.BaseDatos;
using KN_Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace KN_Web.Controllers
{
    public class DescargarPDFController : Controller
    {
        CarritoModel carritoM = new CarritoModel();

        public ActionResult DescargarPDF(int? id)
    {
        if (id == null || id <= 0)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "ID de factura inválido.");
        }

        var factura = carritoM.ObtenerFacturaPorId(id.Value);
        if (factura == null)
        {
            return HttpNotFound("Factura no encontrada.");
        }

        try
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Document document = new Document();
                PdfWriter writer = PdfWriter.GetInstance(document, ms);
                document.Open();

                // Agregar logo
                string logoPath = Server.MapPath("~/dist/img/CafeLogo.jpg");
                if (!System.IO.File.Exists(logoPath))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Logo no encontrado.");
                }
                Image logo = Image.GetInstance(logoPath);
                logo.ScaleAbsolute(100f, 50f);
                logo.Alignment = Element.ALIGN_CENTER;
                document.Add(logo);

                // Detalles de la empresa
                Paragraph companyDetails = new Paragraph
                {
                    Alignment = Element.ALIGN_CENTER
                };
                companyDetails.Add("Café Mendez\nDota, Costa Rica\nTelefono +506 8856 6227\nEmail: support@company.com\n");
                companyDetails.SpacingAfter = 20f;
                document.Add(companyDetails);

                // Detalles de la factura
                document.Add(new Paragraph($"Factura #{factura.IdMaestro}"));
                document.Add(new Paragraph($"Fecha: {factura.FechaCompra.ToString("dd/MM/yyyy hh:mm:ss tt")}"));
                document.Add(new Paragraph($"SubTotal: {factura.SubTotal.ToString("N2")}"));
                document.Add(new Paragraph($"Impuestos: {factura.Impuesto.ToString("N2")}"));
                document.Add(new Paragraph($"Total: {factura.Total.ToString("N2")}"));

                document.Close();
                writer.Close();

                ms.Position = 0;
                return File(ms.ToArray(), "application/pdf", $"Factura_{factura.IdMaestro}.pdf");
            }
        }
        catch (Exception ex)
        {
            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Error al generar el PDF: " + ex.Message);
        }
    }
}
}


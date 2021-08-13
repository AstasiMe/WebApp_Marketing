using Microsoft.AspNetCore.Mvc;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationMarketing.Areas.Identity.Pages.Account.Tables
{
    public class ForecastController : Controller
    {
        public IActionResult GeneratePdf(string html)
        {
            HtmlToPdf converter = new HtmlToPdf();

            html = html.Replace("start", "<").Replace("end", ">");
            PdfDocument doc = converter.ConvertHtmlString(html);

            byte[] pdfFile = doc.Save();
            doc.Close();

            return File(pdfFile, "application/pdf");
        }
    }
}

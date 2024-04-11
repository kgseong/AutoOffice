using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace AutoOffice
{
    internal class PdfUtil
    {
        public static void MergePDFs(string targetPath, params string[] pdfs)
        {
            using (var targetDoc = new PdfDocument())
            {
                foreach (var pdf in pdfs)
                {
                    using (var pdfDoc = PdfReader.Open(pdf, PdfDocumentOpenMode.Import))
                    {
                        for (var i = 0; i < pdfDoc.PageCount; i++)
                            targetDoc.AddPage(pdfDoc.Pages[i]);
                    }
                }
                targetDoc.Save(targetPath);
            }
        }
    }
}

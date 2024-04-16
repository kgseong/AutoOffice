
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.RegularExpressions;

using xls = Microsoft.Office.Interop.Excel;
using word = Microsoft.Office.Interop.Word;
using ppt = Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Core;
using DocumentFormat.OpenXml;
using Microsoft.Office.Interop.Excel;


namespace AutoOffice
{
 
    internal class OficeUtil : IDisposable
    {
        object oMissing = System.Reflection.Missing.Value;
        word.Application doc_app;
        xls.Application xls_app;
        ppt.Application ppt_app;

        public  event EventHandler<DoneArgs> DoneEvent;

        public OficeUtil()
        {
        }
 
        public bool ToPDF(string src_path, string dest_path)
        {
            bool ok = false;
            if (System.IO.File.Exists(src_path) == false)
            {
                OnDoneEvent(new DoneArgs(src_path, false, dest_path, "해당 파일이 없습니다."));
                return false;
            }
            if (System.IO.File.Exists(dest_path) == true)
            {
                OnDoneEvent(new DoneArgs(src_path, false, dest_path, "PDF파일이 이미 있습니다."));
                return false;
            }
            try { 
                var doctp = Helper.GetDocType(src_path);
                if (doctp == DocType.None)
                {
                    OnDoneEvent(new DoneArgs(src_path, false, null, "지원되는 파일 형식이 아닙니다."));
                    return false;
                }
                switch (doctp)
                {
                    case DocType.Word:
                        ok =  WordToPdf(src_path, dest_path);
                        break;
                    case DocType.Xls:
                        ok = XlsToPdf(src_path, dest_path);
                        break;
                    case DocType.Ppt:
                        ok = PptToPdf(src_path, dest_path);
                        break;
                }
            }
            catch (Exception ex)
            {
                OnDoneEvent(new DoneArgs(src_path, false, dest_path, "처리중 오류가 발생하였습니다.\n" + ex.Message));
                return false;
            }
            OnDoneEvent(new DoneArgs(src_path, ok, dest_path));
            return ok;
        }

        public bool Print(string src_path)
        {
            bool ok = false;
            if (System.IO.File.Exists(src_path) == false)
            {
                OnDoneEvent(new DoneArgs(src_path, false, null, "해당 파일이 없습니다."));
                return false;
            }
            try
            {
                var doctp = Helper.GetDocType(src_path);
                if (doctp ==  DocType.None)
                {
                    OnDoneEvent(new DoneArgs(src_path, false, null, "지원되는 파일 형식이 아닙니다."));
                    return false;
                }
                switch (doctp)
                {
                    case DocType.Word:
                        ok = WordPrint(src_path);
                        break;
                    case DocType.Xls:
                        ok = XlsPrint(src_path);
                        break;
                    case DocType.Ppt:
                        ok = PptPrint(src_path);
                        break;
                    case DocType.Pdf:
                        ok = PdfPrint(src_path);
                        break;
                    case DocType.Hwp:
                        ok = HwpPrint(src_path);
                        break;
                }
            }
            catch(Exception ex)
            {
                OnDoneEvent(new DoneArgs(src_path, false, null, "처리중 오류가 발생하였습니다.\n" + ex.Message));
                return false;
            }
            OnDoneEvent(new DoneArgs(src_path, ok));
            return ok;
        }

        private xls.Workbook GetXls(string path)
        {
            if (xls_app == null)
            {
                xls_app = new xls.Application();
            }
            xls.Workbook doc = xls_app.Workbooks.Open(path);
            return doc;
        }
        private word.Document GetWord(string path)
        {
            if (doc_app == null)
            {
                doc_app = new word.Application();
            }
            word.Document doc = doc_app.Documents.Open(path);
            return doc;
        }
        private ppt.Presentation GetPpt(string path)
        {
            if (ppt_app == null)
            {
                ppt_app = new ppt.Application();
            }
            ppt.Presentation doc = ppt_app.Presentations.Open((string)path, MsoTriState.msoTrue, MsoTriState.msoTrue, MsoTriState.msoFalse);
            return doc;
        }

        private bool XlsToPdf(string src_path, string pdf_path)
        {

                xls.Workbook doc = GetXls(src_path);
                doc.ExportAsFixedFormat(xls.XlFixedFormatType.xlTypePDF, pdf_path);
                doc.Close();
                OnDoneEvent(new DoneArgs(src_path, true, pdf_path));
                return true;

            
            return true;
        }

        private bool WordToPdf(string src_path, string pdf_path)
        {
        
            word.Document doc = GetWord(src_path);

            object fileFormat = WdSaveFormat.wdFormatPDF;
            doc.ExportAsFixedFormat(pdf_path, WdExportFormat.wdExportFormatPDF);
            doc.Close();

            return true;

        }

        private bool PptToPdf(string src_path, string pdf_path)
        {

            ppt.Presentation doc = GetPpt(src_path);

            doc.ExportAsFixedFormat(pdf_path, ppt.PpFixedFormatType.ppFixedFormatTypePDF);
            doc.Close();
            return true;

        }

        private bool XlsPrint(string src_path)
        {
            xls.Workbook doc = GetXls(src_path);

            doc.PrintOutEx(oMissing, oMissing, oMissing, oMissing,oMissing, oMissing, oMissing, oMissing);

            doc.Close();
            return true;

        }
        private bool WordPrint(string src_path)
        {
            word.Document doc = GetWord(src_path);

            doc.PrintOut();
            doc.Close();
            return true;

        }

        private bool PptPrint(string src_path)
        {
            ppt.Presentation doc = GetPpt(src_path);
            doc.PrintOut();

            doc.Close();
            return true;

        }

        private bool PdfPrint(string src_path)
        {
            return Helper.RawPrint(src_path);
        }
        private bool HwpPrint(string src_path)
        {
            return Helper.RawPrint(src_path);
        }
        /*
        private bool RawPrint(string src_path)
        {
            using (System.Diagnostics.Process p = new System.Diagnostics.Process())
            {
                p.StartInfo = new System.Diagnostics.ProcessStartInfo()
                {
                    CreateNoWindow = true,
                    Verb = "print",
                    FileName = src_path //put the correct path here
                };
                p.Start();
            }
            return true;
        }
        public static void RunDoc(string src_path)
        {
            try
            {
                using (System.Diagnostics.Process p = new System.Diagnostics.Process())
                {
                    p.StartInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        CreateNoWindow = true,
                        FileName = src_path //put the correct path here
                    };
                    p.Start();
                }
            }
            catch { }
        }*/
        public void Dispose()
        {
            try
            {
                if (doc_app != null)
                {
                    doc_app.Quit();
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(doc_app);
                    doc_app = null;
                }
            }
            catch { }

            try
            {
                if (xls_app != null)
                {
                    xls_app.Quit();
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xls_app);
                    xls_app = null;
                }
            }
            catch { }

            try
            {
                if (ppt_app != null)
                {
                    ppt_app.Quit();
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(ppt_app);
                    ppt_app = null;
                }
            }
            catch { }



            //GC.Collect();
            //GC.SuppressFinalize(this);
            //Dispose();
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SuppressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
           
        }

        ~OficeUtil()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(disposing: false) is optimal in terms of
            // readability and maintainability.
            Dispose();
        }



        #region event
        protected virtual void OnDoneEvent(DoneArgs e)
        {
            EventHandler<DoneArgs> raiseEvent = DoneEvent;

            if (raiseEvent != null)
            {
                raiseEvent(this, e);
            }
        }
        #endregion
    }
}

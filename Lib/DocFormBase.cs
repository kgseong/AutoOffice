using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoOffice
{
    public class DocFormBase : IDocForm
    {
        public event EventHandler<DoneArgs> DoneEvent;
        public string FormFilePath { get; set; }
        public string SaveAsPath { get; set; }

        public DocFormBase(string formFilePth, string saveAsPath)
        {
            FormFilePath = formFilePth;
            SaveAsPath = saveAsPath;
        }

        public virtual bool FillData(Dictionary<string, string> values)
        {
            return true;
        }

        protected virtual void OnDoneEvent(DoneArgs e)
        {
            EventHandler<DoneArgs> raiseEvent = DoneEvent;

            if (raiseEvent != null)
            {
                raiseEvent(this, e);
            }
        }


        public static IDocForm GetDoc(string formpath, string savepath)
        {
            string ext = System.IO.Path.GetExtension(formpath).ToLower();
            var doctp = Helper.GetDocType(formpath);
            IDocForm doc;
            switch (doctp)
            {
                case DocType.Word:
                    doc = new WordForm(formpath, savepath);
                    return doc;
                    break;
                case DocType.Xls:
                    doc = new XlsForm(formpath, savepath);
                    return doc;
                    break;
                case DocType.Ppt:
                    doc = new PptForm(formpath, savepath);
                    return doc;
                    break;
                case DocType.Hwp:
                    doc = new HwpForm(formpath, savepath);
                    return doc;
                    break;
            }
            return null;
        }
        
        public static string GetFieldName(string name)
        {
            return Field.GetFieldName(name);
        }

    }
}

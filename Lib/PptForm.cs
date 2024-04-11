using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.IO.Packaging;

namespace AutoOffice
{
    internal class PptForm: IDocForm
    {

        public event EventHandler<DoneArgs> DoneEvent;
        public string FormFilePath { get; set; }
        public string SaveAsPath { get; set; }

        public PptForm (string formFilePth, string saveAsPath)
        {
            FormFilePath = formFilePth;
            SaveAsPath = saveAsPath;
        }
        public bool FillData(Dictionary<string, string> values)
        {
            System.IO.File.Copy(FormFilePath, SaveAsPath);
            using (PresentationDocument doc = PresentationDocument.Open(SaveAsPath, isEditable: true))
            {
                PresentationPart presentationPart = doc.PresentationPart;

                if (presentationPart != null)
                {
                    foreach (SlideMasterPart slideMasterPart in presentationPart.SlideMasterParts)
                    {
                        ReplaceText(slideMasterPart.SlideMaster.Descendants<DocumentFormat.OpenXml.Drawing.Text>(), values);
                    }

                    foreach (SlidePart slidePart in presentationPart.SlideParts)
                    {
                        ReplaceText(slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>(), values);
                    }
                }

                doc.Save();
                doc.Close();

                OnDoneEvent(new DoneArgs(FormFilePath, true, SaveAsPath));
            }

            return true;
        }

      
        private static void ReplaceText(IEnumerable<DocumentFormat.OpenXml.Drawing.Text> texts, Dictionary<string, string> replacements)
        {
            foreach (var text in texts)
            {
                foreach (var replacement in replacements.Where(replacement => text.Text.Contains(DocFormHelper.GetFieldName( replacement.Key ))))
                {
                    text.Text = text.Text.Replace(DocFormHelper.GetFieldName(replacement.Key), replacement.Value);
                }
            }
        }

        protected virtual void OnDoneEvent(DoneArgs e)
        {
            EventHandler<DoneArgs> raiseEvent = DoneEvent;

            if (raiseEvent != null)
            {
                raiseEvent(this, e);
            }
        }
    }
}

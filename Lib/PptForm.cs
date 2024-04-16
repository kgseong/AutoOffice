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
    internal class PptForm: DocFormBase
    {

        public PptForm (string formFilePth, string saveAsPath):base(formFilePth, saveAsPath)
        {
          
        }
        public override bool FillData(Dictionary<string, string> values)
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
                foreach (var replacement in replacements.Where(replacement => text.Text.Contains(GetFieldName( replacement.Key ))))
                {
                    text.Text = text.Text.Replace(GetFieldName(replacement.Key), replacement.Value);
                }
            }
        }

    
    }
}

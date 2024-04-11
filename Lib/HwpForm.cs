
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.IO.Compression;

namespace AutoOffice
{
    internal class HwpForm: IDocForm
    {

        public event EventHandler<DoneArgs> DoneEvent;
        public string FormFilePath { get; set; }
        public string SaveAsPath { get; set; }

        public HwpForm(string formFilePth, string saveAsPath)
        {
            FormFilePath = formFilePth;
            SaveAsPath = saveAsPath;
        }
        public bool FillData(Dictionary<string, string> values)
        {
            System.IO.File.Copy(FormFilePath, SaveAsPath);

            using (FileStream zipFile = File.Open(SaveAsPath, FileMode.Open))
            {

                using (System.IO.Compression.ZipArchive archive = new System.IO.Compression.ZipArchive(zipFile, ZipArchiveMode.Update))
                {
                    // ZIP 아카이브의 각 항목에 액세스
                    for (int i = 0; i < archive.Entries.Count; i++)
                    {
                        var fname = archive.Entries[i].FullName;
                        //컨텐츠가 있는 파일 수정
                        if (Path.GetFileName(fname).StartsWith("section"))
                        {
                            string content = "";
                            
                            using (System.IO.StreamReader sr = new StreamReader(archive.Entries[i].Open()))
                            {
                                content = sr.ReadToEnd();
                            }

                            foreach (var key in values.Keys)
                            {
                                var _key = DocFormHelper.GetFieldName(key);
                                content = content.Replace(_key, values[key]);
                            }
                            
                            using (System.IO.StreamWriter sw = new StreamWriter(archive.Entries[i].Open()))
                            {
                                sw.Write(content);
                                sw.Flush();
                            }
                        }
                    }
                }
            }
            OnDoneEvent(new DoneArgs(FormFilePath, true, SaveAsPath));
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
    }
}

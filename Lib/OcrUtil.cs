using DocumentFormat.OpenXml.Vml;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace AutoOffice
{
    internal class OcrUtil
    {
        public event EventHandler<DoneArgs> DoneEvent;
        public static string OcrDataDir = "./tessdata";
        public static string[] _Langs;
        public static string[] Langs
        {
            get
            {
                if (_Langs == null)
                {
                    var files = System.IO.Directory.GetFiles(OcrDataDir);
                    HashSet<string> list = new HashSet<string>();
                    foreach(var f in files)
                    {
                        var fname = System.IO.Path.GetFileNameWithoutExtension(f);
                        list.Add(fname.Split('.')[0]);
                    }
                    _Langs = list.ToArray();
                }
                return _Langs;
            }
        }

        public string ImagePath { get; set; }
        public string Lang { get; set; }
        
        public string ReadText(string lang)
        {
            //ImagePath = img_path;
            Lang = lang;
            string result = "";
            //using (TesseractEngine tesseractEngine = new TesseractEngine(szStartUpPath, "kor", EngineMode.Default))
            using (TesseractEngine ocr = new TesseractEngine(OcrDataDir, lang, EngineMode.Default))
            {
                using (Pix pix = Pix.LoadFromFile(ImagePath))
                {
                    var texts = ocr.Process(pix);
                    result = texts.GetText();
                    
                    OnDoneEvent(new DoneArgs(ImagePath, true, lang));
                }
            }
            return result;
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

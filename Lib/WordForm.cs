using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Diagnostics;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.CustomProperties;
using DocumentFormat.OpenXml.Office2010.Word;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.VariantTypes;
using DocumentFormat.OpenXml.Wordprocessing;


namespace AutoOffice
{
    internal class WordForm: IDocForm
    {

        public event EventHandler<DoneArgs> DoneEvent;
        public string FormFilePath { get; set; }
        public string SaveAsPath { get; set; }
        List<Tuple<string, int, int, int, int>> exField { get; set; }
        public WordForm(string formFilePth, string saveAsPath)
        {
            FormFilePath = formFilePth;
            SaveAsPath = saveAsPath;
        }
        public bool FillData(Dictionary<string, string> values)
        {
            System.IO.File.Copy(FormFilePath, SaveAsPath);


            using (WordprocessingDocument doc = WordprocessingDocument.Open(SaveAsPath, true))
            {

                var body = doc.MainDocumentPart.Document.Body;
                var texts = body.Descendants<Text>().ToList();
                for(int i=0; i<texts.Count(); i++) 
                {
                    var text = texts[i];
                    foreach (var key in values.Keys)
                    {
                        var _key = DocFormHelper.GetFieldName(key);
                        if (text.Text.Contains(_key))
                        {
                            text.Text = text.Text.Replace(_key, values[key]);
                        }
                    }
                }
                if (exField == null)
                {
                    exField = FindField(texts);
                }
                //var flds = FindField(texts);
                foreach(var fld in exField)
                {
                    foreach (var key in values.Keys)
                    {
                        var _key = DocFormHelper.GetFieldName(key);
                        if (fld.Item1.Contains(_key))
                        {
                            string text = texts[fld.Item2].Text;
                            if (fld.Item3 == 0)
                            {
                                texts[fld.Item2].Text = values[key];
                            }else
                            {
                                texts[fld.Item2].Text = text.Substring(0, fld.Item3) + values[key];
                            }
                            
                            for(int idx=fld.Item2+1; idx<=fld.Item4; idx++)
                            {
                                if (idx == fld.Item4)
                                {
                                    texts[idx].Text = texts[idx].Text.Substring(fld.Item5+1);
                                }else
                                {
                                    texts[idx].Text = "";
                                }
                            }
                        }
                    }
                }
                doc.Save();
                doc.Close();
                OnDoneEvent(new DoneArgs(FormFilePath, true, SaveAsPath));
            }
        
            return true;
        }

        private List<Tuple<string, int, int, int, int>> FindField(List<Text> texts)
        {

            List<Tuple<string, int, int, int, int>> items = new List<Tuple<string, int, int, int, int>>();
            int idx_s = -1, idx_sp = -1, idx_e = -1, idx_ep = -1;
            int fldmark_cnt = 0;
            string _fld = "";
            for (int i = 0; i < texts.Count(); i++)
            {
                var text = texts[i];
               
                    string _txt = text.Text;
                    Debug.Print("{0} : {1}", i, _txt);
                    if (_txt.Contains("#") == true)
                    {
                        fldmark_cnt += 1;
                        //필드시작
                        if (fldmark_cnt % 2 == 1)
                        {
                            if (_txt.IndexOf('#') == _txt.LastIndexOf('#')) {
                                _fld = _txt;
                                idx_s = i;
                                idx_sp = _txt.IndexOf('#');
                                Debug.Print("s : {0} / {1} / {2} / {3} / {4}", _fld, idx_s, idx_sp, idx_e, idx_ep);
                            }
                            else
                            {
                                //리셋
                                
                                idx_s = -1; idx_sp = -1; idx_e = -1; idx_ep = -1;
                                fldmark_cnt = 0;
                                _fld = "";
                            }
                        }else //필드종료
                        {
                            _fld += _txt;
                            idx_e = i;
                            idx_ep = _txt.IndexOf('#');

                            //필드발견
                            items.Add(new Tuple<string, int, int, int, int>(_fld, idx_s, idx_sp, idx_e, idx_ep));
                            Debug.Print("e : {0} / {1} / {2} / {3} / {4}", _fld, idx_s, idx_sp, idx_e, idx_ep);
                            //리셋
                            
                            idx_s = -1; idx_sp = -1; idx_e = -1; idx_ep = -1;
                            fldmark_cnt = 0;
                            _fld = "";
                        }
                    }else
                    {
                        if (fldmark_cnt > 0)
                        {
                            _fld += _txt;
                        }else
                        {
                            _fld = "";
                        }
                            
                    }
  
            }
              
            return items;

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

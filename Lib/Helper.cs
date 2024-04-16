﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Drawing.Diagrams;


namespace AutoOffice
{

    public static class Helper
    {
        public static string Filter_Office = "문서파일|*.xls;*.xlsx;*.doc;*.docx;*.ppt;*.pptx";
        public static string Filter_Excel = "엑셀파일|*.xls;*.xlsx";
        public static string Filter_Word = "워드파일|*.doc;*.docx";
        public static string Filter_Ppt = "파워포인트파일|*.ppt;*.pptx";
        public static string Filter_Pdf = "PDF파일|*.pdf";
        public static string Filter_Hwp = "한글파일|*.hwpx";
        public static string Filter_All = "오피스파일|*.xls;*.xlsx;*.doc;*.docx;*.ppt;*.pptx;*.pdf;*.hwpx";

     
        public static DocType GetDocType(string filename)
        {
            string ext = System.IO.Path.GetExtension(filename).ToLower();
            DocType doc = DocType.None;
            if (ext.StartsWith(".xls"))
            {
                doc = DocType.Xls;
            }
            else if (ext.StartsWith(".ppt"))
            {
                doc = DocType.Ppt;
            }
            else if (ext.StartsWith(".doc"))
            {
                doc = DocType.Word;
            }else if (ext.StartsWith(".pdf"))
            {
                doc = DocType.Pdf;
            }
            else if (ext.StartsWith(".hwpx"))
            {
                doc = DocType.Hwp;
            }

            return doc;
        }

        public static  bool RawPrint(string src_path)
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
        public static void OpenDoc(string src_path)
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
        }

        public static string[] GetValidDocList(string[] files, DocType[] doctyps)
        {
            var items = from item in files
                        where doctyps.Contains(GetDocType(item)) == true
                        select item;
            return items.ToArray();
        }
        public static void ListViewItemUpDown (System.Windows.Forms.ListView listview, int updown)
        {
            //up = -1, down = 1
            int direction = updown;

            Dictionary<ListViewItem, int> sel_items = new Dictionary<ListViewItem, int>();
            foreach(ListViewItem item in listview.SelectedItems)
            {
                sel_items.Add(item, item.Index);
            }

            //case up
            if (updown == -1)
            {
                foreach(var item in sel_items.Keys)
                {
                    if (sel_items[item] > 0)
                    {
                        listview.Items.Remove(item);
                        listview.Items.Insert(sel_items[item] - 1, item);
                    }
                }
            }else if (updown == 1)
            {
                foreach (var item in sel_items.Keys)
                {
                    if (sel_items[item]+1 < listview.Items.Count)
                    {
                        listview.Items.Remove(item);
                        listview.Items.Insert(sel_items[item]+1 , item);
                    }
                }
            }
         
        }
        public static void ListViewItemAdd(System.Windows.Forms.ListView listview, string[] items)
        {
            foreach(var item in items)
            {
                bool is_exist = false;
                foreach(ListViewItem lvi in listview.Items)
                {
                    if (lvi.Text == item)
                    {
                        is_exist = true;
                        continue;
                    }
                }
                if (is_exist == false)
                {
                    var new_item = listview.Items.Add(item);
                    new_item.Checked = true;
                }
            }
            
        }


    }
}
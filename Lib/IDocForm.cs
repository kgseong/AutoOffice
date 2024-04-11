using DocumentFormat.OpenXml.Office2016.Drawing.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoOffice
{
    public interface IDocForm
    {
        event EventHandler<DoneArgs> DoneEvent;
        //string FilePath { get; set; }
        //bool SetField(string name, string value);
        string FormFilePath { get; set; }
        string SaveAsPath { get; set; }
        bool FillData(Dictionary<string, string> values );
        //bool LoadForm(string FormFilePath);
        //bool Save(string FilePath);
        //void ResetForm();
        //void UnLoadForm();
        //void Print();
    }
}

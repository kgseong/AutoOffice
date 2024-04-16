using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoOffice
{
    /// <summary>
    /// Event Args for job is done
    /// </summary>
    public class DoneArgs : EventArgs
    {
        public string FileName { get; set; }
        public bool isOK { get; set; }
        public string ToFileName { get; set; }
        public string Message { get; set; }
        public DoneArgs(string src, bool ok, string dst=null, string msg = null)
        {
            FileName = src;
            isOK = ok;
            ToFileName = dst;
            Message = msg;
        }
    }
}

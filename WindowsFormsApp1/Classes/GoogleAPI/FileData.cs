using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reactor_Interface.Classes.GoogleAPI
{
    public class FileData
    {
        public string Name { get; }
        public string ID { get; }
        public string MimeType { get; }

        public FileData(string name, string iD, string mimeType)
        {
            Name = name;
            ID = iD;
            this.MimeType = mimeType;
        }
    }
}

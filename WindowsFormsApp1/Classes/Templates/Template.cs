using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace Reactor_Interface.Classes.Templates
{
    public class Template
    {
        public string Name { get; }
        public Dictionary<string, List<List<Pair>>> Pages { get; }
        public Template(string name, Dictionary<string, List<List<Pair>>> pages) 
        {
            Pages = pages;
            Name = name;
        }
    }
}

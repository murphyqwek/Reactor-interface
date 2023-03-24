using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reactor_Interface.Classes.Templates
{
    public class Template
    {
        public string Name { get; }

        public Dictionary<string, List<List<string>>> Pages { get; }
        public Template(string name, Dictionary<string, List<List<string>>> pages) 
        {
            Pages = pages;
            Name = name;
        }
    }
}

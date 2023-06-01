using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reactor_Interface.Classes.Exceptions
{
    public class SameFieldsNamesException : Exception
    {
        public SameFieldsNamesException() : 
            base("Два или более полей имеют одинаковые названия"){ 
        }
    }
}

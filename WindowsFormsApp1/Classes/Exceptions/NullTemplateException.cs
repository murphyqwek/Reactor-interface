using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reactor_Interface.Classes.Exceptions
{
    public class NullTemplateException : Exception 
    { 
        public NullTemplateException() : base("Шаблона серии не существует") { }
    }
}

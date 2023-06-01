using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reactor_Interface.Classes.Exceptions
{
    public class TemplateDoesNotExistExcpetion : Exception
    {
        public TemplateDoesNotExistExcpetion(string templatePath) 
            : base("Данный шаблон не сущетсвует по пути " + templatePath){ }
    }
}

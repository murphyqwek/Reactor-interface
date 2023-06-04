using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reactor_Interface.Classes.Exceptions
{
    public class ExperimentIsNotCapableWithTemplateExcpetion : Exception
    {
        public ExperimentIsNotCapableWithTemplateExcpetion() : base("Эксперимент не соответсвует шаблону") { }
    }
}

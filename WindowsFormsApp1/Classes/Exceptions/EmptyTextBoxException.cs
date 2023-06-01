using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reactor_Interface.Classes.Exceptions
{
    public class EmptyTextBoxException : Exception
    {
        public EmptyTextBoxException()
        : base("Одно или несколько полей были не заполнены") { }
    }
}

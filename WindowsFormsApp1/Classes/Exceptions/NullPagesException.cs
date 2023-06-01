using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reactor_Interface.Classes.Exceptions
{
    public class NullPagesException : Exception
    {
        public NullPagesException()
        : base("Все страницы пусты") { }
    }
}

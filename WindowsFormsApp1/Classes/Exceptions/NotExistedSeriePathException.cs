using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reactor_Interface.Classes.Exceptions
{
    public class NotExistedSeriePathException : Exception
    {
        public NotExistedSeriePathException(string seriePath)
        : base("По пути: " + seriePath + " файла серии не существует"){ }
    }
}

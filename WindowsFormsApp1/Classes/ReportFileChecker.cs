using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reactor_Interface.Classes
{
    public class ReportFileChecker
    {
        static public bool IsReportOpen(string filePath)
        {
            if (!File.Exists(filePath))
                return false;

            StreamReader reader;
            try
            {
                reader = new StreamReader(filePath);
                reader.Close();
                return false;
            }
            catch (IOException)
            {
                return true;
            }
        }
    }
}

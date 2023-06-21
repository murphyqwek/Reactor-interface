using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reactor_Interface.Classes.Experiment;
using Reactor_Interface.Classes.Templates;

namespace Reactor_Interface.Classes.XRD
{
    public static class XRDParser
    {
        public static List<GraphPoint> ParseXRDToGraphPoints(string RXDFilePath)
        {
            List<GraphPoint> xrdPoints = new List<GraphPoint>();

            Regex reg = new Regex("([\\d\\.]+)\\s+(\\S+)");

            string[] lines;

            double maxVal = 0;

            lines = File.ReadAllText(RXDFilePath).Split('\n');

            if (lines.Length < 31)
                return null;

            for(int i = 31; i < lines.Length; i++)
            {
                var matches = reg.Matches(lines[i]);
                if(matches.Count > 0)
                { 
                    double matchValue = Convert.ToDouble(matches[0].Groups[2].Value);
                    maxVal = Math.Max(matchValue, maxVal);
                }
            }

            for(int i = 31; i < lines.Length; i++)
            {
                var matches = reg.Matches(lines[i]);
                if (matches.Count > 0)
                {
                    //string[] splittedMatch = matches[0].Value.Split();

                    double XValue = Convert.ToDouble(matches[0].Groups[1].Value.Replace('.', ','));
                    double YValue = Convert.ToDouble(matches[0].Groups[2].Value);

                    xrdPoints.Add(new GraphPoint(XValue, YValue));
                }
            }

            return xrdPoints;
        }

        public static string GetXRDFilePath()
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Выберите файл рентгена";
                dlg.Filter = "Файл Ренгтена (*.txt)|*.txt|All files (*.*)|*.*";
                dlg.Multiselect = false;

                dlg.ShowDialog();
                if (string.IsNullOrEmpty(dlg.FileName))
                    return null;

                return dlg.FileName;
            }
        }

    }
}
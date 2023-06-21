using Reactor_Interface.Classes.Experiment;
using Reactor_Interface.Classes.GoogleAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using System.Globalization;

namespace Reactor_Interface.Classes.Oscillograph
{
    public class OscillographParser
    {
        public static List<List<GraphPoint>> ParseOscillographToGraphPoints(string filepath)
        {
            List<List<GraphPoint>> Series = new List<List<GraphPoint>>();

            List<GraphPoint> Serie1 = new List<GraphPoint>(),
                             Serie2 = new List<GraphPoint>();

            string value;
            string[] splittedValue;

            using (TextReader fileReader = File.OpenText(filepath))
            {
                fileReader.ReadLine();
                fileReader.ReadLine();

                while ((value = fileReader.ReadLine()) != null)
                {
                    splittedValue = value.Split(',');

                    double time = double.Parse(splittedValue[0], CultureInfo.InvariantCulture);
                    double V2 = double.Parse(splittedValue[1], CultureInfo.InvariantCulture);
                    double V3 = double.Parse(splittedValue[2], CultureInfo.InvariantCulture);

                    Serie1.Add(new GraphPoint(time, V2));
                    Serie2.Add(new GraphPoint(time, V3));
                }
            }

            Series.Add(Serie1);
            Series.Add(Serie2);

            return Series;
        }

        public static string GetOSCPicPath()
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Выберите файл картинки осциллографа";
                dlg.Filter = "Файл Картиники Осциллограф (*.bmp)|*.bmp";
                dlg.Multiselect = false;

                dlg.ShowDialog();
                if (string.IsNullOrEmpty(dlg.FileName))
                    return null;

                return dlg.FileName;
            }
        }

        public static string GetOSCFilePath()
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Выберите файл осциллографа";
                dlg.Filter = "Файл Осциллографа (*.csv)|*.csv";
                dlg.Multiselect = false;

                dlg.ShowDialog();
                if (string.IsNullOrEmpty(dlg.FileName))
                    return null;

                return dlg.FileName;
            }
        }

    }
}
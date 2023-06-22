using Reactor_Interface.Classes.Experiment;
using Reactor_Interface.Classes.GoogleAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Reactor_Interface.Classes.Oscillograph
{
    public class OscillographParser
    {
        const double tokConst = 0.0047;

        public static List<List<GraphPoint>> ParseOscillographToGraphPoints(string filepath)
        {
            List<List<GraphPoint>> Series = new List<List<GraphPoint>>();

            List<GraphPoint> VoltSerie = new List<GraphPoint>(),
                             TokSerie = new List<GraphPoint>(),
                             PSerie = new List<GraphPoint>();

            string value;
            string[] splittedValue;


            using (TextReader fileReader = File.OpenText(filepath))
            {
                fileReader.ReadLine();
                fileReader.ReadLine();

                double koef = getKoef(VoltSerie, TokSerie, PSerie, fileReader);

                while ((value = fileReader.ReadLine()) != null)
                {
                    splittedValue = value.Split(',');

                    double time = double.Parse(splittedValue[0], CultureInfo.InvariantCulture);
                    double U = double.Parse(splittedValue[1], CultureInfo.InvariantCulture);
                    double I = double.Parse(splittedValue[2], CultureInfo.InvariantCulture);

                    U = CountU(U);
                    I = CountI(I, koef);
                    double P = CountP(I, U);

                    VoltSerie.Add(new GraphPoint(time, U));
                    TokSerie.Add(new GraphPoint(time, I));
                    PSerie.Add(new GraphPoint(time, P));
                }
            }

            Series.Add(VoltSerie);
            Series.Add(TokSerie);
            Series.Add(PSerie);

            return Series;
        }

        private static double CountU(double u) => u * 10;

        private static double CountI(double i, double koef) => (i - koef) / tokConst;

        private static double CountP(double i, double u) => i * u / 1000;

        private static double getKoef(List<GraphPoint> voltSerie, List<GraphPoint> tokSerie, List<GraphPoint> pSerie, TextReader fileReader)
        {
            List<double> _time = new List<double>(), _tok = new List<double>(), _volt = new List<double>();

            string value;

            double tokSum = 0, countTok = 0;

            while ((value = fileReader.ReadLine()) != null)
            {
                var splittedValue = value.Split(',');

                double time = double.Parse(splittedValue[0], CultureInfo.InvariantCulture);
                double U = double.Parse(splittedValue[1], CultureInfo.InvariantCulture);
                double I = double.Parse(splittedValue[2], CultureInfo.InvariantCulture);

                if (time > -0.5)
                    break;

                U = CountU(U);

                tokSum += I;
                countTok++;

                voltSerie.Add(new GraphPoint(time, U));
                _time.Add(time);
                _tok.Add(I);
                _volt.Add(U);
            }

            double koef = tokSum / countTok;

            for(int i = 0; i < _time.Count; i++)
            {
                double I = CountI(_tok[i], koef);
                double P = CountP(I, _volt[i]);

                tokSerie.Add(new GraphPoint(_time[i], I));
                pSerie.Add(new GraphPoint(_time[i], P));
            }

            return koef;
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
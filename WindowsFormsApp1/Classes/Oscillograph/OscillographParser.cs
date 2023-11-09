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
using Reactor_Interface.Classes.XRD;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;

namespace Reactor_Interface.Classes.Oscillograph
{
    public class OscillographParser
    {
        const double tokConst = 0.0047;

        public delegate List<GraphPoint> FilterMethod(List<GraphPoint> points, int order);

        const double ConvertToMEGA = 0.000036;

        public static List<GraphPoint> CountKVtHSerie(List<GraphPoint> VoltSerie, List<GraphPoint> TokSerie)
        {
            List<GraphPoint> kVtHSerie = new List<GraphPoint>
            {
                new GraphPoint(VoltSerie[0].X, 0)
            };
            for (int i = 1; i < VoltSerie.Count; i++)
            {
                double kVtHValue = CountkVtH(VoltSerie[i].Y, TokSerie[i].Y, VoltSerie[i].X - VoltSerie[i - 1].X) + kVtHSerie[i - 1].Y;
                kVtHSerie.Add(new GraphPoint(VoltSerie[i].X, kVtHValue));
            }

            return kVtHSerie;
        }

        public static List<List<GraphPoint>> ParseOscillographToGraphPoints(string filepath, bool isFiltred)
        {
            List<List<GraphPoint>> Series = new List<List<GraphPoint>>();

            List<GraphPoint> VoltSerie = new List<GraphPoint>(),
                             TokSerie = new List<GraphPoint>(),
                             PSerie = new List<GraphPoint>(),
                             kVtHSerie = new List<GraphPoint>();

            List<double> Time = new List<double>();

            string value;
            string[] splittedValue;


            using (TextReader fileReader = File.OpenText(filepath))
            {
                fileReader.ReadLine();
                fileReader.ReadLine();

                double koef = getKoef(VoltSerie, TokSerie, Time, fileReader);

                while ((value = fileReader.ReadLine()) != null)
                {
                    splittedValue = value.Split(',');

                    double time = double.Parse(splittedValue[0], CultureInfo.InvariantCulture);
                    double U = double.Parse(splittedValue[1], CultureInfo.InvariantCulture);
                    double I = double.Parse(splittedValue[2], CultureInfo.InvariantCulture);

                    U = CountU(U);
                    I = CountI(I, koef);
                    //double P = CountP(I, U);

                    VoltSerie.Add(new GraphPoint(time, U));
                    TokSerie.Add(new GraphPoint(time, I));
                    Time.Add(time);
                }
            }

            if (isFiltred)
            {
                VoltSerie = SavitzkyGolayFilter.Filter(VoltSerie, 15, 3);
                TokSerie = SmoothTokSerie(TokSerie, 3, 8);
            }

            kVtHSerie = CountKVtHSerie(VoltSerie, TokSerie);
            PSerie = CountPSerie(VoltSerie, TokSerie);

            Series.Add(VoltSerie);
            Series.Add(TokSerie);
            Series.Add(PSerie);
            Series.Add(kVtHSerie);

            return Series;
        }

        private static List<GraphPoint> CountPSerie(List<GraphPoint> VoltSerie, List<GraphPoint> TokSerie)
        {
            List<GraphPoint> PSerie = new List<GraphPoint>();

            for (int i = 0; i < VoltSerie.Count; i++)
            {
                PSerie.Add(new GraphPoint(VoltSerie[i].X, CountP(TokSerie[i].Y, VoltSerie[i].Y)));
            }

            return PSerie;
        }

        private static List<GraphPoint> SmoothTokSerie(List<GraphPoint> TokSerie, int order, int windowSize)
        {
            List<GraphPoint> SmoothedTokSeire = SavitzkyGolayFilter.Filter(TokSerie, windowSize, order);
            List<GraphPoint> smoothedTok = new List<GraphPoint>();
            List<GraphPoint> tok = new List<GraphPoint>();
            List<GraphPoint> tok1 = new List<GraphPoint>();
            bool isPeakPlato = false;

            for (int i = 0; i < SmoothedTokSeire.Count; i++)
            {
                if (!isPeakPlato && smoothedTok.Count == 0)
                {
                    if (SmoothedTokSeire[i].Y <= -20)
                        tok.Add(new GraphPoint(SmoothedTokSeire[i].X, -20));
                    else
                        tok.Add(TokSerie[i]);
                }
                if (!isPeakPlato && smoothedTok.Count > 0)
                {
                    if (SmoothedTokSeire[i].Y <= -20)
                        tok1.Add(new GraphPoint(SmoothedTokSeire[i].X, -20));
                    else
                        tok1.Add(TokSerie[i]);
                }

                if (isPeakPlato)
                    smoothedTok.Add(TokSerie[i]);

                if (SmoothedTokSeire[i].Y > 50 && !isPeakPlato)
                {
                    isPeakPlato = true;
                    continue;
                }

                if (SmoothedTokSeire[i].Y < 10 && isPeakPlato)
                {
                    isPeakPlato = false;
                    smoothedTok = SavitzkyGolayFilter.Filter(smoothedTok, windowSize, order);
                }
            }

            List<GraphPoint> points = new List<GraphPoint>();
            for (int i = 0; i < tok.Count; i++)
                points.Add(tok[i]);
            for (int i = 0; i < smoothedTok.Count; i++)
                points.Add(smoothedTok[i]);
            for (int i = 0; i < tok1.Count; i++)
                points.Add(tok1[i]);
            return points;
        }

        public static List<List<GraphPoint>> SmoothOscillograph(List<GraphPoint> VoltSerie, List<GraphPoint> TokSerie, int windowSizeTok, int orderTok, int windowSzieVolt, int orderVolt)
        {
            TokSerie = SavitzkyGolayFilter.Filter(TokSerie, windowSizeTok, orderTok);//SmoothTokSerie(TokSerie, orderTok, windowSizeTok);//
            VoltSerie = SavitzkyGolayFilter.Filter(VoltSerie, windowSzieVolt, orderVolt);
            List<GraphPoint> PSerie = CountPSerie(VoltSerie, TokSerie);
            List<GraphPoint> kVtHSerie = CountKVtHSerie(VoltSerie, TokSerie);

            return new List<List<GraphPoint>> { VoltSerie, TokSerie, PSerie, kVtHSerie };
        }

        private static double CountU(double u) => u * 10;

        private static double CountkVtH(double u, double i, double DeltaTime) => u * i * DeltaTime / 3600000;

        private static double CountI(double i, double koef) => (i - koef) / tokConst;

        private static double CountP(double i, double u) => i * u / 1000;

        private static double getKoef(List<GraphPoint> voltSerie, List<GraphPoint> tokSerie, List<double> Time, TextReader fileReader)
        {
            List<double> _tok = new List<double>(), _volt = new List<double>();

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
                _tok.Add(I);
                _volt.Add(U);
                Time.Add(time);
            }

            double koef = tokSum / countTok;

            for(int i = 0; i < Time.Count; i++)
            {
                double I = CountI(_tok[i], koef);
                //double P = CountP(I, _volt[i]);

                tokSerie.Add(new GraphPoint(Time[i], I));
                //pSerie.Add(new GraphPoint(_time[i], P));
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
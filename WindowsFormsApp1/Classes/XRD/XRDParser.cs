using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Reactor_Interface.Classes.Experiment;
using Reactor_Interface.Classes.Templates;

namespace Reactor_Interface.Classes.XRD
{
    public static class XRDParser
    {
        /*Рекомендуемые параметры:
         * windowSize = 35
         * order = 3
         * minHeightDrop = 5
         * minDepthDrop = -5
         * smoothFactor(Gaussian) = 6
         */

        struct xrdDiffPonit
        {
            public double x;
            public double y;
            public int index;
        }

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

                    double XValue = Convert.ToDouble(matches[0].Groups[1].Value.Replace('.', ','));
                    double YValue = Convert.ToDouble(matches[0].Groups[2].Value);

                    xrdPoints.Add(new GraphPoint(XValue, YValue));
                }
            }
            return xrdPoints;
        }

        private static double CountMiddleValue(List<GraphPoint> xrdPoints, int index)
        {
            const int countToMiddle = 10;
            int lastIndex = index + countToMiddle;
            double result = 0;
            int count = 0;
            for (; index < lastIndex && index < xrdPoints.Count - 1; index++) {
                result += xrdPoints[index].Y;
                count++;
            }

            return result / count;
        }

        /*
        public static List<GraphPoint> Scale(List<GraphPoint> xrdPoints)
        {
            List<GraphPoint> smoothedXRD = new List<GraphPoint>();

            for (int i = 1; i < xrdPoints.Count; i += 2)
            {
                smoothedXRD.Add(new GraphPoint(
                    (xrdPoints[i].X + xrdPoints[i - 1].X) / 2,
                    (xrdPoints[i].Y + xrdPoints[i - 1].Y) / 2
                    ));
            }

            return smoothedXRD;
        }

        public static List<GraphPoint> ScaleNTimes(List<GraphPoint> xrdPoints, int n)
        {
            List<GraphPoint> smoothedXRD = Scale(xrdPoints);

            for (int i = 0; i < n - 1; i++)
                smoothedXRD = Scale(smoothedXRD);

            return smoothedXRD;
        }
        */

        static double[] SimpleMovingAvarage(double[] yCoorde, int n)
        {
            double[] graphPoints = new double[yCoorde.Length];
            for(int i = n; i < yCoorde.Length; i++)
            {
                double value = 0;
                for(int j = 0; j < n; j++)
                    value += yCoorde[i - j];

                value /= n;

                graphPoints[i] = value;
            }
            return graphPoints;
        }

        private static List<xrdDiffPonit> GetDropCoords(double[] yCoords, double[] xCoords, int windowSize, int order, int minDropHeight, int minDropDepth, Chart chart = null, bool isGaussian = false)
        {
            if(isGaussian)
            {
                yCoords = GaussianBlur.Apply(yCoords, 6);
                for (int i = 0; i < yCoords.Length && chart != null; i++)
                {
                    //chart.Series["XRD Smooth"].Points.AddXY(xCoords[i], yCoords[i]);
                }
                //chart.Series["XRDSmooth"]
                return ParseGaussian(yCoords, xCoords);
            }

            yCoords = SavitzkyGolayFilter.Filter(yCoords, windowSize, order);
            for (int i = 0; i < yCoords.Length && chart != null; i++)
            {
                //chart.Series["XRD Smooth"].Points.AddXY(xCoords[i], yCoords[i]);
            }

            double[] diffYCoords = new double[yCoords.Length];
            diffYCoords[0] = 0;
            for (int i = 1; i < yCoords.Length; i++)
            {
                diffYCoords[i] = (yCoords[i] - yCoords[i - 1]) * 10;
            }

            diffYCoords = SavitzkyGolayFilter.Filter(diffYCoords, windowSize, order);

            for (int i = 0; i < diffYCoords.Length && chart != null; i++)
            {
                //chart.Series["XRD Smooth"].Points.AddXY(xCoords[i], diffYCoords[i]);
            }

            List<xrdDiffPonit> xrdDiffs = new List<xrdDiffPonit>();

            for (int i = 1; i < diffYCoords.Length; i++)
            {
                if (diffYCoords[i] < minDropHeight)
                    continue;

                int maxIndex = FindMaxIndex(i, diffYCoords);
                int minIndex = FinMinIndex(maxIndex, diffYCoords);
                if (diffYCoords[minIndex] > minDropDepth)
                    continue;

                xrdDiffs.Add(new xrdDiffPonit { x = xCoords[maxIndex], y = diffYCoords[maxIndex], index = maxIndex });
                xrdDiffs.Add(new xrdDiffPonit { x = xCoords[minIndex], y = diffYCoords[minIndex], index = minIndex });
                i = minIndex;
            }
            return xrdDiffs;
        }

        private static List<xrdDiffPonit> ParseGaussian(double[] yCoords, double[] xCoords)
        {
            List<xrdDiffPonit> peaks = new List<xrdDiffPonit>();
            string peaksString = "";
            for(int i = 1; i < yCoords.Length; i++)
            {
                peaksString += yCoords[i] - yCoords[i - 1] >= 0 ? 'u' : 'd';
            }

            bool peakStart = false;
            bool CountingD = false;
            for(int i = 0; i < peaksString.Length; i++)
            {
                if (peaksString[i] == 'u' && !peakStart)
                {
                    if (CountingD)
                    {
                        int pointI = i - 1;
                        peaks.Add(new xrdDiffPonit { x = xCoords[pointI], y = yCoords[pointI], index = pointI});
                    }
                    peaks.Add(new xrdDiffPonit { x = xCoords[i], y = yCoords[i], index = i });
                    peakStart = true;
                }

                if (peaksString[i] == 'd' && peakStart)
                {
                    CountingD = true;
                    //peaks.Add(new xrdDiffPonit { x = xCoords[i], y = yCoords[i], index = i + 4 });
                    peakStart = false;
                }
            }
            if(peaks.Count % 2 == 1)
            {
                int i = peaksString.Length;
                peaks.Add(new xrdDiffPonit { x = xCoords[i], y = yCoords[i], index = i });
            }
            return peaks;
        }

        private static void Concat(ref List<GraphPoint> list1, List<GraphPoint> list2)
        {
            foreach(var point in list2)
            {
                list1.Add(point);
            }
        }

        private static List<GraphPoint> GaussianPeaks(int startIndex, int finishIndex, List<GraphPoint> xrdPoints, Chart chart = null)
        {
            int size = finishIndex - startIndex;//xrdDiffs[i + 1].index - xrdDiffs[i].index;
            double[] yCheck = new double[size];
            double[] xCheck = new double[size];
            int originalArrayIndex = startIndex;//xrdDiffs[i].index;

            for (int j = 0; j < size; j++)
            {
                yCheck[j] = xrdPoints[originalArrayIndex].Y;
                xCheck[j] = xrdPoints[originalArrayIndex].X;
                originalArrayIndex++;
            }
            List<GraphPoint> output = new List<GraphPoint>();
            var diffPoints = GetDropCoords(yCheck, xCheck, 0, 0, 0, 0, chart, true);
            for(int i = 0; i < diffPoints.Count; i+=2)
            {
                output.Add(FindMaxPeak(diffPoints[i].index + startIndex, diffPoints[i + 1].index + startIndex, xrdPoints));
            }

            return output;
        }

        public static void SetPeaks(ref Chart chart, List<GraphPoint> xrdPoints, int windowSize, int order, int minDropHeight, int minDropDepth, int LocalWindowSize, int LocalOrder)
        {
            Console.WriteLine(string.Format("MinDropHeight = {0}, MinDropDepth = {1}", minDropHeight, minDropDepth));
            chart.Series["XRD Peaks"].Points.Clear();
            chart.Series["XRD Smooth"].Points.Clear();

            double[] x = new double[xrdPoints.Count];
            double[] y = new double[xrdPoints.Count];
            double[] diffArray = new double[xrdPoints.Count];
            for (int i = 0; i < xrdPoints.Count; i++)
            {
                x[i] = xrdPoints[i].X;
                y[i] = xrdPoints[i].Y;
            }

            //y = SavitzkyGolayFilter.Filter(y, 10, 3);
            List<xrdDiffPonit> extremumArray = GetDropCoords(y, x, windowSize, order, minDropHeight, minDropDepth, chart);

            y = SavitzkyGolayFilter.Filter(y, windowSize, order);
            diffArray[0] = 0;
            for (int i = 1; i < y.Length; i++)
            {
                diffArray[i] = (y[i] - y[i - 1]) * 10;
            }
            diffArray = SavitzkyGolayFilter.Filter(diffArray, windowSize, order);

            List<GraphPoint> peaks = new List<GraphPoint>();

            if (extremumArray.Count == 2)
            {
                FindMaxPeak(extremumArray[0].index, extremumArray[1].index, xrdPoints);
                return;
            }

            for (int i = 2; i < extremumArray.Count; i += 2)
            {
                List<GraphPoint> localPeaks = new List<GraphPoint>();
                int localMaximumIndex = extremumArray[i].index - 1;
                while (diffArray[localMaximumIndex] < diffArray[localMaximumIndex + 1] && localMaximumIndex > 0 && localMaximumIndex < diffArray.Length - 1)
                    localMaximumIndex--;

                int localMinimumIndex = extremumArray[i + 1].index + 1;
                while (diffArray[localMinimumIndex] > diffArray[localMinimumIndex - 1] && localMinimumIndex > 0 && localMinimumIndex < diffArray.Length - 1)
                    localMinimumIndex++;

                localMinimumIndex--;
                localMaximumIndex++;
                
                if (localMaximumIndex == extremumArray[i - 1].index)
                {
                    if (i == extremumArray.Count - 2)
                    {
                        Concat(ref localPeaks, GaussianPeaks(extremumArray[i - 2].index, extremumArray[i + 1].index, xrdPoints, chart));
                    }
                    else if (i < extremumArray.Count && localMinimumIndex == extremumArray[i + 2].index)
                    {
                        Concat(ref localPeaks, GaussianPeaks(extremumArray[i - 2].index, extremumArray[i + 3].index, xrdPoints, chart));
                        //Concat(ref localPeaks, MergeNearPeaks(xrdDiffs[i].index, xrdDiffs[i + 3].index, xrdPoints, windowSize, order, minDropHeight, minDropDepth, chart));
                    }
                    else if (i < extremumArray.Count && localMinimumIndex != extremumArray[i + 2].index)
                    {
                        Concat(ref localPeaks, GaussianPeaks(extremumArray[i - 2].index, extremumArray[i + 1].index, xrdPoints, chart));
                        localPeaks.Add(FindMaxPeak(extremumArray[i + 2].index, extremumArray[i + 3].index, xrdPoints));
                    }
                }
                else
                {

                    if (peaks.Count == 0)
                    {
                        var k = FindMaxPeak(extremumArray[i - 2].index, extremumArray[i - 1].index, xrdPoints);
                        localPeaks.Add(k);
                    }
                    /*
                    else if (peaks[peaks.Count - 1].X == k.X && peaks[peaks.Count - 1].Y == k.Y)
                        localPeaks.Add(k);*/

                    if (i == extremumArray.Count - 2)
                    {
                        localPeaks.Add(FindMaxPeak(extremumArray[i].index, extremumArray[i + 1].index, xrdPoints));
                    }
                    else
                    {
                        if (localMinimumIndex == extremumArray[i + 2].index)
                        {
                            Concat(ref localPeaks, GaussianPeaks(extremumArray[i].index, extremumArray[i + 3].index, xrdPoints, chart));
                        }
                        else
                        {
                            localPeaks.Add(FindMaxPeak(extremumArray[i].index, extremumArray[i + 1].index, xrdPoints));
                            localPeaks.Add(FindMaxPeak(extremumArray[i + 2].index, extremumArray[i + 3].index, xrdPoints));
                        }
                    }
                }
                bool phatnomIndex = false;
                int LastIndex = peaks.Count - 1;

                if (LastIndex > 0)
                {
                    for (int j = 0; j < localPeaks.Count; j++)
                    {
                        if (localPeaks[j].X == peaks[LastIndex].X && localPeaks[j].Y == peaks[j].Y)
                        {
                            phatnomIndex = true;
                        }
                    }
                    if (!phatnomIndex)
                    {
                        peaks.RemoveAt(LastIndex);
                    }
                }
                Concat(ref peaks, localPeaks);
            }

            foreach(var point in peaks)
            {
                chart.Series["XRD Peaks"].Points.AddXY(point.X, point.Y);
            }

            //Console.WriteLine(chart.Series["XRD Peaks"].Points.Count);
        }

        private static GraphPoint FindMaxPeak(int start, int finish, List<GraphPoint> xrdPoints)
        {
            double max_y = Double.MinValue;
            double max_x = 0;

            for (; start < finish; start++)
            {
                if (xrdPoints[start].Y > max_y)
                {
                    max_y = xrdPoints[start].Y;
                    max_x = xrdPoints[start].X;
                }
            }

            return new GraphPoint(max_x, max_y);
            //chart.Series["XRD Peaks"].Points.AddXY(max_x, max_y);
        }

        private static void FindPeak(int LeftIndex, int RightIndex, double[] filtredArray, double[] x, Chart chart)
        {
            List<double> subArray = new List<double>();
            for(int i = LeftIndex; i <= RightIndex; i++)
            {
                subArray.Add(filtredArray[i]);
            }

            var diffArray = SavitzkyGolayFilter.Filter(subArray.ToArray(), 35, 3);
            int j = 0;
            for (int i = LeftIndex; i <= RightIndex; i++)
            {
                chart.Series["XRD Smooth"].Points.AddXY(x[i], diffArray[j]);
                j++;
            }

        }

        private static int FindLeftPeakEgde(int maxIndex, double[] differArray)
        {
            int i = maxIndex - 1;
            while (differArray[i] < differArray[i + 1] && i > 0 && i < differArray.Length - 1)
                i--;

            return i;
        }

        private static int FindRightPeakEgde(int minIndex, double[] differArray)
        {
            int i = minIndex + 1;
            while (differArray[i] > differArray[i - 1] && i > 0 && i < differArray.Length - 1)
                i++;

            return i;
        }

        private static int FinMinIndex(int maxIndex, double[] smoothedDifferY)
        {
            int i = maxIndex + 1;
            if (i > smoothedDifferY.Length - 1)
                return i - 1;

            while (smoothedDifferY[i] < smoothedDifferY[i - 1] && i < smoothedDifferY.Length - 1)
                i++;

            return i - 1;
        }

        private static int FindMaxIndex(int i, double[] smoothedDifferY)
        {
            int startIndex = i;
            while (smoothedDifferY[i] > smoothedDifferY[i - 1] && i < smoothedDifferY.Length - 1)
                i++;

            int maxIndex = startIndex;
            for(; startIndex < i; startIndex++)
            {
                maxIndex = smoothedDifferY[maxIndex] < smoothedDifferY[startIndex] ? startIndex : maxIndex;
            }

            return maxIndex;
        }

        private static bool isPeak(List<GraphPoint> xrdPoints, int startIndex, int endIndex)
        {
            double min_y = Double.MaxValue;
            double max_y = Double.MinValue;
            for(int i = startIndex; i <= endIndex; i++)
            {
                min_y = Math.Min(min_y, xrdPoints[i].Y);
                max_y = Math.Max(max_y, xrdPoints[i].Y);
            }

            return max_y - min_y >= 50;
        }

        private static void FindLoclaPeak(double x, double x1, List<GraphPoint> xrdPoints, Chart chart)
        {
            double max_y = -1000000;
            double max_x = 0;
            double min_y = Double.MaxValue;
            for(int i = 0; i < xrdPoints.Count; i++)
            {
                if (xrdPoints[i].X >= x && xrdPoints[i].X <= x1)
                {
                    min_y = Math.Min(xrdPoints[i].Y, min_y);
                    if (xrdPoints[i].Y > max_y)
                    {
                        max_y = xrdPoints[i].Y;
                        max_x = xrdPoints[i].X;
                    }
                    chart.Series["XRD Peaks"].Points.AddXY(xrdPoints[i].X, xrdPoints[i].Y);
                }
                if (xrdPoints[i].X > x1)
                    break;
            }
            //chart.Series["XRD Peaks"].Points.AddXY(max_x, max_y);
        }

        public static string GetXRDFilePath()
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Выберите файл рентгена ";
                dlg.Filter = "Файл Рентгена  (*.txt)|*.txt|All files (*.*)|*.*";
                dlg.Multiselect = false;

                dlg.ShowDialog();
                if (string.IsNullOrEmpty(dlg.FileName))
                    return null;

                return dlg.FileName;
            }
        }

    }
}


//differList = SimpleMovingAvarage(differList, 10);

/*
bool findedPeak = false;
double x1 = 0;
double x2 = 0;
for(int i = 1; i < differList.Count; i++)
{

    if (differList[i].Y > 5 && !findedPeak)
    {
        //x1 = FindBeginOfPeak(i, differList);
        x1 = differList[i - 5].X;   
    }
    if (differList[i].Y < -5 && x1 != 0 && !findedPeak)
    {
        //x2 = FindEndOfPeak(i, differList);
        x2 = differList[i + 5].X;
        findedPeak = true;
        //FindLoclaPeak(x1, x2, xrdPoints, chart);
        //x1 = x2 = 0;
    }
    if ((differList[i].Y < 5 || differList[i].Y > -5) && findedPeak )
    {
        findedPeak = false;
        FindLoclaPeak(x1, x2, xrdPoints, chart);
        x1 = x2 = 0;
    }
    //chart.Series["XRD Peaks"].Points.AddXY(differList[i].X, findYValue(xrdPoints, differList[i].X));
}
*/



/*
 if (j[i] == 'd' && j[i + 1] == 'u')
                {
                    if (i - startIndex >= minPeakSize)
                    {
                        
                    startIndex = i+1;
                }
*/


/*
for (int i = 0; i < j.Count() - 1; i++)
            {
                if (j[i] == 'u' && !isPeakStarted) { isPeakStarted = true; startIndex = i; continue; }

                if (j[i] == 'd' && isPeakStarted && i - startIndex >= minPeakSize && j[i + 1] == 'u')
                {
                    isPeakStarted = false;
                    string peak = j.Substring(startIndex, i - startIndex);
                    double countU = Convert.ToDouble(peak.Count(f => (f == 'u')));
                    double countD = Convert.ToDouble(peak.Count(f => (f == 'd')));
                    if (peak.IndexOf('u') > peak.IndexOf('d'))
                        continue;

                    if (countU == 0 || countD == 0)
                        continue;

                    if (countU < countD)
                    {
                        double temp = countU;
                        countU = countD;
                        countD = temp;
                    }

                    if (countU / (countD + countU) * 100 >= procent)
                        continue;


                    if (isPeak(xrdPoints, startIndex, i))
                        FindLoclaPeak(x[startIndex], x[i], xrdPoints, chart);
                }
            }
*/

/*
if (y[i] > y[i - 1] * porogMax)
    j += "u";
else if (y[i] < y[i - 1] * porogMin)
    j += "d";
else
    j += " ";//j.Last();
*/

//double max_y = Double.MinValue;
//double max_x = 0;
//chart.Series["XRD Peaks"].Points.AddXY(x[minIndex], z[minIndex]);
//chart.Series["XRD Peaks"].Points.AddXY(x[maxIndex], z[maxIndex]);
/*
for (; leftEdge < rightEdge; leftEdge++)
{
    if (xrdPoints[leftEdge].Y > max_y)
    {
        max_y = xrdPoints[leftEdge].Y;
        max_x = xrdPoints[leftEdge].X;
    }
}*/


/*if (xrdDiffs[i - 2].index == maxIndex + 1)
                    FindMaxPeak(xrdDiffs[i - 3].index, xrdDiffs[i].index, chart, xrdPoints);*/
/*
if (xrdDiffs[i + 2].index == minIndex - 1)
{
    wasMerged = i + 4 == xrdDiffs.Count;
    //FindMaxPeak(xrdDiffs[i].index, xrdDiffs[i + 3].index, chart, xrdPoints);
    chart.Series["XRD Peaks"].Points.AddXY(xrdDiffs[i].x, xrdDiffs[i].y);
    chart.Series["XRD Peaks"].Points.AddXY(xrdDiffs[i + 3].x, xrdDiffs[i + 3].y);
    i += 2;
    continue;
}
else
{
    //wasMerged = false;
    //FindMaxPeak(xrdDiffs[i].index, xrdDiffs[i + 1].index, chart, xrdPoints);
    chart.Series["XRD Peaks"].Points.AddXY(xrdDiffs[i].x, xrdDiffs[i].y);
    chart.Series["XRD Peaks"].Points.AddXY(xrdDiffs[i + 1].x, xrdDiffs[i + 1].y);
}
*/

/*
int maxIndex = xrdDiffs[i].index - 1;
while (z[maxIndex] < z[maxIndex + 1] && maxIndex > 0 && maxIndex < z.Length - 1)
    maxIndex--;

int minIndex = xrdDiffs[i + 1].index + 1;
while (z[minIndex] > z[minIndex - 1] && minIndex > 0 && minIndex < z.Length - 1)
    minIndex++;


//i = chart.Series["XRD Peaks"].Points.Count;
*/

                /*
                int size = minIndex - maxIndex;//xrdDiffs[i + 1].index - xrdDiffs[i].index;
                double[] yCheck = new double[size];
                double[] xCheck = new double[size];
                int originalArrayIndex = maxIndex;//xrdDiffs[i].index;

                for (int j = 0; j < size; j++)
                {
                    yCheck[j] = xrdPoints[originalArrayIndex].Y;
                    xCheck[j] = xrdPoints[originalArrayIndex].X;
                    originalArrayIndex++;
                }

                if (GetDropCoords(yCheck, xCheck, windowSize, order, minDropHeight, minDropDepth, chart, true).Count != 0) 
                {
                    chart.Series["XRD Peaks"].Points.AddXY(xrdDiffs[i].x, xrdDiffs[i].y);
                    chart.Series["XRD Peaks"].Points.AddXY(xrdDiffs[i + 1].x, xrdDiffs[i + 1].y);
                }*/

            /*
            int xrdLastIndex = xrdDiffs.Count - 1;
            if (!wasMerged)
                FindMaxPeak(xrdDiffs[xrdLastIndex - 1].index, xrdDiffs[xrdLastIndex].index, chart, xrdPoints);
            */


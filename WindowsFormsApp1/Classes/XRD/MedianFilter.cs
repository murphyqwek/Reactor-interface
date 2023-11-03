using Reactor_Interface.Classes.Experiment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reactor_Interface.Classes.XRD
{
    public class MedianFilter
    {
        public static List<GraphPoint> ApplyMedianFilter(List<GraphPoint> points, int windowSize) 
        {
            List<GraphPoint> result = new List<GraphPoint>();

            double[] y = new double[points.Count];

            for (int i = 0; i < points.Count; i++)
            {
                y[i] = points[i].Y;
            }

            y = ApplyMedianFilter(y, windowSize);

            for (int i = 0; i < points.Count; i++)
            {
                result.Add(new GraphPoint(points[i].X, y[i] / 10));
            }
            return result;
        }

        public static double[] ApplyMedianFilter(double[] data, int windowSize)
        {
            int totalDataPoints = data.Length;
            double[] filteredData = new double[totalDataPoints];
            int halfWindowSize = windowSize / 2;

            for (int i = 0; i < totalDataPoints; i++)
            {
                double[] window = new double[windowSize];
                int start = i - halfWindowSize;
                int end = i + halfWindowSize;

                if (start < 0)
                    start = 0;
                if (end >= totalDataPoints)
                    end = totalDataPoints - 1;

                int windowIndex = 0;
                for (int j = start; j < end; j++)
                {
                    window[windowIndex] = data[j];
                    windowIndex++;
                }

                Array.Sort(window);
                filteredData[i] = window[halfWindowSize];
            }

            return filteredData;
        }
    }
}

using Reactor_Interface.Classes.Experiment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Reactor_Interface.Classes.XRD
{
    public class ExponentialMovingAvarage
    {
        public static List<GraphPoint> Calculate(List<GraphPoint> points, int smoothingFactor)
        {
            List<GraphPoint> result = new List<GraphPoint>();

            double[] y = new double[points.Count];

            for (int i = 0; i < points.Count; i++)
            {
                y[i] = points[i].Y;
            }

            y = EMA(y, smoothingFactor);

            for (int i = 0; i < points.Count; i++)
            {
                result.Add(new GraphPoint(points[i].X, y[i]));
            }

            //foreach(double newY in ExponentialMovingAverage(y, 5))

            return result;
        }

        public static double[] EMA(double[] x, int N)
        {
            // x is the input series            
            // N is the notional age of the data used
            // k is the smoothing constant

            double k = 2.0 / (N + 1);
            double[] y = new double[x.Length];
            y[0] = x[0];
            for (int i = 1; i < x.Length; i++) y[i] = k * x[i] + (1 - k) * y[i - 1];

            return y;
        }
    }
}

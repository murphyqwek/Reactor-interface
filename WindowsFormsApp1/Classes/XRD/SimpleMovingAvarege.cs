using Reactor_Interface.Classes.Experiment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reactor_Interface.Classes.XRD
{
    public class SimpleMovingAvarege
    {
        public static List<GraphPoint> Filter(List<GraphPoint> data, int period)
        {
            int totalDataPoints = data.Count;
            List<GraphPoint> points = new List<GraphPoint>();

            for (int i = period - 1; i < totalDataPoints; i++)
            {
                double sum = 0;
                for (int j = 0; j < period; j++)
                {
                    sum += data[i - j].Y;
                }
                points.Add(new GraphPoint(data[i].X, sum / period));
            }

            return points;
        }
    }
}

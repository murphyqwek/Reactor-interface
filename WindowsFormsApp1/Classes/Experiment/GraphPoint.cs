using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reactor_Interface.Classes.Experiment
{
    public class GraphPoint
    {
        public double X { get; }
        public double Y { get; }

        public GraphPoint(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}

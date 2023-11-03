using MathNet.Numerics.Interpolation;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reactor_Interface.Classes.XRD
{
    using Reactor_Interface.Classes.Experiment;

    /// </summary>
    using System;
    using System.Linq;

    public class SavitzkyGolayFilter
    {
        public static List<GraphPoint> Filter(List<GraphPoint> points, int windowSize, int polynomialOrder)
        {
            double[] rawData = new double[points.Count];
            for(int i = 0; i < points.Count; i++)
            {
                rawData[i] = points[i].Y;
            }

            rawData = Filter(rawData, windowSize, polynomialOrder);

            List<GraphPoint> filteredPoints = new List<GraphPoint>();

            for(int i = 0; i < points.Count; i++)
            {
                filteredPoints.Add(new GraphPoint(points[i].X, rawData[i]));
            }

            return filteredPoints;
        }


        public static double[] Filter(double[] data, int windowSize, int polynomialOrder)
        {
            int halfWindowSize = windowSize / 2;
            int dataSize = data.Length;
            double[] result = new double[dataSize];

            if (polynomialOrder >= windowSize)
            {
                throw new ArgumentException("Polynomial order must be less than window size.");
            }

            for (int i = 0; i < dataSize; i++)
            {
                int left = i - halfWindowSize;
                int right = i + halfWindowSize;

                // Начало и конец данных, где необходимо учесть граничные условия.
                if (left < 0)
                {
                    left = 0;
                }
                if (right >= dataSize)
                {
                    right = dataSize - 1;
                }

                double[] x = Enumerable.Range(left, right - left + 1).Select(n => (double)n).ToArray();
                double[] y = x.Select(idx => data[(int)idx]).ToArray();

                double[] coeffs = FitPolynomial(x, y, polynomialOrder);
                result[i] = EvaluatePolynomial(coeffs, i);
            }

            return result;
        }

        private static double[] FitPolynomial(double[] x, double[] y, int order)
        {
            int matrixSize = order + 1;
            double[,] matrix = new double[matrixSize, matrixSize];
            double[] vector = new double[matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = Enumerable.Range(0, x.Length).Sum(idx => Math.Pow(x[idx], row + col));
                }

                vector[row] = Enumerable.Range(0, x.Length).Sum(idx => Math.Pow(x[idx], row) * y[idx]);
            }

            return SolveSystem(matrix, vector);
        }

        private static double[] SolveSystem(double[,] matrix, double[] vector)
        {
            int size = vector.Length;
            double[] result = new double[size];

            for (int pivot = 0; pivot < size; pivot++)
            {
                for (int row = pivot + 1; row < size; row++)
                {
                    double factor = -matrix[row, pivot] / matrix[pivot, pivot];
                    vector[row] += factor * vector[pivot];

                    for (int col = pivot; col < size; col++)
                    {
                        matrix[row, col] += factor * matrix[pivot, col];
                    }
                }
            }

            for (int row = size - 1; row >= 0; row--)
            {
                result[row] = vector[row];

                for (int col = row + 1; col < size; col++)
                {
                    result[row] -= matrix[row, col] * result[col];
                }

                result[row] /= matrix[row, row];
            }

            return result;
        }

        private static double EvaluatePolynomial(double[] coeffs, double x)
        {
            double result = 0.0;
            int degree = coeffs.Length - 1;

            for (int i = degree; i >= 0; i--)
            {
                result = result * x + coeffs[i];
            }

            return result;
        }
    }
}
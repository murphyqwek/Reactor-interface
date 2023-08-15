using CenterSpace.NMath.Core;
using Reactor_Interface.Classes.Experiment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Reactor_Interface.Classes.XRD
{
    public class PolynomialApproximation
    {
        public static double[] FitPolynomial(double[] x, double[] y, int degree)
        {
            List<GraphPoint> graphPoints = new List<GraphPoint>();

            for(int i = 0; i < x.Length; i++)
            {
                graphPoints.Add(new GraphPoint(x[i], y[i]));
            }

            return FitPolynomial(graphPoints, degree);
        }

        public static double[] FitPolynomial(List<GraphPoint> xrdPoints, int degree)
        {
            // Создание матрицы системы уравнений
            int n = xrdPoints.Count;
            int matrixSize = degree + 1;
            double[,] matrix = new double[matrixSize, matrixSize];
            double[] vector = new double[matrixSize];

            // Заполнение матрицы и вектора правой части системы
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = 0;

                    for (int k = 0; k < n; k++)
                    {
                        matrix[i, j] += Math.Pow(xrdPoints[k].X, i + j);
                    }
                }

                for (int k = 0; k < n; k++)
                {
                    vector[i] += xrdPoints[k].Y * Math.Pow(xrdPoints[k].X, i);
                }
            }

            // Решение системы уравнений
            double[] coefficients = new double[matrixSize];
            GaussianElimination(matrix, vector, coefficients);

            return coefficients;
        }

        private static void GaussianElimination(double[,] matrix, double[] vector, double[] result)
        {
            int matrixSize = vector.Length;

            // Прямой ход метода Гаусса
            for (int pivot = 0; pivot < matrixSize - 1; pivot++)
            {
                for (int row = pivot + 1; row < matrixSize; row++)
                {
                    double factor = matrix[row, pivot] / matrix[pivot, pivot];

                    for (int col = pivot; col < matrixSize; col++)
                    {
                        matrix[row, col] -= factor * matrix[pivot, col];
                    }

                    vector[row] -= factor * vector[pivot];
                }
            }

            // Обратный ход метода Гаусса
            result[matrixSize - 1] = vector[matrixSize - 1] / matrix[matrixSize - 1, matrixSize - 1];

            for (int row = matrixSize - 2; row >= 0; row--)
            {
                double sum = 0;

                for (int col = row + 1; col < matrixSize; col++)
                {
                    sum += matrix[row, col] * result[col];
                }

                result[row] = (vector[row] - sum) / matrix[row, row];
            }
        }
    }
}

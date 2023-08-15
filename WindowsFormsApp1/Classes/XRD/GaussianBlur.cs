using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reactor_Interface.Classes.XRD
{
    public static class GaussianBlur
    {
        public static double[] Apply(double[] inputSignal, double standardDeviation)
        {
            int signalLength = inputSignal.Length;
            double[] blurredSignal = new double[signalLength];

            int filterLength = (int)Math.Ceiling(6 * standardDeviation); // Определение размера фильтра на основе стандартного отклонения

            // Подготовка коэффициентов фильтра Гаусса
            double[] kernel = new double[filterLength];
            double sum = 0;

            for (int i = 0; i < filterLength; i++)
            {
                double x = i - filterLength / 2;
                kernel[i] = Math.Exp(-(x * x) / (2 * standardDeviation * standardDeviation));
                sum += kernel[i];
            }

            for (int i = 0; i < filterLength; i++)
            {
                kernel[i] /= sum; // Нормализация коэффициентов
            }

            // Применение фильтра
            for (int i = 0; i < signalLength; i++)
            {
                double filteredValue = 0;

                for (int j = 0, k = i - filterLength / 2; j < filterLength; j++, k++)
                {
                    if (k >= 0 && k < signalLength)
                    {
                        filteredValue += kernel[j] * inputSignal[k];
                    }
                }

                blurredSignal[i] = filteredValue;
            }

            return blurredSignal;
        }
    }
}

using System;
using System.Linq;

namespace LeastSquare.src
{
    public static class ApproxError
    {
        public static double MeanRelativeError(double[] realData, double[] calculatedData)
        {
            if (realData.Length == calculatedData.Length)
            {
                return (calculatedData.Select((x, i) => Math.Abs(realData[i] - x) / x).Sum() / realData.Length) * 100;
            }

            return -1;
        }

        public static double TheilsCoefficient(double[] realData, double[] calculatedData)
        {
            double arithmeticMean = realData.Sum() / realData.Length;
            double numerator = 0;

            for (int i = 0; i < calculatedData.Length; i++)
            {
                numerator += Math.Pow(calculatedData[i] - arithmeticMean, 2);
            }

            return Math.Sqrt(numerator / calculatedData.Sum(x => Math.Pow(x, 2)));
        }

        public static double Dispersion(double[] realData)
        {
            return (realData.Sum(x => 
                Math.Pow(x, 2)) / realData.Length) - Math.Pow(realData.Sum() / realData.Length, 2);
        }

        public static double StandartDeviation(double[] realData)
        {
            return Math.Sqrt(Dispersion(realData));
        }

        public static double IndexOfDetermination(double[] realData, double[] calculatedData)
        {
            double arithmeticMean = realData.Sum() / realData.Length;

            return 1 - realData.Select((x, i) => Math.Pow((x - calculatedData[i]) / (x - arithmeticMean), 2)).Sum();
        }

        public static double EmpiricalCorrelation(double[] realData, double[] calculatedData)
        {
            double arithmeticMean = realData.Sum() / realData.Length;

            return Math.Sqrt(realData.Select((x, i) => 
                Math.Pow((arithmeticMean - calculatedData[i]) / (x - arithmeticMean), 2)).Sum());
        }
    }
}

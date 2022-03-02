using System;
using System.Linq;

namespace LeastSquare.src
{
    public static class LinearEquation
    {
        public static string GetEquation(double a, double b)
        {
            if (b < 0)
            {
                return $"y = {a}x - {Math.Abs(b)}";
            }

            return $"y = {a}x + {b}";
        }

        public static void GetCoefficients(double[] x, double[] y, out double a, out double b)
        {
            a = (x.Length * SumOfXY(x, y) - x.Sum() * y.Sum()) / Denominator(x);
            b = (y.Sum() * SquareOfX(x) - x.Sum() * SumOfXY(x, y)) / Denominator(x);
        }

        private static double Denominator(double[] x)
        {
            return x.Length * SquareOfX(x) - x.Sum() * x.Sum();
        }

        private static double SumOfXY(double[] x, double[] y)
        {
            return x.Select((f, i) => f * y[i]).Sum();
        }

        private static double SquareOfX(double[] x)
        {
            return x.Sum(f => f * f);
        }
    }
}

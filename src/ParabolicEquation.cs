using System;
using System.Linq;

namespace LeastSquare.Source
{
    public static class ParabolicEquation
    {
        public static string GetEquation(double a, double b, double c)
        {
            string signB = Math.Sign(b) == 1 ? "+" : "-";
            string signC = Math.Sign(c) == 1 ? "+" : "-";

            return $"y = {a} {signB} {b}x {signC} {c}x^2";
        }

        public static void GetCoefficient(double[] x, double[] y, out double a, out double b, out double c)
        {
            double[,] SLE = new double[,]
            {
                { x.Length, x.Sum(), x.Sum(a => a * a) },
                { x.Sum(), x.Sum(a => a * a), x.Sum(a => (float)Math.Pow(a, 3)) },
                { x.Sum(a => a * a), x.Sum(a => Math.Pow(a, 3)), x.Sum(a => Math.Pow(a, 4)) }
            };

            double[] FreeNums = new double[] { y.Sum(), SumOfXY(x, y), SumOfX2Y(x, y) };

            a = SleSolver.SLE_Solutions(SLE, FreeNums)[0];
            b = SleSolver.SLE_Solutions(SLE, FreeNums)[1];
            c = SleSolver.SLE_Solutions(SLE, FreeNums)[2];
        }

        private static double SumOfXY(double[] x, double[] y)
        {
            return x.Select((f, i) => f * y[i]).Sum();
        }

        private static double SumOfX2Y(double[] x, double[] y)
        {
            return x.Select((f, i) => f * f * y[i]).Sum();
        }
    }
}

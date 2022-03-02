using System;
using System.Collections.Generic;
using System.Linq;

namespace LeastSquare.Source
{
    public static class FDMethod
    {
        public static string EquationType(double[] y, out List<double[]> differenceSheet)
            => GetOrderOfEquation(y, out differenceSheet) switch
        {
            1 => "y = ax + b",
            2 => "y = ax^2 + bx + c",
            3 => "y = ax^3 + bx^2 + cx + d",
            -1 => "y = a*exp(x) + c",
            _  => ""
        };

        private static int GetOrderOfEquation(double[] y, out List<double[]> differenceTable)
        {
            differenceTable = new List<double[]>();

            double[] rateChange = GetRateOfChange(y);
            int counter = y.Length;

            for (int i = 0; i < counter; i++)
            {
                for (int j = 0; j < y.Length - 1; j++)
                {
                    y[j] = Math.Round(Math.Abs(y[j] - y[j + 1]), 3);
                }

                Array.Resize(ref y, y.Length - 1);
                differenceTable.Add(y);

                if (y.Sum() - y.Sum() / y.Length <= 0.01)
                {
                    differenceTable.Add(rateChange);
                    return i - 1;
                }
            }

            differenceTable.Add(rateChange);
            return -1;
        }

        private static double[] GetRateOfChange(double[] y)
        {
            double[] result = new double[y.Length - 1];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Math.Round(y[i + 1] / y[i], 3);
            }

            return result;
        }
    }
}

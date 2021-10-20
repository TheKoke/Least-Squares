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
                { x.Sum(a => a * a), x.Sum(a => (float)Math.Pow(a, 3)), x.Sum(a => (float)Math.Pow(a, 4)) }
            };

            double[] FreeNums = new double[] { y.Sum(), SumOfXY(x, y), SumOfX2Y(x, y) };

            a = SLE_Solutions(SLE, FreeNums)[0];
            b = SLE_Solutions(SLE, FreeNums)[1];
            c = SLE_Solutions(SLE, FreeNums)[2];
        }

        private static double[] SLE_Solutions(double[,] Matrix, double[] FreeNums)
        {
            double[] solutions = new double[Matrix.GetLength(0)];

            for (int i = 0; i < solutions.Length; i++)
            {
                double[,] Clone = (double[,])Matrix.Clone();

                for (int j = 0; j < solutions.Length; j++)
                {
                    Clone[j, i] = FreeNums[j];
                }

                solutions[i] = Determinant(Clone) / Determinant(Matrix);
            }

            return solutions;
        }

        private static double Determinant(double[,] Matrix)
        {
            double result = 0;

            if (Matrix.GetLength(0) == 2)
            {
                return (Matrix[0, 0] * Matrix[1, 1]) - (Matrix[0, 1] * Matrix[1, 0]);
            }

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                if (i % 2 == 0)
                {
                    result += Matrix[0, i] * Determinant(MinorOf(Matrix, 0, i));
                }
                else
                {
                    result -= Matrix[0, i] * Determinant(MinorOf(Matrix, 0, i));
                }
            }

            return result;
        }

        private static double[,] MinorOf(double[,] Matrix, int row, int col)
        {
            double[,] Minor = new double[Matrix.GetLength(0) - 1, Matrix.GetLength(1) - 1];
            int delrow, delcol;

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                delrow = i;

                if (i > row)
                {
                    delrow--;
                }

                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    delcol = j;

                    if (j > col)
                    {
                        delcol--;
                    }

                    if (i != row && j != col)
                    {
                        Minor[delrow, delcol] = Matrix[i, j];
                    }
                }
            }

            return Minor;
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

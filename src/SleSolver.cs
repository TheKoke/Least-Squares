using System;

namespace LeastSquare.Source
{
	public class SleSolver
	{
        public static double Determinant(double[,] Matrix)
        {
            if (Matrix.GetLength(0) == 1)
            {
                return Matrix[0, 0];
            }

            double result = 0;
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                result += Matrix[0, i] * AlgebraicApp(Matrix, 0, i);
            }

            return result;
        }

        public static double[,] GetMinor(double[,] Matrix, int DelStr, int DelCol)
        {
            double[,] MinorMatrix = new double[Matrix.GetLength(0) - 1, Matrix.GetLength(1) - 1];

            short varForIndexStr = 0;
            short varForIndexCol = 0;

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                if (i == DelStr)
                    continue;

                for (int j = 0; j < Matrix.GetLength(0); j++)
                {
                    if (j == DelCol)
                        continue;

                    MinorMatrix[varForIndexStr, varForIndexCol] = Matrix[i, j];
                    varForIndexCol++;
                }

                varForIndexStr++;
                varForIndexCol = 0;
            }

            return MinorMatrix;
        }

        public static double AlgebraicApp(double[,] Matrix, int firstIndex, int SecIndex)
        {
            return Math.Pow(-1, firstIndex + SecIndex) * Determinant(GetMinor(Matrix, firstIndex, SecIndex));
        }

        public static double[] SLE_Solutions(double[,] Matrix, double[] freeNums)
        {
            double[] solutions = new double[Matrix.GetLength(0)];

            for (int i = 0; i < solutions.Length; i++)
            {
                double[,] Clone = (double[,])Matrix.Clone();

                for (int j = 0; j < solutions.Length; j++)
                {
                    Clone[j, i] = freeNums[j];
                }

                solutions[i] = Determinant(Clone) / Determinant(Matrix);
            }

            return solutions;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theory_of_Plasticity
{
    internal class Determinant
    {
        //        public static double determinantMatrix(double[,] tensor) { 
        //            double determinant = 0;
        //            if (tensor.Length == 2)
        //            {
        //                return tensor[0, 0] * tensor[1, 1] - tensor[0, 1] * tensor[1, 0];
        //            }
        //            for(int j = 0; j < tensor.Length; j++)
        //{
        //                // Calculate the cofactor for element A[0][j]
        //                double[,] submatrix = new double[tensor.GetLength(0) - 1, tensor.GetLength(1) - 1];
        //                int rowIndex = 0;
        //                for (int i = 1; i < tensor.GetLength(0); i++)
        //                {
        //                    int colIndex = 0;
        //                    for (int k = 0; k < tensor.GetLength(1); k++)
        //                    {
        //                        if (k != j)
        //                        {
        //                            submatrix[rowIndex, colIndex] = tensor[i, k];
        //                            colIndex++;
        //                        }
        //                    }
        //                    rowIndex++;
        //                }
        //                double cofactor = Math.Pow(-1, 0 + j) * determinantMatrix(submatrix);  // Recursive call to calculate determinant

        //                // Multiply the element by its cofactor and add to the determinant
        //                determinant += tensor[0, j] * cofactor;
        //            }
        //            return determinant;
        //        }
        public static double DeterminantMatrix(double[,] matrix)
        {
            int n = matrix.GetLength(0);

            if (n != matrix.GetLength(1))
            {
                throw new ArgumentException("Invalid matrix. It must be square.");
            }

            if (n == 1)
            {
                return matrix[0, 0];
            }

            double determinant = 0;
            int sign = 1;

            for (int j = 0; j < n; j++)
            {
                double[,] submatrix = CreateSubmatrix(matrix, 0, j);
                determinant += sign * matrix[0, j] * DeterminantMatrix(submatrix);
                sign = -sign;
            }

            return determinant;
        }

        private static double[,] CreateSubmatrix(double[,] matrix, int rowToRemove, int colToRemove)
        {
            int n = matrix.GetLength(0);
            double[,] submatrix = new double[n - 1, n - 1];
            int rowIndex = 0;

            for (int i = 0; i < n; i++)
            {
                if (i == rowToRemove)
                {
                    continue;
                }

                int colIndex = 0;
                for (int j = 0; j < n; j++)
                {
                    if (j == colToRemove)
                    {
                        continue;
                    }

                    submatrix[rowIndex, colIndex] = matrix[i, j];
                    colIndex++;
                }

                rowIndex++;
            }

            return submatrix;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LA.Equations;

namespace LA.Matrix
{
    internal class Arithmetic
    {
        public double[,] multiplyMatrices(double[,] A, double[,] B)
        {
            if(A.GetLength(1) != B.GetLength(0))
            {
                return new double[,] { };
            }

            double[,] result = new double[A.GetLength(0), B.GetLength(1)];  

            for(int row = 0; row < A.GetLength(0); row++)
            {
                for(int col = 0; col < B.GetLength(1); col++)
                {
                    for(int k = 0; k < A.GetLength(1); k++)
                    {
                        result[row, col] += A[row, k] * B[k, col];
                    }
                }
            }


            return result;

        }

        public double[,] addMatrices(double[,] A, double[,] B)
        {
            if (A.GetLength(0) != B.GetLength(0) || A.GetLength(1) != B.GetLength(1))
            {
                return new double[,] { };
            }

            double[,] result = new double[A.GetLength(0), A.GetLength(1)];

            for (int row = 0; row < A.GetLength(0); row++)
            {
                for (int col = 0; col < A.GetLength(1); col++)
                {
                    result[row, col] += A[row, col] + B[row, col];
                }
            }


            return result;

        }

        public int computeRank(double[,] matrix)
        {
            int numberNonZeroRows = 0;
            for (int currentRow = 0; currentRow < matrix.GetLength(0); currentRow++)
            {
                
                int currentCol = 0; 

                while(matrix[currentRow, currentCol] == 0)
                {
                    if(currentCol == matrix.GetLength(1) - 1)
                    {
                        numberNonZeroRows++;
                    }
                    else
                    {
                        currentCol++;
                    }

                    
                }
            }
            

            return numberNonZeroRows;
        }

        public int computeNull(double[,] matrix)
        {
            
            return 0;
        }

        public double[,] transpose(double[,] matrix)
        {
            double[,] result = new double[matrix.GetLength(1), matrix.GetLength(0)];

            for(int currentRow = 0; currentRow < matrix.GetLength(0); currentRow++)
            {
                for(int currentColumn = 0; currentColumn < matrix.GetLength(1); currentColumn++)
                {
                    result[currentColumn, currentRow] = matrix[currentRow, currentColumn];
                }
            }
            return result;
        }

    }
}

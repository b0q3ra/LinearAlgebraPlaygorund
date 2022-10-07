using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LA.Equations
{
    internal class SolveSystem
    {
        public static double[] solve(double[,] matrix)
        {
            double[] result = new double[matrix.GetLength(0)];
            SolveSystem.upperTriangular(matrix);
            


            SolveSystem.computeSolutions(matrix, result, result.Length - 1);

            return result;
        }

        /*
            a11 a12 a13 a14     a15
             0  a22 a23 a24     a25
             0   0  a33 a34     a35
             0   0   0  a44     a45
         */
        public static double[] computeSolutions(double[,] upperTriangularMatrix, double[] result, int iteration)
        {
            if (iteration < 0)
            {
                return result;
            }
            else
            {
                double sum = 0;
                double product = 1;
                for(int i = iteration; i <= upperTriangularMatrix.GetLength(0); i++)
                {
                    if(i == iteration)
                    {

                        product = 1 / upperTriangularMatrix[iteration, iteration];
                       
                    }
                    else if(iteration < i && i < upperTriangularMatrix.GetLength(0))
                    {
                        sum += -1 * (upperTriangularMatrix[iteration, i]) * result[i];
                        
                    }
                    else if(i == upperTriangularMatrix.GetLength(0))
                    {
                        result[iteration] = (upperTriangularMatrix[iteration, i] + sum) * product;
                        //Console.Write($"Matrix[{iteration},{i}]: {upperTriangularMatrix[iteration, i]} ");
                        //Console.Write($"Product: {product} ");
                        //Console.Write($"Sum: {sum} ");
                        //Console.Write($"Result[{i}]: {result[iteration]} ");
                        //Console.WriteLine();
                    }
                }


                return computeSolutions(upperTriangularMatrix, result, iteration - 1);
            }
            
        }

        public static double[,] upperTriangular(double[,] matrix)
        {
            /*
             * ex:
                { 11, 12, 13, 14, 15, 16 }
                { 21, 22, 23, 24, 25, 26 }
                { 31, 32, 33, 34, 35, 36 }
                { 41, 42, 43, 44, 45, 46 }
                { 51, 52, 53, 54, 55, 56 }
             */
            
            //GET DIAGONAL LENGTH ex: 5
            int diagonalLength = matrix.GetLength(0) < matrix.GetLength(1) ? matrix.GetLength(0) : matrix.GetLength(1);
            
            //GET NUMBER OF COLUMNS AND NUMBER OF ROWS ex: numberOfRows = 5 and numberOfColumns = 6
            int numberOfRows = matrix.GetLength(0);
            int numberOfColumns = matrix.GetLength(1);

            //ITERATE DIAGONAL ex: matrix[1,1] -> ... -> matrix[5,5]
            for(int diagonalPosition = 0; diagonalPosition < diagonalLength; diagonalPosition++)
            {
                double pivot = matrix[diagonalPosition, diagonalPosition];
                int rowsPermutationCounter = diagonalPosition + 1;
                
                //CHANGES ROW UNTIL PIVOT IS NOT ZERO OR THERE ARE NO MORE ROWS UNDER THE PIVOT
                while (pivot == 0)
                {
                    if(rowsPermutationCounter >= numberOfRows)
                    {
                        System.Environment.Exit(0);
                    }
                    SolveSystem.interchangeRows(diagonalPosition, rowsPermutationCounter, matrix);
                    pivot = matrix[diagonalPosition, diagonalPosition];
                    rowsPermutationCounter++;
                }

                //SCALE ROW2 AND ADDED TO ROW1
                for(int currentRow = diagonalPosition + 1; currentRow < numberOfRows; currentRow++)
                {
                    
                    double coeficient = matrix[currentRow, diagonalPosition] / pivot;
                    SolveSystem.addScaledRow(currentRow, diagonalPosition, -1 * coeficient, matrix);
                    //SolveSystem.printMatrix(matrix);
                    //Console.WriteLine("");
                }
                
            }

            return matrix;
        }

        public static double[,] interchangeRows(int row1, int row2, double[,] matrix)
        {
            for(int currentColumn = 0; currentColumn < matrix.GetLength(1); currentColumn++)
            {
                double temp = matrix[row1, currentColumn];
                matrix[row1, currentColumn] = matrix[row2, currentColumn];
                matrix[row2, currentColumn] = temp;
            }

            return matrix;
        }

        public static double[,] addRow(int row1, int row2, double[,] matrix)
        {
            for (int currentColumn = 0; currentColumn < matrix.GetLength(1); currentColumn++)
            {
                
                matrix[row1, currentColumn] += matrix[row2, currentColumn];
                
            }

            return matrix;
        }

        public static double[,] addScaledRow(int row1, int row2, double coeficient, double[,] matrix)
        {
            for (int currentColumn = 0; currentColumn < matrix.GetLength(1); currentColumn++)
            {

                matrix[row1, currentColumn] += coeficient * matrix[row2, currentColumn];

            }

            return matrix;
        }

        public static void printMatrix(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine("");
            }
        }
    }
}

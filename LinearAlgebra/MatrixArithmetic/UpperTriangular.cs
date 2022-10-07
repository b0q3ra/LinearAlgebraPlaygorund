using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA.Matrix
{
    public class UpperTriangular
    {
        
        //COMPUTE UPPER TRIANGULAR MATRIX
        public double[,] computeUpperTriangular(double[,] matrix)
        {

            //MATRIX DIAGONAL LENGTH
            int matrixDiagonalLength = matrix.GetLength(0) < matrix.GetLength(1) ? matrix.GetLength(0) : matrix.GetLength(1);

            //ITERATE THROUGH ALL COLUMNS
            for(int currentColumn = 0; currentColumn < matrix.GetLength(1); currentColumn++)
            {
                //SEARCH FIRST NON ZERO ENTRY IN CURRENT COLUMN ASSIGN TO currentPivot
                int currentPivotIndex = searchPivot(matrix, currentColumn);

                //CHECK IF NON ZERO ENTRY EXISTS ON THE COLUMN, IF NOT SKIP ITERATION
                if (currentPivotIndex != -1)
                {
                    
                    //SWAP CURRENT PIVOT TO PIVOT POSITION
                    swapRow(matrix, currentColumn, currentPivotIndex);
                    double currentPivot = matrix[currentColumn, currentColumn];



                    //ELIMINATE ALL NON ZERO ENTRIES BELOW THE PIVOT
                    for (int currentRow = currentColumn + 1; currentRow < matrix.GetLength(0); currentRow++)
                    {
                        //IF CURRENT TARGET ENTRY IS NOT ZERO, ADD SCALED ROW
                        if(matrix[currentRow, currentColumn] != 0)
                        {
                            double scalar = -1 * (matrix[currentRow, currentColumn]/currentPivot);
                            addScaledRow(matrix, scalar, currentPivotIndex, currentRow);   
                        }

                    }
                }
                    
                
            }

            //Utils.printMatrix(matrix);
            return matrix;

        }
        
        //NORMALIZE PIVOT
        public double[,] normalizePivots(double[,] matrix)
        {
            //COMPUTE UPPER TRIANGULAR MATRIX
            matrix = computeUpperTriangular(matrix);

            //COMPUTE DIAGONAL LENGTH
            int diagonalLength = computeDiagonalLength(matrix);

            //ITERATE THROUGH DIAGONAL
           for(int currentRow = 0; currentRow < matrix.GetLength(0); currentRow++)
           {

                int currentColumn = 0;

                while(currentColumn < matrix.GetLength(1) && matrix[currentRow, currentColumn] == 0)
                {
                    currentColumn++;
                }
                
                if(currentColumn < matrix.GetLength(1))
                {
                    double scalar = 1 / matrix[currentRow, currentColumn];
                    scaleRow(matrix, scalar, currentRow, currentColumn);
                }

           }
            
            
            
            
            Utils.printMatrix(matrix);

            return matrix;
        }

        //COMPUTE ROW-ECHELON FORM
        public double[,] rowEchelon(double[,] matrix)
        {
            normalizePivots(matrix);

            for(int currentRow = 0; currentRow < matrix.GetLength(0); currentRow++)
            {
                int currentColumn = 0;
                while(matrix[currentRow, currentColumn] == 0)
                {
                    currentColumn++;
                }
                if (currentColumn < matrix.GetLength(1))
                {
                    for(int targetRow = currentRow - 1; targetRow >= 0; targetRow--)
                    {
                        //Console.Write(matrix[upperRow, currentColumn] + " ");
                        double scalar = -(matrix[targetRow, currentColumn] / matrix[currentRow, currentColumn]);
                        addScaledRow(matrix, scalar, currentRow, targetRow);
                        
                        
                        
                    }
                    Console.WriteLine();
                }
            }
            
            return matrix;
        }

        //SEARCH VALID PIVOT INDEX IN GIVEN COLUMN
        public int searchPivot(double[,] matrix, int pivot)
        {

            try
            {
                for(int i = pivot; i < matrix.GetLength(0); i++)
                {
                    if(matrix[i, pivot] != 0)
                    {
                        return i;
                    }
                }
                throw new Exception("No Pivot Found");

            }catch (Exception e)
            {
                return -1;
            }


            
        }

        //SWAP ROWS BY INDEX
        public void swapRow(double[,] matrix, int row1, int row2)
        {
            for(int i = 0; i < matrix.GetLength(1); i++)
            {
                double temp = matrix[row1, i];
                matrix[row1, i] = matrix[row2, i];
                matrix[row2, i] = temp;
            }
        }

        //ADD SCALED ROW TO TARGET ROW
        public double[,] addScaledRow(double[,]matrix, double scalar, int scaledRow, int targetRow)
        {
            for(int i = 0; i < matrix.GetLength(1); i++)
            {
                matrix[targetRow, i] += scalar * matrix[scaledRow, i];
            }

            return matrix;
        }

        //SCALE ROW
        public double[,] scaleRow(double[,] matrix, double scalar, int row, int initialColumn = 0)
        {
            for(int i = initialColumn; i< matrix.GetLength(1); i++)
            {
                matrix[row, i] *= scalar;
            }

            return matrix;
        }

        //COMPUTE DIAGONAL LENGTH
        public int computeDiagonalLength(double[,] matrix)
        {
            return matrix.GetLength(0) < matrix.GetLength(1) ? matrix.GetLength(0) : matrix.GetLength(1);
        }
    }
}

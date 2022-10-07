using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA.Matrix
{
    internal class Utils
    {
        public static void printMatrix(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(matrix[i, j] < 0)
                    {
                        Console.Write("{0:N2} ", matrix[i, j]);
                    }
                    else
                    {
                        Console.Write(" {0:N2} ", matrix[i, j]);
                    }
                    
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public static double[,] generateIdentity(int dimensions)
        {

            double[,] result = new double[dimensions, dimensions];
            for(int i = 0; i < dimensions; i++)
            {
                for(int j = 0; j < dimensions; j++)
                {
                    if(j == i)
                    {
                        result[i, j] = 1;
                    }
                    else
                    {
                        result[i, j] = 0;
                    }
                        
                }
            }

            return result;
        }
    }
}

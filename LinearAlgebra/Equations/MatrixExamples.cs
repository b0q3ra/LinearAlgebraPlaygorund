using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA.Equations
{
    internal class MatrixExamples
    {
        double[,] matrix = new double[,]
{
                { 11, 12, 13, 14, 15, 16 },
                { 21, 22, 23, 24, 25, 26 },
                { 31, 32, 33, 34, 35, 36 },
                { 41, 42, 43, 44, 45, 46 },
                { 51, 52, 53, 54, 55, 56 },

};

        double[,] matrix1 = new double[,]
        {
                { 1, 3, 4 },
                { 2, 8, 9 },
                { 2, 4, 4 },
                { 2, 4, 4 },
                { 2, 4, 4 },

        };

        double[,] matrix2 = new double[,]
        {
                { 1, 1, 1, 4 },
                { 2, 2, 5, 11 },
                { 4, 6, 8, 24 },

        };

        double[,] matrix3 = new double[,]
        {
                { 2 ,    1,      7,      0,   -1 },
                { 3,    2,      0,      -2,   1},
                { 2,    2,      2,      -2,   4 },

        };
    }
}

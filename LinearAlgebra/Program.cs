using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LA.Equations;
using LA.Matrix;
using LA.Examples;
using LA.Sets;
using System.DI;

namespace LA 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            UpperTriangular calculator = new UpperTriangular();
            Arithmetic arithmetic = new Arithmetic();

            double[,] m1 = new double[,]
            {
                { 1, 1, 2 },
                { 2, 2, 5 },
                { 3, 3, 7 },
            };

            calculator.rowEchelon(m1);
            Utils.printMatrix(m1);
            Console.WriteLine(arithmetic.computeRank(m1));
        }
    }
}
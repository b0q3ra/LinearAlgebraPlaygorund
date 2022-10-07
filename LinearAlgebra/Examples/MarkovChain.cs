using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LA.Matrix ;

namespace LA.Examples
{
    internal class MarkovChain
    {   //A is a probability matrix, ith is a column vector
        public void calulateNthIterationMarkov(double[,] A, double[,] x, int ith)
        {
            if(ith > 0)
            {
                Arithmetic machine = new Arithmetic();
                x = machine.multiplyMatrices(A, x);
                calulateNthIterationMarkov(A, x, ith - 1);
            }
        }
    }
}

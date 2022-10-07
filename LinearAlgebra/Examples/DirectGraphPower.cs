using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LA.Matrix;

namespace LA.Examples
{
    internal class DirectGraphPower
    {
        public double[,] calculateGraphPowers(double[,] directG, int powers)
        {
            Arithmetic machine = new Arithmetic();
            double[,] previous = Utils.generateIdentity(directG.GetLength(0));

            for(int i = 0; i < powers; i++)
            {
                previous = machine.multiplyMatrices(previous, directG);
            }

            return previous;
        }
    }
}

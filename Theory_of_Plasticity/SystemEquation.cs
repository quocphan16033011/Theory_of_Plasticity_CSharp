using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theory_of_Plasticity
{
    internal class SystemEquation
    {
        public static double[,] systemEquation(double[,] tensor, double sigma)
        {
            double[,] result = new double[,]
            { { tensor[0, 0] - sigma, tensor[0, 1], tensor[0, 2] }, { tensor[1, 0], tensor[1, 1] - sigma, tensor[1, 2] }, { tensor[2, 0], tensor[2, 1], tensor[2, 2] - sigma } };
            return result;
        }
    }
}

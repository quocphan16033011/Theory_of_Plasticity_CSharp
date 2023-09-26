using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theory_of_Plasticity
{
    internal class SolveSystemEquation
    {
        public static double[,] solveSystemEquation(double[,] systemEquation)
        {
            double[,] systemEquationDelete3 = new double[2, 2];
            for (int i = 0; i < systemEquationDelete3.GetLength(0); i++)
            {
                for (int j = 0; j < systemEquationDelete3.GetLength(1); j++)
                {
                    if (i == 0 && j != 2)
                    {
                        systemEquationDelete3[i, j] = systemEquation[i, j] * (-systemEquation[1, 2]);
                    }
                    else if (i == 1 && j != 2)
                    {
                        systemEquationDelete3[i, j] = systemEquation[i, j] * systemEquation[0, 2];
                    }
                }
            }

            double[] plus2System = new double[2];
            plus2System[0] = systemEquationDelete3[0, 0] + systemEquationDelete3[1, 0];
            plus2System[1] = systemEquationDelete3[0, 1] + systemEquationDelete3[1, 1];

            double n1Follow2 = -plus2System[1] / plus2System[0];
            double n3Follow2 = -(systemEquation[1, 0] * n1Follow2 + systemEquation[1, 1]) / systemEquation[1, 2];

            double n2 = Math.Sqrt(1 / (Math.Pow(n1Follow2, 2) + 1 + Math.Pow(n3Follow2, 2)));
            double n2Op = -n2;
            double n1 = n2 * n1Follow2;
            double n1Op = -n1;
            double n3 = n2 * n3Follow2;
            double n3Op = -n3;

            return new double[,] { { n1, n2, n3 }, { n1Op, n2Op, n3Op } };
        }
    }
}


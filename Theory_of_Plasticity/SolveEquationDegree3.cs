using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theory_of_Plasticity
{
    internal class SolveEquationDegree3
    {
        //public static double[] SolveCharacteristicEquation(double a, double b, double c)
        //{
        //    double x1 = 0;
        //    double x2 = 0;
        //    double x3 = 0;
        //    double sigma_1 = 0;
        //    double sigma_2 = 0;
        //    double sigma_3 = 0;
        //    double Delta = Math.Pow((-a), 2) - 3 * 1 * b;
        //    double k = (9 * 1 * (-a) * b - 2 * Math.Pow((-a), 3) - 27 * Math.Pow(1, 2) * (-c)) / (2 * Math.Sqrt(Math.Abs(Delta) * Math.Abs(Delta)));
        //    if (Delta > 0)
        //    {
        //        if (Math.Abs(k) <= 1)
        //        {
        //            x1 = (2 * Math.Sqrt(Delta) * Math.Cos(Math.Acos(k) / 3) - (-a)) / (3 * 1);
        //            x2 = (2 * Math.Sqrt(Delta) * Math.Cos(Math.Acos(k) / 3 - 2 * Math.PI / 3) - (-a)) / (3 * 1);
        //            x3 = (2 * Math.Sqrt(Delta) * Math.Cos(Math.Acos(k) / 3 + 2 * Math.PI / 3) - (-a)) / (3 * 1);
        //        }
        //        else
        //        {
        //            x1 = x2 = x3 = ((Math.Sqrt(Delta) * Math.Abs(k)) / (3 * 1 * k)) * (Math.Pow((Math.Abs(k) + Math.Sqrt(k * k - 1)), (1 / 3)) + Math.Pow((Math.Abs(k) - Math.Sqrt(k * k - 1)), (1 / 3))) - (-a) / (3 * 1);
        //        }

        //    }

        //    if (Delta == 0)
        //    {
        //        x1 = x2 = x3 = (-(-a) + Math.Pow((Math.Pow((-a), 3) - 27 * 1 * 1 * (-c)), (1 / 3))) / (3 * 1);
        //    }

        //    if (Delta < 0)
        //    {
        //        x1 = x2 = x3 = ((Math.Sqrt(Math.Abs(Delta))) / (3 * 1)) * (Math.Pow((k + Math.Sqrt(k * k + 1)), (1 / 3)) + Math.Pow((k - Math.Sqrt(k * k + 1)), (1 / 3))) - (-a) / (3 * 1);
        //    }
        //    if (x1 > x2 && x1 > x3)
        //    {
        //        sigma_1 = x1;
        //    }
        //    else if (x2 > x1 && x2 > x3)
        //    {
        //        sigma_1 = x1;
        //    }
        //    else
        //    {
        //        sigma_1 = x3;
        //    }

        //    if (sigma_1 == x1 && x2 > x3)
        //    {
        //        sigma_2 = x2;
        //        sigma_3 = x3;
        //    }
        //    else if (sigma_1 == x1 && x3 > x2)
        //    {
        //        sigma_2 = x3;
        //        sigma_3 = x2;
        //    }
        //    else if (sigma_1 == x2 && x1 > x3)
        //    {
        //        sigma_2 = x1;
        //        sigma_3 = x3;
        //    }
        //    else if (sigma_1 == x2 && x3 > x1)
        //    {
        //        sigma_2 = x3;
        //        sigma_3 = x1;
        //    }
        //    else if (sigma_1 == x3 && x1 > x2)
        //    {
        //        sigma_2 = x1;
        //        sigma_3 = x2;
        //    }
        //    else if (sigma_1 == x3 && x2 > x1)
        //    {
        //        sigma_2 = x2;
        //        sigma_3 = x1;
        //    }
        //    return new double[] {sigma_1,sigma_2,sigma_3};
        //}
        public static double[] SolveCharacteristicEquation(double a, double b, double c)
        {
            double x1 = 0;
            double x2 = 0;
            double x3 = 0;
            double Delta = Math.Pow(-a, 2) - 3 * b;
            double k = (9 * (-a) * b - 2 * Math.Pow(-a, 3) - 27 * Math.Pow(1, 2) * (-c)) / (2 * Math.Sqrt(Math.Pow(Math.Abs(Delta), 3)));

            if (Delta > 0)
            {
                if (Math.Abs(k) <= 1)
                {
                    x1 = (2 * Math.Sqrt(Delta) * Math.Cos(Math.Acos(k) / 3) - (-a)) / (3 * 1);
                    x2 = (2 * Math.Sqrt(Delta) * Math.Cos(Math.Acos(k) / 3 - 2 * Math.PI / 3) - (-a)) / (3 * 1);
                    x3 = (2 * Math.Sqrt(Delta) * Math.Cos(Math.Acos(k) / 3 + 2 * Math.PI / 3) - (-a)) / (3 * 1);
                }
                else
                {
                    double term1 = (Math.Sqrt(Delta) * Math.Abs(k)) / (3 * 1 * k);
                    double term2 = Math.Pow((Math.Abs(k) + Math.Sqrt(Math.Pow(k, 2) - 1)), 1 / 3);
                    double term3 = Math.Pow((Math.Abs(k) - Math.Sqrt(Math.Pow(k, 2) - 1)), 1 / 3);
                    x1 = x2 = x3 = term1 * (term2 + term3) - (-a) / (3 * 1);
                }
            }

            if (Delta == 0)
            {
                x1 = x2 = x3 = (-(-a) + Math.Pow((-a), 3) - 27 * Math.Pow(1, 2) * (-c)) / (3 * 1);
            }

            if (Delta < 0)
            {
                double term1 = Math.Sqrt(Math.Abs(Delta)) / (3 * 1);
                double term2 = Math.Pow((k + Math.Sqrt(Math.Pow(k, 2) + 1)), 1 / 3);
                double term3 = Math.Pow((k - Math.Sqrt(Math.Pow(k, 2) + 1)), 1 / 3);
                x1 = x2 = x3 = term1 * (term2 + term3) - (-a) / (3 * 1);
            }

            double sigma_1, sigma_2, sigma_3;

            if (x1 > x2 && x1 > x3)
            {
                sigma_1 = x1;
            }
            else if (x2 > x1 && x2 > x3)
            {
                sigma_1 = x2;
            }
            else
            {
                sigma_1 = x3;
            }

            if (sigma_1 == x1 && x2 > x3)
            {
                sigma_2 = x2;
                sigma_3 = x3;
            }
            else if (sigma_1 == x1 && x3 > x2)
            {
                sigma_2 = x3;
                sigma_3 = x2;
            }
            else if (sigma_1 == x2 && x1 > x3)
            {
                sigma_2 = x1;
                sigma_3 = x3;
            }
            else if (sigma_1 == x2 && x3 > x1)
            {
                sigma_2 = x3;
                sigma_3 = x1;
            }
            else if (sigma_1 == x3 && x1 > x2)
            {
                sigma_2 = x1;
                sigma_3 = x2;
            }
            else
            {
                sigma_2 = x2;
                sigma_3 = x1;
            }

            return new double[] { sigma_1, sigma_2, sigma_3};
        }
    }
}

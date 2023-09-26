using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theory_of_Plasticity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input Stess Tensor");
            double[,] tensor = new double[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine("epsilon_" + (i + 1).ToString() + (j + 1).ToString());
                    tensor[i, j] = Double.Parse(Console.ReadLine());
                }
            }
            double det = Determinant.DeterminantMatrix(tensor);
            double I1 = tensor[0, 0] + tensor[1, 1] + tensor[2, 2];
            double I2 = (tensor[0, 0] * tensor[1, 1] - tensor[0, 1] * tensor[0, 1]) + (tensor[1, 1] * tensor[2, 2] - tensor[1, 2] * tensor[1, 2]) + (tensor[0, 0] * tensor[2, 2] - tensor[2, 0] * tensor[2, 0]);
            double I3 = det;
            Console.WriteLine(I1);
            Console.WriteLine(I2);
            Console.WriteLine(I3);
            double[] mainStress = SolveEquationDegree3.SolveCharacteristicEquation(I1, I2, I3);
            double sigma_1 = 0;
            double sigma_2 = 0;
            double sigma_3 = 0;
            Console.WriteLine("Main Stress");
            for (int i = 0; i < mainStress.Length; i++)
            {
                Console.WriteLine($"sigma_{i + 1} : {mainStress[i]}");
                if (i == 0) sigma_1 = mainStress[i];
                if (i == 1) sigma_2 = mainStress[i];
                if (i == 2) sigma_3 = mainStress[i];
            }
            double[,] system_equation_1 = SystemEquation.systemEquation(tensor, sigma_1);
            double[,] system_equation_2 = SystemEquation.systemEquation(tensor, sigma_2);
            double[,] system_equation_3 = SystemEquation.systemEquation(tensor, sigma_3);

            double[,] first_main_direction = SolveSystemEquation.solveSystemEquation(system_equation_1);
            double[,] second_main_direction = SolveSystemEquation.solveSystemEquation(system_equation_2);
            double[,] third_main_direction = SolveSystemEquation.solveSystemEquation(system_equation_3);

            Console.WriteLine("Main Direction");
            Console.WriteLine("The First Main Direction");
            for (int i = 0; i < first_main_direction.GetLength(0); i++)
            {
                for (int j = 0; j < first_main_direction.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        Console.Write($"{first_main_direction[i, j]} ");
                    }
                    else if (i == 1 && j == 0)
                    {
                        Console.WriteLine();
                        Console.Write($"{first_main_direction[i, j]} ");
                    }
                    else
                        Console.Write($"{first_main_direction[i, j]} ");
                }
            }
            Console.WriteLine();
            Console.WriteLine("The Second Main Direction");
            for (int i = 0; i < second_main_direction.GetLength(0); i++)
            {
                for (int j = 0; j < second_main_direction.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        Console.Write($"{second_main_direction[i, j]} ");
                    }
                    else if (i == 1 && j == 0)
                    {
                        Console.WriteLine();
                        Console.Write($"{second_main_direction[i, j]} ");
                    }
                    else
                        Console.Write($"{second_main_direction[i, j]} ");
                }
            }
            Console.WriteLine();
            Console.WriteLine("The Third Main Direction");
            for (int i = 0; i < third_main_direction.GetLength(0); i++)
            {
                for (int j = 0; j < third_main_direction.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        Console.Write($"{third_main_direction[i, j]} ");
                    }
                    else if (i == 1 && j == 0)
                    {
                        Console.WriteLine();
                        Console.Write($"{third_main_direction[i, j]} ");
                    }
                    else
                        Console.Write($"{third_main_direction[i, j]} ");
                }
            }
            Console.ReadKey();
        }
    }
}

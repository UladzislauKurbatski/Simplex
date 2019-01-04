using System;

namespace Lab._2.NetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] matrix = {{4, 1, 3, 1},
                                {1, 2, 1, 0},
                                {3, 0, 1, 4},
                                {0, -2, -4, -1}};

            double[,] original = new double[matrix.GetLength(0), matrix.GetLength(1)];

            Array.Copy(matrix, original, matrix.Length);

            SimplexMethod smplx = new SimplexMethod(matrix);

            var toBasisLenght = (matrix.GetLength(0) - 1) * 2;

            double[] x = new double[toBasisLenght];

            matrix = smplx.Calculate(x);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
            }

            Console.WriteLine("\n");



            for (int i = 0; i < x.Length; i++)
            {
                Console.WriteLine("x" + (i + 1) + " " + x[i]);
            }


            double func = 0;

            for (int i = matrix.GetLength(0) - 1, j = 1, k = 0; j < original.GetLength(1); j++, k++)
            {
                func += -original[i, j] * x[k];
            }

            Console.WriteLine("Z = " + func);

            Console.Read();
        }
    }
}

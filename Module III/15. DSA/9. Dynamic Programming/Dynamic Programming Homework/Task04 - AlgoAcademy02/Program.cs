using System;
using System.Linq;

namespace Task04___AlgoAcademy02
{
    // 100/100 - my solution
    public class Program
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            int k = numbers[0];
            int n = numbers[1];

            long[,] memory = new long[k + 1, n + 1];

            for (int i = 0; i <= n; i++)
            {
                memory[0, i] = i;
            }

            for (int i = 1; i < k; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    memory[i, j] = memory[i - 1, j] + memory[i, j - 1];
                }
            }

            long result = 0;
            for (int i = 0; i <= n; i++)
            {
                result += memory[k - 1, i];
            }
            Console.WriteLine(result);
            //Print(memory);
        }

        private static void Print(long[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(" " + matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}

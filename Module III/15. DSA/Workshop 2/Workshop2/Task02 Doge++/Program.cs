using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02_Doge__
{
    public class Program
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            int k = dimensions[2];

            string[] enemies = Console.ReadLine().Split(';');

            long[,] matrix = new long[rows, cols];
            for (int i = 0; i < enemies.Length; i++)
            {
                var enemyDimensions = enemies[i].Split();
                var enemyRow = int.Parse(enemyDimensions[0]);
                var enemyCol = int.Parse(enemyDimensions[1]);

                matrix[enemyRow, enemyCol] = -1;
            }

            for (int i = 0; i < cols; i++)
            {
                if (matrix[0, i] != -1)
                {
                    matrix[0, i] = 1;
                }
                else
                {
                    break;
                }
            }

            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, 0] != -1)
                {
                    matrix[i, 0] = 1;
                }
                else
                {
                    break;
                }
            }

            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] != -1)
                    {
                        if (matrix[i - 1, j] != -1)
                        {
                            matrix[i, j] += matrix[i - 1, j];
                        }

                        if (matrix[i, j - 1] != -1)
                        {
                            matrix[i, j] += matrix[i, j - 1];
                        }
                    }
                }
            }

            Console.WriteLine(matrix[rows - 1, cols - 1]);
        }
    }
}

using System;
using System.Linq;
using System.Numerics;

public class Program
{
    public static void Main()
    {
        int[] arr = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
        int rows = arr[0];
        int cols = arr[1];
        BigInteger[,] matrix = new BigInteger[rows, cols];
        
        int[] bone = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
        if (bone[0] == 0 && bone[1] == 0)
        {
            Console.WriteLine(1);
            return;
        }
        matrix[bone[0], bone[1]] = -2;

        int k = int.Parse(Console.ReadLine());

        for (int i = 0; i < k; i++)
        {
            int[] enemy = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            int enemyRow = enemy[0];
            int enemyCol = enemy[1];
            matrix[enemyRow, enemyCol] = -1;
        }

        for (int i = 0; i < cols; i++)
        {
            if (matrix[0, i] >= 0)
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
            if (matrix[i, 0] >= 0)
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
                    if (matrix[i, j] == -2)
                    {
                        if (matrix[i - 1, j] != -1)
                        {
                            matrix[i, j] += matrix[i - 1, j];
                        }

                        if (matrix[i, j - 1] != -1)
                        {
                            matrix[i, j] += matrix[i, j - 1];
                        }

                        Console.WriteLine(matrix[i, j] + 2);
                        return;
                    }

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
    }

    public static void Print(BigInteger[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(string.Format("{0}", matrix[i, j]).PadLeft(3, ' '));
            }

            Console.WriteLine();
        }
    }
}


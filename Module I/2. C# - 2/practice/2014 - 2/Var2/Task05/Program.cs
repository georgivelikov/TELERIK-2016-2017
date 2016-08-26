using System;
using System.Collections.Generic;
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

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int[] coin = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            matrix[coin[0], coin[1]] += 1;
        }

        BigInteger sum = matrix[0, 0];
        for (int i = 1; i < cols; i++)
        {
            matrix[0, i] += matrix[0, i - 1];
        }

        for (int i = 1; i < rows; i++)
        {
            matrix[i, 0] += matrix[i - 1, 0];
        }


        for (int i = 1; i < rows; i++)
        {
            for (int j = 1; j < cols; j++)
            {
                if (matrix[i, j] == 0)
                {
                    matrix[i, j] = BigInteger.Max(matrix[i - 1, j], matrix[i, j - 1]);
                }
                else
                {
                    matrix[i, j] += BigInteger.Max(matrix[i - 1, j], matrix[i, j - 1]);
                }
            }
        }

        Console.WriteLine(matrix[rows - 1, cols - 1]);
    }
}


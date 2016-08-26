using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static int[,] matrix;
    private static int rows;
    private static int cols;
    private static int maxSum = int.MinValue;

    public static void Main()
    {
        int[] dimensions = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
        rows = dimensions[0];
        cols = dimensions[1];

        matrix = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            int[] numbers = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = numbers[j];
            }
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                LargestSum(i, j);
            }
        }

        Console.WriteLine(maxSum);
    }

    private static void LargestSum(int currentRow, int currentCol)
    {
        

        if (currentRow + 2 < rows && currentCol + 2 < cols)
        {
            int currentSum = 0;

            for (int i = currentRow; i <= currentRow + 2; i++)
            {
                for (int j = currentCol; j <= currentCol + 2; j++)
                {
                    currentSum += matrix[i, j];
                }
            }

            if (currentSum > maxSum)
            {
                maxSum = currentSum;
            }
        }
    }
}


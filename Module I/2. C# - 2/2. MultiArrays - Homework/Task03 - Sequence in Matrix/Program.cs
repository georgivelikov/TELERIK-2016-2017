using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static string[,] matrix;
    private static bool[,] boolMatrix;
    private static int rows;
    private static int cols;
    private static int maxSeq = int.MinValue;
    private static string maxNum = "";

    public static void Main()
    {
        int[] dimensions = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
        rows = dimensions[0];
        cols = dimensions[1];

        matrix = new string[rows, cols];
        boolMatrix = new bool[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            string[] inputLine = Console.ReadLine().Split();
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = inputLine[j];
            }
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                FindMaxSequence(i, j);
            }
        }

        Console.WriteLine(maxSeq);
        //Console.WriteLine(maxNum);
    }

    private static void FindMaxSequence(int currentRow, int currentCol)
    {
        if (!boolMatrix[currentRow, currentCol])
        {
            int currentSeq = 1;

            for (int i = currentRow; i < rows - 1; i++)
            {
                if (matrix[i, currentCol] == matrix[i + 1, currentCol])
                {
                    currentSeq++;
                }
                else
                {
                    break;
                }
            }

            if (currentSeq > maxSeq)
            {
                maxSeq = currentSeq;
                maxNum = matrix[currentRow, currentCol];
            }

            currentSeq = 1;

            for (int i = currentRow; i > 0; i--)
            {
                if (matrix[i, currentCol] == matrix[i - 1, currentCol])
                {
                    currentSeq++;
                }
                else
                {
                    break;
                }
            }

            if (currentSeq > maxSeq)
            {
                maxSeq = currentSeq;
                maxNum = matrix[currentRow, currentCol];
            }

            currentSeq = 1;

            for (int i = currentCol; i < cols - 1; i++)
            {
                if (matrix[currentRow, i] == matrix[currentRow, i + 1])
                {
                    currentSeq++;
                }
                else
                {
                    break;
                }
            }

            if (currentSeq > maxSeq)
            {
                maxSeq = currentSeq;
                maxNum = matrix[currentRow, currentCol];
            }

            currentSeq = 1;

            for (int i = currentCol; i > 0; i--)
            {
                if (matrix[currentRow, i] == matrix[currentRow, i - 1])
                {
                    currentSeq++;
                }
                else
                {
                    break;
                }
            }

            if (currentSeq > maxSeq)
            {
                maxSeq = currentSeq;
                maxNum = matrix[currentRow, currentCol];
            }

            currentSeq = 1;

            int row = currentRow;
            int col = currentCol;

            while (row > 0 && col > 0)
            {
                if (matrix[row, col] == matrix[row - 1, col - 1])
                {
                    currentSeq++;
                    row--;
                    col--;
                }
                else
                {
                    break;
                }
            }

            if (currentSeq > maxSeq)
            {
                maxSeq = currentSeq;
                maxNum = matrix[currentRow, currentCol];
            }

            currentSeq = 1;

            row = currentRow;
            col = currentCol;

            while (row > 0 && col < cols - 1)
            {
                if (matrix[row, col] == matrix[row - 1, col + 1])
                {
                    currentSeq++;
                    row--;
                    col++;
                }
                else
                {
                    break;
                }
            }

            if (currentSeq > maxSeq)
            {
                maxSeq = currentSeq;
                maxNum = matrix[currentRow, currentCol];
            }

            currentSeq = 1;

            row = currentRow;
            col = currentCol;

            while (row < rows - 1 && col < cols - 1)
            {
                if (matrix[row, col] == matrix[row + 1, col + 1])
                {
                    currentSeq++;
                    row++;
                    col++;
                }
                else
                {
                    break;
                }
            }

            if (currentSeq > maxSeq)
            {
                maxSeq = currentSeq;
                maxNum = matrix[currentRow, currentCol];
            }

            currentSeq = 1;

            while (row < rows - 1 && col > 0)
            {
                if (matrix[row, col] == matrix[row + 1, col - 1])
                {
                    currentSeq++;
                    row++;
                    col--;
                }
                else
                {
                    break;
                }
            }

            if (currentSeq > maxSeq)
            {
                maxSeq = currentSeq;
                maxNum = matrix[currentRow, currentCol];
            }
        }
    }
}



using System;
using System.Data;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];
        int counter = 1;
        int currentRow = 0;
        int currentCol = 0;
        char direction = 'R';

        while (true)
        {
            if (direction == 'R')
            {
                if (currentCol == n - 1 || matrix[currentRow, currentCol + 1] != 0)
                {
                    matrix[currentRow, currentCol] = counter;
                    counter++;
                    currentRow++;
                    direction = 'D';
                }
                else
                {
                    matrix[currentRow, currentCol] = counter;
                    counter++;
                    currentCol++;
                }

                if (counter > Math.Pow(n, 2))
                {
                    break;
                }
            }

            if (direction == 'L')
            {
                if (currentCol == 0 || matrix[currentRow, currentCol - 1] != 0)
                {
                    matrix[currentRow, currentCol] = counter;
                    counter++;
                    currentRow--;
                    direction = 'U';
                }
                else
                {
                    matrix[currentRow, currentCol] = counter;
                    counter++;
                    currentCol--;
                }

                if (counter > Math.Pow(n, 2))
                {
                    break;
                }
            }

            if (direction == 'D')
            {
                if (currentRow == n - 1 || matrix[currentRow + 1, currentCol] != 0)
                {
                    matrix[currentRow, currentCol] = counter;
                    counter++;
                    currentCol--;
                    direction = 'L';
                }
                else
                {
                    matrix[currentRow, currentCol] = counter;
                    counter++;
                    currentRow++;
                }

                if (counter > Math.Pow(n, 2))
                {
                    break;
                }
            }

            if (direction == 'U')
            {
                if (currentRow == 0 || matrix[currentRow - 1, currentCol] != 0)
                {
                    matrix[currentRow, currentCol] = counter;
                    counter++;
                    currentCol++;
                    direction = 'R';
                }
                else
                {
                    matrix[currentRow, currentCol] = counter;
                    counter++;
                    currentRow--;
                }

                if (counter > Math.Pow(n, 2))
                {
                    break;
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static int[,] matrix;

    private static bool[,] boolMatrix;

    private static int rows;

    private static int cols;

    private static Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();

    private static int maxCounter = int.MinValue;

    public static void Main()
    {
        int[] dimensions = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
        rows = dimensions[0];
        cols = dimensions[1];

        matrix = new int[rows, cols];
        boolMatrix = new bool[rows, cols];

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
                if (!boolMatrix[i, j])
                {
                    int currentCounter = 0;
                    int currentCellValue = matrix[i, j];
                    queue.Enqueue(new Tuple<int, int>(i, j));
                    
                    while (queue.Count > 0)
                    {
                        currentCounter++;
                        var currentCell = queue.Dequeue();
                        int currentCellRow = currentCell.Item1;
                        int currentCellCol = currentCell.Item2;
                        boolMatrix[currentCellRow, currentCellCol] = true;

                        if (CheckValidCell(currentCellRow - 1, currentCellCol))
                        {
                            if (matrix[currentCellRow - 1, currentCellCol] == currentCellValue)
                            {
                                queue.Enqueue(new Tuple<int, int>(currentCellRow - 1, currentCellCol));
                                boolMatrix[currentCellRow - 1, currentCellCol] = true;
                            }
                        }

                        if (CheckValidCell(currentCellRow + 1, currentCellCol))
                        {
                            if (matrix[currentCellRow + 1, currentCellCol] == currentCellValue)
                            {
                                queue.Enqueue(new Tuple<int, int>(currentCellRow + 1, currentCellCol));
                                boolMatrix[currentCellRow + 1, currentCellCol] = true;
                            }
                        }

                        if (CheckValidCell(currentCellRow, currentCellCol - 1))
                        {
                            if (matrix[currentCellRow, currentCellCol - 1] == currentCellValue)
                            {
                                queue.Enqueue(new Tuple<int, int>(currentCellRow, currentCellCol - 1));
                                boolMatrix[currentCellRow, currentCellCol - 1] = true;
                            }
                        }

                        if (CheckValidCell(currentCellRow, currentCellCol + 1))
                        {
                            if (matrix[currentCellRow, currentCellCol + 1] == currentCellValue)
                            {
                                queue.Enqueue(new Tuple<int, int>(currentCellRow, currentCellCol + 1));
                                boolMatrix[currentCellRow, currentCellCol + 1] = true;
                            }
                        }
                    }

                    if (currentCounter > maxCounter)
                    {
                        maxCounter = currentCounter;
                    }

                    //Console.WriteLine(currentCounter);
                    //Print();
                }
            }
        }

        Console.WriteLine(maxCounter);
    }

    private static bool CheckValidCell(int row, int col)
    {
        if (row >= 0 && col >= 0 && row < rows && col < cols)
        {
            if (boolMatrix[row, col])
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }
    }

    private static void Print()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }

            Console.WriteLine();
        }
    }
}


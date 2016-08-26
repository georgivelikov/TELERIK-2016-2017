using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Program
{
    public static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        int row = 0;
        int col = 2;
        int path = 0;
        int max = int.MinValue;
        int[][] matrix = new int[rows][];
        bool[][] boolean = new bool[rows][];
        for (int i = 0; i < rows; i++)
        {
            int[] arr = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            bool[] boolArr = new bool[arr.Length];
            matrix[i] = arr;
            boolean[i] = boolArr;
        }

        for (int i = 0; i < matrix[0].Length; i++)
        {
            col = i;
            row = 0;

            while (true)
            {
                path++;
                if (boolean[row][col])
                {
                    break;
                }
                else
                {
                    boolean[row][col] = true;
                    if (matrix[row][col] < 0)
                    {
                        path += Math.Abs(matrix[row][col]);
                        break;
                    }
                    else
                    {
                        col = matrix[row][col];
                        row++;
                        if (row == rows)
                        {
                            row = 0;
                        }
                    }
                }
            }

            if (path > max)
            {
                max = path;
            }

            path = 0;
            for (int j = 0; j < rows; j++)
            {
                bool[] boolArr = new bool[matrix[j].Length];
                boolean[j] = boolArr;
            }
        }
        

        Console.WriteLine(max);
    }
}


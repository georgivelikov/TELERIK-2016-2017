using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class Program
{
    public static void Main()
    {
        char[,] matrix =
            {
                { 'r', 'b', 'r' }, 
                { 'b', 'g', 'b' }, 
                { 'r', 'b', 'r' }
            };

        int row = 1;
        int col = 1;
        char dir = 'L';
        

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            char[] commands = Console.ReadLine().ToCharArray();
            for (int j = 0; j < commands.Length; j++)
            {
                char c = commands[j];
                if (c == 'L')
                {
                    if (dir == 'L')
                    {
                        dir = 'D';
                    }
                    else if (dir == 'R')
                    {
                        dir = 'U';
                    }
                    else if (dir == 'U')
                    {
                        dir = 'L';
                    }
                    else if (dir == 'D')
                    {
                        dir = 'R';
                    }
                }
                else if (c == 'R')
                {
                    if (dir == 'L')
                    {
                        dir = 'U';
                    }
                    else if (dir == 'R')
                    {
                        dir = 'D';
                    }
                    else if (dir == 'U')
                    {
                        dir = 'R';
                    }
                    else if (dir == 'D')
                    {
                        dir = 'L';
                    }
                }
                else // W
                {
                    if (dir == 'L')
                    {
                        col--;
                    }
                    else if (dir == 'R')
                    {
                        col++;
                    }
                    else if (dir == 'U')
                    {
                        row--;
                    }
                    else if (dir == 'D')
                    {
                        row++;
                    }

                    if (row == -1)
                    {
                        row = 2;
                    }

                    if (row == 3)
                    {
                        row = 0;
                    }

                    if (col == -1)
                    {
                        col = 2;
                    }

                    if (col == 3)
                    {
                        col = 0;
                    }
                }
            }

            if (matrix[row, col] == 'g')
            {
                Console.WriteLine("GREEN");
            }
            else if (matrix[row, col] == 'r')
            {
                Console.WriteLine("RED");
            }
            else if (matrix[row, col] == 'b')
            {
                Console.WriteLine("BLUE");
            }

            row = 1;
            col = 1;
        }
    }
}


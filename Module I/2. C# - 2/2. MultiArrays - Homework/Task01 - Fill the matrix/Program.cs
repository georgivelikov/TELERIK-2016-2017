using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01___Fill_the_matrix
{
 

    class Program
    {
        private static int[,] matrix;

        private static int n;

        private static int counter = 1;

        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            matrix = new int[n, n];
            string symbol = Console.ReadLine();

            switch (symbol)
            {
                case "a":
                    BuildA();
                    break;
                case "b":
                    BuildB();
                    break;
                case "c":
                    BuildC();
                    break;
                case "d":
                    BuildD();
                    break;
            }

            Print();
        }

        static void BuildA()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[j, i] = counter;
                    counter++;
                }
            }
        }

        static void BuildB()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i % 2 == 0)
                    {
                        matrix[j, i] = counter;
                        counter++;
                    }
                    else
                    {
                        matrix[n - 1 - j, i] = counter;
                        counter++;
                    }
                }
            }
        }

        static void BuildC()
        {
            int startRow = n - 1;
            int startCol = 1;
            int currentRow;
            int currentCol;
            int finalCol;

            for (int i = startRow; i >= 0; i--)
            {
                currentRow = i;
                currentCol = 0;
                finalCol = n - 1 - i;
                while (finalCol > -1)
                {
                    matrix[currentRow, currentCol] = counter;
                    counter++;
                    currentRow++;
                    currentCol++;
                    finalCol--;
                }
            }

            startRow = 0;

            for (int i = startCol; i < n; i++)
            {
                currentRow = 0;
                currentCol = i;
                finalCol = n - 1 - i;
                while (finalCol > -1)
                {
                    matrix[currentRow, currentCol] = counter;
                    counter++;
                    currentRow++;
                    currentCol++;
                    finalCol--;
                } 
            }
        }

        static void BuildD()
        {
            int counterForD = 0;
            int row = 0;
            int col = 0;
            int rowCount = n;
            int colCount = n - 1;
            string direction = "down";

            while (counter < n * n + 1)
            {
                while (direction == "right" && counter < n * n + 1)
                {
                    matrix[row, col] = counter;
                    counter++;
                    counterForD++;
                    if (counterForD == colCount)
                    {
                        direction = "up";
                        colCount--;
                        row--;
                        counterForD = 0;
                        break;
                    }

                    col++;
                }

                while (direction == "down" && counter < n * n + 1)
                {
                    matrix[row, col] = counter;
                    counter++;
                    counterForD++;
                    if (counterForD == rowCount)
                    {
                        direction = "right";
                        rowCount--;
                        counterForD = 0;
                        col++;
                        break;
                    }

                    row++;
                }

                while (direction == "left" && counter < n * n + 1)
                {
                    matrix[row, col] = counter;
                    counter++;
                    counterForD++;
                    if (counterForD == colCount)
                    {
                        direction = "down";
                        colCount--;
                        row++;
                        counterForD = 0;
                        break;
                    }

                    col--;
                }

                while (direction == "up" && counter < n * n + 1)
                {
                    matrix[row, col] = counter;
                    counter++;
                    counterForD++;
                    if (counterForD == rowCount)
                    {
                        direction = "left";
                        rowCount--;
                        col--;
                        counterForD = 0;
                        break;
                    }

                    row--;
                }
            }
        }

        static void Print()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j != n - 1)
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                    else
                    {
                        Console.Write(matrix[i, j]);
                    }
                    
                }

                Console.WriteLine();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    public class Program
    {
        private static int currentRow;
        private static int currentCol;
        private static int sum = 0;

        public static void Main(string[] args)
        {

            string[] dimensions = Console.ReadLine().Split();
            int rows = int.Parse(dimensions[0]);
            int cols = int.Parse(dimensions[1]);

            currentRow = rows - 1;
            currentCol = 0;

            int[,] matrix = new int[rows, cols];
            bool[,] checkerMatrix = new bool[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                int startingValue = (rows - 1 - i) * 3;
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = startingValue;
                    startingValue += 3;
                }
            }

            int numberOfMoves = int.Parse(Console.ReadLine());
            string[] commands = new string[numberOfMoves];
            for (int i = 0; i < numberOfMoves; i++)
            {
                commands[i] = Console.ReadLine();
            }

            foreach (string command in commands)
            {
                string[] commandArgs = command.Split();
                string direction = commandArgs[0];
                int moves = int.Parse(commandArgs[1]);

                switch (direction)
                {
                    case "UR":
                        MoveRightUp(matrix, rows, cols, moves, checkerMatrix);
                        break;
                    case "RU":
                        MoveRightUp(matrix, rows, cols, moves, checkerMatrix);
                        break;
                    case "RD":
                        MoveRightDown(matrix, rows, cols, moves, checkerMatrix);
                        break;
                    case "DR":
                        MoveRightDown(matrix, rows, cols, moves, checkerMatrix);
                        break;
                    case "LD":
                        MoveLeftDown(matrix, rows, cols, moves, checkerMatrix);
                        break;
                    case "DL":
                        MoveLeftDown(matrix, rows, cols, moves, checkerMatrix);
                        break;
                    case "LU":
                        MoveLeftUp(matrix, rows, cols, moves, checkerMatrix);
                        break;
                    case "UL":
                        MoveLeftUp(matrix, rows, cols, moves, checkerMatrix);
                        break;
                }
            }

            Console.WriteLine(sum);


            //Print(matrix);
        }

        private static void MoveRightUp(int[,] matrix, int rows, int cols, int moves, bool[,] checkerMatrix)
        {
            for (int i = 0; i < moves; i++)
            {
                if (currentRow == 0 || currentCol == cols - 1)
                {
                    if (!checkerMatrix[currentRow, currentCol])
                    {
                        checkerMatrix[currentRow, currentCol] = true;
                        sum += matrix[currentRow, currentCol];
                    }

                    return;
                }

                if (!checkerMatrix[currentRow, currentCol])
                {
                    checkerMatrix[currentRow, currentCol] = true;
                    sum += matrix[currentRow, currentCol];
                }

                if (i != moves - 1)
                {
                    currentRow--;
                    currentCol++;
                }
            }
        }

        private static void MoveLeftUp(int[,] matrix, int rows, int cols, int moves, bool[,] checkerMatrix)
        {
            for (int i = 0; i < moves; i++)
            {
                if (currentRow == 0 || currentCol == 0)
                {
                    if (!checkerMatrix[currentRow, currentCol])
                    {
                        checkerMatrix[currentRow, currentCol] = true;
                        sum += matrix[currentRow, currentCol];
                    }

                    return;
                }

                if (!checkerMatrix[currentRow, currentCol])
                {
                    checkerMatrix[currentRow, currentCol] = true;
                    sum += matrix[currentRow, currentCol];
                }

                if (i != moves - 1)
                {
                    currentRow--;
                    currentCol--;
                }
            }
        }

        private static void MoveRightDown(int[,] matrix, int rows, int cols, int moves, bool[,] checkerMatrix)
        {
            for (int i = 0; i < moves; i++)
            {
                if (currentRow == rows - 1 || currentCol == cols - 1)
                {
                    if (!checkerMatrix[currentRow, currentCol])
                    {
                        checkerMatrix[currentRow, currentCol] = true;
                        sum += matrix[currentRow, currentCol];
                    }

                    return;
                }

                if (!checkerMatrix[currentRow, currentCol])
                {
                    checkerMatrix[currentRow, currentCol] = true;
                    sum += matrix[currentRow, currentCol];
                }

                if (i != moves - 1)
                {
                    currentRow++;
                    currentCol++;
                }
            }
        }

        private static void MoveLeftDown(int[,] matrix, int rows, int cols, int moves, bool[,] checkerMatrix)
        {
            for (int i = 0; i < moves; i++)
            {
                if (currentRow == rows - 1 || currentCol == 0)
                {
                    if (!checkerMatrix[currentRow, currentCol])
                    {
                        checkerMatrix[currentRow, currentCol] = true;
                        sum += matrix[currentRow, currentCol];
                    }

                    return;
                }

                if (!checkerMatrix[currentRow, currentCol])
                {
                    checkerMatrix[currentRow, currentCol] = true;
                    sum += matrix[currentRow, currentCol];
                }

                if (i != moves - 1)
                {
                    currentRow++;
                    currentCol--;
                }
            }
        }

        private static void Print(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}

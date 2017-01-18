using System;
using System.Collections.Generic;

namespace Task14
{
    public class Program
    {
        private static string[,] matrix;

        private static bool[,] booleanMatrix;

        private static int counter = 0;

        public static void Main()
        {
            matrix = new string[,]
            {
                { "0", "0", "0", "x", "0", "x" },
                { "0", "x", "0", "x", "0", "x" },
                { "0", "*", "x", "0", "0", "0" },
                { "0", "x", "0", "F", "0", "0" },
                { "0", "0", "0", "0", "x", "0" },
                { "0", "x", "0", "x", "0", "x" },
            };

            booleanMatrix = new bool[matrix.GetLength(0), matrix.GetLength(1)];

            int startRow = 2;
            int startCol = 1;

            Cell startingCell = new Cell(startRow, startCol);

            FindPath(startingCell);

            Console.WriteLine(counter);
        }

        private static void FindPath(Cell cell)
        {
            var currentRow = cell.Row;
            var currentCol = cell.Col;

            if (!IsCellValid(currentRow, currentCol))
            {
                return;
            }

            if (matrix[currentRow, currentCol] == "F")
            {
                counter++;
                return;
            }

            booleanMatrix[currentRow, currentCol] = true;
            FindPath(new Cell(currentRow + 1, currentCol));
            FindPath(new Cell(currentRow - 1, currentCol));
            FindPath(new Cell(currentRow, currentCol + 1));
            FindPath(new Cell(currentRow, currentCol - 1));
            booleanMatrix[currentRow, currentCol] = false;
        }

        public class Cell
        {
            public Cell(int row, int col)
            {
                this.Row = row;
                this.Col = col;
            }

            public int Row { get; set; }

            public int Col { get; set; }
        }

        private static bool IsCellValid(int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1) || matrix[row, col] == "x" || booleanMatrix[row, col])
            {
                return false;
            }

            return true;
        }

        private static void PrintMatrix()
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

using System;
using System.Collections.Generic;
using System.Linq;

namespace Task14
{
    public class Program
    {
        private static string[,] matrix;

        private static int startRow = 0;
    
        private static int startCol = 0;

        private static int currentSymbol = 1;

        private static int currentCounter = 0;

        private static SortedDictionary<int, int> resultHolder = new SortedDictionary<int, int>();

        public static void Main()
        {
            matrix = new string[,]
            {
                { "0", "0", "0", "x", "0", "x" },
                { "0", "x", "0", "x", "X", "x" },
                { "0", "0", "x", "0", "0", "0" },
                { "0", "x", "0", "0", "x", "x" },
                { "0", "0", "0", "0", "x", "0" },
                { "0", "x", "0", "x", "0", "0" },
            };

            while (IsThereEmptyCell())
            {
                Cell startingCell = new Cell(startRow, startCol);
                FindPath(startingCell);
                resultHolder.Add(currentCounter, currentSymbol);

                currentCounter = 0;
                currentSymbol++;
            }

            PrintMatrix();

            Console.WriteLine("Largest connected area consists of {0} cells, marked with symbol {1}!", resultHolder.Keys.Max(), resultHolder[resultHolder.Keys.Max()]);
        }

        private static bool IsThereEmptyCell()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == "0")
                    {
                        startRow = i;
                        startCol = j;
                        return true;
                    }
                }
            }

            return false;
        }

        private static void FindPath(Cell cell)
        {
            var currentRow = cell.Row;
            var currentCol = cell.Col;

            if (!IsCellValid(currentRow, currentCol))
            {
                return;
            }

            matrix[currentRow, currentCol] = currentSymbol.ToString();
            currentCounter++;

            FindPath(new Cell(currentRow + 1, currentCol));
            FindPath(new Cell(currentRow - 1, currentCol));
            FindPath(new Cell(currentRow, currentCol + 1));
            FindPath(new Cell(currentRow, currentCol - 1));
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
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1) || matrix[row, col] != "0")
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

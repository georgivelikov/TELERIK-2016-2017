using System;
using System.Collections.Generic;

namespace Task14
{
    public class Program
    {
        private static string[,] matrix;

        public static void Main()
        {
            matrix = new string[,] 
            { 
                { "0", "0", "0", "x", "0", "x" },
                { "0", "x", "0", "x", "0", "x" },
                { "0", "*", "x", "0", "x", "0" },
                { "0", "x", "0", "0", "0", "0" },
                { "0", "0", "0", "x", "x", "0" },
                { "0", "0", "0", "x", "0", "x" },
            };

            int startRow = 2;
            int startCol = 1;

            Cell startingCell = new Cell(startRow, startCol, 0);

            var queue = new Queue<Cell>();

            queue.Enqueue(startingCell);

            while (queue.Count != 0)
            {
                var currentCell = queue.Dequeue();
                var currentRow = currentCell.Row;
                var currentCol = currentCell.Col;
                var currentCounter = currentCell.Counter;

                if (matrix[currentRow, currentCol] != "*")
                {
                    currentCounter++;
                    matrix[currentRow, currentCol] = currentCounter.ToString();
                }

                if (IsCellValid(currentRow + 1, currentCol))
                {
                    var cell = new Cell(currentRow + 1, currentCol, currentCounter);
                    queue.Enqueue(cell);
                }

                if (IsCellValid(currentRow - 1, currentCol))
                {
                    var cell = new Cell(currentRow - 1, currentCol, currentCounter);
                    queue.Enqueue(cell);
                }

                if (IsCellValid(currentRow, currentCol + 1))
                {
                    var cell = new Cell(currentRow, currentCol + 1, currentCounter);
                    queue.Enqueue(cell);
                }

                if (IsCellValid(currentRow, currentCol - 1))
                {
                    var cell = new Cell(currentRow, currentCol - 1, currentCounter);
                    queue.Enqueue(cell);
                }
            }

            PrintMatrix();
        }

        public class Cell
        {
            public Cell(int row, int col, int counter)
            {
                this.Row = row;
                this.Col = col;
                this.Counter = counter;
            }

            public int Row { get; set; }

            public int Col { get; set; }

            public int Counter { get; set; }
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
                    if (matrix[i, j] == "0")
                    {
                        matrix[i, j] = "u";
                    }

                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}

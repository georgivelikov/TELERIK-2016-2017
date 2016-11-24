using System;

namespace Task12
{
    public class Program
    {
        private static Cell[,] board;

        private static int counter;

        private static int n;

        private static int[] deltaRow = { 1, -1, 0, 0, 1, -1, -1, 1 };

        private static int[] deltaCol = { 0, 0, -1, 1, 1, 1, -1, -1 };

        public static void Main()
        {
            // n = int.Parse(Console.ReadLine());
		
	    n = 8;

            board = new Cell[n, n];

            PlaceCellsCoordinates();
            
            PlaceQueen(0);

            Console.WriteLine(counter);
        }

        private static void PlaceQueen(int row)
        {
            if (row == n)
            {
                counter++;
                return;
            }

            for (int col = 0; col < n; col++)
            {
                if (CanPlaceQueen(board[row, col]))
                {
                    board[row, col].Taken = true;
                    PlaceQueen(row + 1);
                    board[row, col].Taken = false;
                }
            }
        }

        private static bool CanPlaceQueen(Cell cell)
        {
            for (int k = 0; k < 8; k++)
            {
                int dirRow = deltaRow[k];
                int dirCol = deltaCol[k];

                var currentRow = cell.Row + dirRow;
                var currentCol = cell.Col + dirCol;

                while (IsInBoard(currentRow, currentCol))
                {
                    if (board[currentRow, currentCol].Taken)
                    {
                        return false;
                    }

                    currentRow += dirRow;
                    currentCol += dirCol;
                }
            }

            return true;
        }

        private static bool IsInBoard(int row, int col)
        {
            if (row < 0 || row >= board.GetLength(0) || col < 0 || col >= board.GetLength(1))
            {
                return false;
            }

            return true;
        }

        private class Cell
        {
            public Cell(int row, int col)
            {
                this.Row = row;
                this.Col = col;
                this.Taken = false;
            }

            public int Row { get; set; }

            public int Col { get; set; }

            public bool Taken { get; set; }
        }

        private static void PlaceCellsCoordinates()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    board[i, j] = new Cell(i, j);
                }
            }
        }
    }
}

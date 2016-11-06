namespace WalkInMatrix
{
	using System;
	using System.Collections.Generic;
	using System.Text;

	using global::WalkInMatrix.Contracts;

    public class WalkInMatrix
	{
		// All possible directions
		private static readonly Tuple<int, int> Up = new Tuple<int, int>(-1, 0);
		private static readonly Tuple<int, int> RightUp = new Tuple<int, int>(-1, 1);
		private static readonly Tuple<int, int> Right = new Tuple<int, int>(0, 1);
		private static readonly Tuple<int, int> RightDown = new Tuple<int, int>(1, 1);
		private static readonly Tuple<int, int> Down = new Tuple<int, int>(1, 0);
		private static readonly Tuple<int, int> LeftDown = new Tuple<int, int>(1, -1);
		private static readonly Tuple<int, int> Left = new Tuple<int, int>(0, -1);
		private static readonly Tuple<int, int> LeftUp = new Tuple<int, int>(-1, -1);
        
		public static Tuple<int, int> ChangeDirection(int[,] matrix, int currentX, int currentY, List<Tuple<int, int>> listOfPossibleDirections)
		{
			for (int i = 0; i < listOfPossibleDirections.Count; i++)
			{
				if (ValidateDirection(matrix, currentX, currentY, listOfPossibleDirections[i]))
				{
					return listOfPossibleDirections[i];
				}
			}

			return null; // Method returns null means than there are no available directions left and should seek for nearest empty cell
		}

		public static List<Tuple<int, int>> GenerateListOfPossibleDirections(Tuple<int, int> currentDirection)
		{
			// direction is rightDown
			if (currentDirection == null || (currentDirection.Item1 == 1 && currentDirection.Item2 == 1))
			{
				return new List<Tuple<int, int>>
							{
								Down, LeftDown, Left, LeftUp, Up, RightUp, Right
							};
			}

			// direction is down
			if (currentDirection.Item1 == 1 && currentDirection.Item2 == 0)
			{
				return new List<Tuple<int, int>>
							{
								LeftDown, Left, LeftUp, Up, RightUp, Right, RightDown
							};
			}

			// direction is leftDown
			if (currentDirection.Item1 == 1 && currentDirection.Item2 == -1)
			{
				return new List<Tuple<int, int>>
							{
								Left, LeftUp, Up, RightUp, Right, RightDown, Down
							};
			}

			// direction is left
			if (currentDirection.Item1 == 0 && currentDirection.Item2 == -1)
			{
				return new List<Tuple<int, int>>
							{
								LeftUp, Up, RightUp, Up, Right, RightDown, Down, LeftDown
							};
			}

			// direction is leftUp
			if (currentDirection.Item1 == -1 && currentDirection.Item2 == -1)
			{
				return new List<Tuple<int, int>>
							{
								Up, RightUp, Up, Right, RightDown, Down, LeftDown, Left
							};
			}

			// direction is up
			if (currentDirection.Item1 == -1 && currentDirection.Item2 == 0)
			{
				return new List<Tuple<int, int>>
							{
								RightUp, Right, RightDown, Down, LeftDown, Left, LeftUp
							};
			}

			// direction is rightUp
			if (currentDirection.Item1 == -1 && currentDirection.Item2 == 1)
			{
				return new List<Tuple<int, int>>
							{
								Right, RightDown, Down, LeftDown, Left, LeftUp, Up
							};
			}

			// direction is right
			if (currentDirection.Item1 == 0 && currentDirection.Item2 == 1)
			{
				return new List<Tuple<int, int>>
							{
								RightDown, Down, LeftDown, Left, LeftUp, Up, RightUp
							};
			}

			return null;
		}

		public static Tuple<int, int> FindNearestEmptyCell(int[,] matrix)
		{
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					if (matrix[i, j] == 0)
					{
						Tuple<int, int> cellCoordinate = new Tuple<int, int>(i, j);
						return cellCoordinate;
					}
				}
			}

			return null;
		}

		public static bool ValidateDirection(int[,] matrix, int currentRow, int currentCol, Tuple<int, int> direction)
		{
			int rowLimit = matrix.GetLength(0);
			int colLimit = matrix.GetLength(1);

			// Check if direction is in the boundary of the matrix
			if (currentRow + direction.Item1 < rowLimit &&
				currentCol + direction.Item2 < colLimit &&
				currentRow + direction.Item1 >= 0 &&
				currentCol + direction.Item2 >= 0)
			{
				// Check if cell is empty
				if (matrix[currentRow + direction.Item1, currentCol + direction.Item2] == 0)
				{
					return true;
				}
			}

			return false;
		}

		public static void PrintMatrix(int[,] matrix, IWriter writer)
		{
            StringBuilder sb = new StringBuilder();
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					sb.Append(string.Format("{0,2} ", matrix[i, j]));
				}

				sb.AppendLine();
			}

		    writer.WriteLine(sb.ToString());
		}

		public static void Main()
		{
			const int StartingNumber = 1;
			const int StartingRow = 0;
			const int StartingCol = 0;
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();

		    writer.WriteLine("Please enter number of rows & cols: ");
		    int n = int.Parse(reader.ReadLine());

			int[,] matrix = new int[n, n];
			int row = StartingRow;
			int col = StartingCol;
			int numberCounter = StartingNumber;
			Tuple<int, int> currentDirection = new Tuple<int, int>(1, 1); // Starting direction is rightDown

			while (true)
			{
				matrix[row, col] = numberCounter;
				numberCounter++;
				if (!ValidateDirection(matrix, row, col, currentDirection))
				{
					var listOfPossibleDirections = GenerateListOfPossibleDirections(currentDirection);

					currentDirection = ChangeDirection(matrix, row, col, listOfPossibleDirections);

                    if (currentDirection == null) // all neighbour cells are filled
                    {
                        var newStartingCell = FindNearestEmptyCell(matrix);

                        if (newStartingCell == null) // all cells are filled
                        {
							break;
						}

						row = newStartingCell.Item1;
						col = newStartingCell.Item2;
						currentDirection = ChangeDirection(matrix, row, col, listOfPossibleDirections);
					}
					else
					{
						row += currentDirection.Item1;
						col += currentDirection.Item2;
					}
				}
				else
				{
					row += currentDirection.Item1; // direction.Item1 represent X coodinate change
					col += currentDirection.Item2; // direction.Item2 represent Y coodinate change
				}
			}

			PrintMatrix(matrix, writer);
		}
	}
}

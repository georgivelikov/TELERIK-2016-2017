namespace WalkInMatrixTests
{
	using System;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using WalkInMatrix;

	[TestClass]
	public class WalkInMatrixTests
	{
		[TestMethod]
		public void Test_ValidateDirection_WhenMatrixBorderIsReached()
		{
			var matrix = new int[,]
							{
								{ 1, 0, 0, 0, 0 }, 
								{ 0, 2, 0, 0, 0 }, 
								{ 0, 0, 3, 0, 0 }, 
								{ 0, 0, 0, 4, 0 }, 
								{ 9, 8, 7, 6, 5 }
							};

			Tuple<int, int> currentDirection = new Tuple<int, int>(0, -1); // Current direction is left

			// Current position is matrx[4,0]
			int currentRow = 4;
			int currentCol = 0;

			bool isDirectionPossible = WalkInMatrix.ValidateDirection(matrix, currentRow, currentCol, currentDirection);

			Assert.AreEqual(isDirectionPossible, false, "Direction is impossible");
		}

		[TestMethod]
		public void Test_ValidateDirection_WhenNonEmptyCellIsReached()
		{
			var matrix = new int[,]
							{
								{ 1, 0, 0, 0, 0 }, 
								{ 12, 2, 0, 0, 0 }, 
								{ 11, 0, 3, 0, 0 }, 
								{ 10, 0, 0, 4, 0 }, 
								{ 9, 8, 7, 6, 5 }
							};

			Tuple<int, int> currentDirection = new Tuple<int, int>(-1, 0); // Current direction is up

			// Current position is matrx[1,0]
			int currentRow = 1;
			int currentCol = 0;

			bool isDirectionPossible = WalkInMatrix.ValidateDirection(matrix, currentRow, currentCol, currentDirection);

			Assert.AreEqual(isDirectionPossible, false, "Direction is impossible");
		}

		[TestMethod]
		public void Test_GenerateListOfPossibleDirections_ReturnsCorrectListOfDirectionsToMove()
		{
			var matrix = new int[,]
							{
								{ 1, 0, 0, 0, 0 }, 
								{ 12, 2, 0, 0, 0 }, 
								{ 11, 0, 3, 0, 0 }, 
								{ 10, 0, 0, 4, 0 }, 
								{ 9, 8, 7, 6, 5 }
							};

			Tuple<int, int> currentDirection = new Tuple<int, int>(-1, 0); // Current direction is up
			
			// Generate list of seven possible direcitons starting clockwise
			// Example: 
			// If current direction is Up the list should start with RightUp, than Right etc.
			// If current direction is LeftDown the list shold start with Left, than LeftUp etc.
			var listOfPossibleDirections = WalkInMatrix.GenerateListOfPossibleDirections(currentDirection);

			Tuple<int, int> firstExpectedDirection = new Tuple<int, int>(-1, 1); // RightUp
			Tuple<int, int> secondExpectedDirection = new Tuple<int, int>(0, 1); // Right
			Tuple<int, int> thirdExpectedDirection = new Tuple<int, int>(1, 1); // RightDown
			Tuple<int, int> fourthExpectedDirection = new Tuple<int, int>(1, 0); // Down
			Tuple<int, int> fifthExpectedDirection = new Tuple<int, int>(1, -1); // LeftDown
			Tuple<int, int> sixthExpectedDirection = new Tuple<int, int>(0, -1); // Left
			Tuple<int, int> seventhExpectedDirection = new Tuple<int, int>(-1, -1); // LeftUp

			Assert.AreEqual(listOfPossibleDirections[0], firstExpectedDirection, "Direction is should be Right Up");
			Assert.AreEqual(listOfPossibleDirections[1], secondExpectedDirection, "Direction is should be Right");
			Assert.AreEqual(listOfPossibleDirections[2], thirdExpectedDirection, "Direction is should be Right Down");
			Assert.AreEqual(listOfPossibleDirections[3], fourthExpectedDirection, "Direction is should be Down");
			Assert.AreEqual(listOfPossibleDirections[4], fifthExpectedDirection, "Direction is should be Down Left");
			Assert.AreEqual(listOfPossibleDirections[5], sixthExpectedDirection, "Direction is should be Left");
			Assert.AreEqual(listOfPossibleDirections[6], seventhExpectedDirection, "Direction is should be Left Up");
		}

		[TestMethod]
		public void Test_ChangeDirection_ReturnsFirstPosibleDirectionClockwise()
		{
			var matrix = new int[,]
							{
								{ 1, 0, 0, 0, 0 }, 
								{ 12, 2, 0, 0, 0 }, 
								{ 11, 0, 3, 0, 0 }, 
								{ 10, 0, 0, 4, 0 }, 
								{ 9, 8, 7, 6, 5 }
							};

			Tuple<int, int> currentDirection = new Tuple<int, int>(-1, 0); // Current direction is up

			// Current position is matrx[1,0]
			int currentRow = 1;
			int currentCol = 0;

			var listOfPossibleDirections = WalkInMatrix.GenerateListOfPossibleDirections(currentDirection);
			var expectedDirection = new Tuple<int, int>(-1, 1); // Expected direction is Right Up
			var resultedDirection = WalkInMatrix.ChangeDirection(matrix, currentRow, currentCol, listOfPossibleDirections);

			Assert.AreEqual(resultedDirection, expectedDirection, "Direction should be Right Up");
		}

		[TestMethod]
		public void Test_ChangeDirection_ToReturnNull_WhenNoChangesArePossible()
		{
			var matrix = new int[,]
							{
								{ 1, 13, 0, 0, 0 }, 
								{ 12, 2, 0, 0, 0 }, 
								{ 11, 14, 3, 0, 0 }, 
								{ 10, 0, 0, 4, 0 }, 
								{ 9, 8, 7, 6, 5 }
							};

			Tuple<int, int> currentDirection = new Tuple<int, int>(-1, 0); // Current direction is up

			// Current position is matrx[1,0]
			int currentRow = 1;
			int currentCol = 0;

			var listOfPossibleDirections = WalkInMatrix.GenerateListOfPossibleDirections(currentDirection);
			Tuple<int, int> expectedDirection = null; // Expected direction is null, because all neighbour cells are filled
			var resultedDirection = WalkInMatrix.ChangeDirection(matrix, currentRow, currentCol, listOfPossibleDirections);

			Assert.AreEqual(resultedDirection, expectedDirection, "There are no possible changes of direction to neighbour cells");
		}

		[TestMethod]
		public void Test_FindNearestEmptyCell_ToReturnNearestEmptyCell_WhenAllNeighbourCellsAreFilled()
		{
			var matrix = new int[,]
							{
								{ 1, 13, 0, 0, 0 }, 
								{ 12, 2, 0, 0, 0 }, 
								{ 11, 14, 3, 0, 0 }, 
								{ 10, 0, 0, 4, 0 }, 
								{ 9, 8, 7, 6, 5 }
							};

			// Current position is matrx[1,0]
			Tuple<int, int> expectedLocation = new Tuple<int, int>(0, 2); // Nearest empty cell on smallest possible row is matrix[0, 2]
			var resultedLocation = WalkInMatrix.FindNearestEmptyCell(matrix);

			Assert.AreEqual(resultedLocation, expectedLocation, "Expected location is no equal to resulted location");
		}
	}
}

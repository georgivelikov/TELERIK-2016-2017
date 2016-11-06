using System;

namespace Task_02
{
    public class StartUp
    {
        public static void Main()
        {
            //Part 1
            var potato = new Potato();
            potato.IsPeeled = true;

            if (potato == null)
            {
                throw new ArgumentNullException("Potato can not be null!");
            }

            if (potato.IsRotten)
            {
                throw new InvalidOperationException("Can not cook the potato because it is rotten!");
            }

            if (!potato.IsPeeled)
            {
                throw new InvalidOperationException("Can not cook the potato because it is not peeled!");
            }

            Cook(potato);

            // Part 2
            int currentRow = 1;
            int currentCol = 2;

            int totalRows = 5;
            int totalCols = 5;

            bool[,] visitedMatrix = new bool[totalRows, totalCols];

            if (currentRow >= 0 && currentRow < totalRows 
                && currentCol >= 0 && currentCol < totalCols
                && !visitedMatrix[currentRow, currentCol])
            {
                VisitCell(currentRow, currentCol, visitedMatrix);
            }

            // Expected to be true
            Console.WriteLine(visitedMatrix[currentRow, currentCol]);
        }

        public static void Cook(Potato potato)
        {
            Console.WriteLine("I am cooking the potato");
        }

        public static void VisitCell(int currentRow, int currentCol, bool[,] visitedMatrix)
        {
            Console.WriteLine("Cell visited!");
            visitedMatrix[currentRow, currentCol] = true;

        }
    }
}

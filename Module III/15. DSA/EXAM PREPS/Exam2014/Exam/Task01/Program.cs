using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    public class Program
    {
        private static bool[,] visited;
        private static string[,] matrix;
        //private static int currentRow;
        //private static int currentCol;
        private static long currentCounter;
        private static long maxCounter;
        private static int rows;
        private static int cols;

        public static void Main()
        {
            int[] start = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int currentRow = start[0];
            int currentCol = start[1];

            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            rows = dimensions[0];
            cols = dimensions[1];
            matrix = new string[rows, cols];
            visited = new bool[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] line = Console.ReadLine().Split();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            Teleport(currentRow, currentCol);
            Console.WriteLine(maxCounter);
        }

        private static void Teleport(int currentRow, int currentCol)
        {
            visited[currentRow, currentCol] = true;

            int currentVal = int.Parse(matrix[currentRow, currentCol]);
            currentCounter += currentVal;
            bool canUse = false;
            if(CheckIfValid(currentRow - currentVal, currentCol))
            {
                Teleport(currentRow - currentVal, currentCol);
            }
            if (CheckIfValid(currentRow + currentVal, currentCol))
            {
                Teleport(currentRow + currentVal, currentCol);
            }
            if (CheckIfValid(currentRow, currentCol - currentVal))
            {
                Teleport(currentRow, currentCol - currentVal);
            }
            if (CheckIfValid(currentRow, currentCol + currentVal))
            {
                Teleport(currentRow, currentCol + currentVal);
            }

            if (currentRow + currentVal < rows)
            {
                if(matrix[currentRow + currentVal, currentCol] != "#")
                {
                    canUse = true;
                }
            }
            else if (currentRow - currentVal >= 0)
            {
                if (matrix[currentRow - currentVal, currentCol] != "#")
                {
                    canUse = true;
                }
            }
            else if (currentCol - currentVal >= 0)
            {
                if (matrix[currentRow, currentCol - currentVal] != "#")
                {
                    canUse = true;
                }
            }
            else if (currentCol + currentVal < cols)
            {
                if (matrix[currentRow, currentCol + currentVal] != "#")
                {
                    canUse = true;
                }
            }
            else
            {
                canUse = false;
            }
            if (currentCounter > maxCounter && canUse)
            {
                maxCounter = currentCounter;
                //Console.WriteLine(currentRow + " " + currentCol + " " + maxCounter);
            }
            currentCounter -= currentVal;
            visited[currentRow, currentCol] = false;
        }

        private static bool CheckIfValid(int currentRow, int currentCol)
        {
            if (currentRow >= rows || currentRow < 0 || currentCol >= cols || currentCol < 0)
            {
                return false;
            }
            else if (matrix[currentRow, currentCol] == "#")
            {
                return false;
            }
            else if (visited[currentRow, currentCol])
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

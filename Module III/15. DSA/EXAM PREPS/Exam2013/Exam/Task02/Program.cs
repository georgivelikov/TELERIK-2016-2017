using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{    
    class Program
    {
        public static char[,,] cube;
        public static bool[,,] visited;
        private static int currentLevel;
        private static int currentRow;
        private static int currentCol;
        private static int levels;
        private static int rows;
        private static int cols;
        private static int currentCounter = 0;
        private static int minCounter = int.MaxValue;

        public static void Main()
        {
            int[] starting = Console.ReadLine().Split().Select(int.Parse).ToArray();
            currentLevel = starting[0];
            currentRow = starting[1];
            currentCol = starting[2];

            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            levels = dimensions[0];
            rows = dimensions[1];
            cols = dimensions[2];

            cube = new char[levels, rows, cols];
            visited = new bool[levels, rows, cols];

            for (int level = 0; level < levels; level++)
            {
                for (int row = 0; row < rows; row++)
                {
                    var symbols = Console.ReadLine().ToCharArray();
                    for (int col = 0; col < cols; col++)
                    {
                        cube[level, row, col] = symbols[col];
                    }
                }
            }

            Escape(currentLevel, currentRow, currentCol);
            Console.WriteLine(minCounter);
        }

        private static void Escape(int currentLevel, int currentRow, int currentCol)
        {
            if(!IsValidMove(currentLevel, currentRow, currentCol))
            {
                return;
            }

            currentCounter++;
            if(currentCounter >= minCounter)
            {
                currentCounter--;
                return;
            }

            visited[currentLevel, currentRow, currentCol] = true;

            if(cube[currentLevel, currentRow, currentCol] == 'U')
            {
                Escape(currentLevel + 1, currentRow, currentCol);
            }
            else if(cube[currentLevel, currentRow, currentCol] == 'D')
            {
                Escape(currentLevel - 1, currentRow, currentCol);
            }

            Escape(currentLevel, currentRow + 1, currentCol);
            Escape(currentLevel, currentRow - 1, currentCol);
            Escape(currentLevel, currentRow, currentCol + 1);
            Escape(currentLevel, currentRow, currentCol - 1);

            currentCounter--;
            visited[currentLevel, currentRow, currentCol] = false;
        }

        private static bool IsValidMove(int currentLevel, int currentRow, int currentCol)
        {
            if(currentLevel < levels && currentLevel >= 0)
            {
                if(currentRow < 0 || currentRow >= rows || currentCol < 0 || currentCol >= cols)
                {
                    return false;
                }
                else if(cube[currentLevel, currentRow, currentCol] == '#')
                {
                    return false;
                }
                else if(visited[currentLevel, currentRow, currentCol])
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if(currentCounter < minCounter)
                {
                    minCounter = currentCounter;
                }

                return false;
            }
        }
    }
}

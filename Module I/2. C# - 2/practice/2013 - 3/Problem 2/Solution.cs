using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Solve();
        }
        private static void Solve()
        {
            int[][] numbers = ReadNumbers();
            int bestValue = int.MinValue;
            bool[][] used = new bool[numbers.Length][];
            for (int row = 0; row < used.Length; row++)
            {
                used[row] = new bool[numbers[row].Length];
            }
            for (int column = 0; column < numbers[0].Length; column++)
            {
                var value = GetValue(column, numbers, used);
                if (bestValue < value)
                {
                    bestValue = value;
                }
            }
            Console.WriteLine(bestValue);

        }

        private static int GetValue(int startColumn, int[][] numbers, bool[][] used)
        {
            for (int r = 0; r < used.Length; r++)
            {
                used[r] = new bool[numbers[r].Length];
            }

            int row = 0;
            int column = startColumn;

            int path = 0;
            while (column >= 0 && !used[row][column])
            {
                used[row][column] = true;
                path++;
                column = numbers[row][column];
                row++;
                if (row >= numbers.Length)
                {
                    row -= numbers.Length;
                }
            }

            if (column < 0)
            {
                int value = path + Math.Abs(column);

                return value;
            }
            else
            {
                return -1;
            }
        }

        private static int[][] ReadNumbers()
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] numbers = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                var numberStrings = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                numbers[row] = new int[numberStrings.Length];
                for (int column = 0; column < numberStrings.Length; column++)
                {
                    numbers[row][column] = int.Parse(numberStrings[column]);
                }
            }
            return numbers;
        }
    }
}

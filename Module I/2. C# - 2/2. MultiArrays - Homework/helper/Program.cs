

namespace LargerThanNeighbours
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int length = int.Parse(Console.ReadLine());
            int[] arr = new int[length];
            arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Console.WriteLine(CheckNumbersInArray(arr));

        }
        static int CheckNumbersInArray(int[] arr)
        {
            int count = 0;
            for (int i = 1; i < arr.Length - 1; i++)
            {
                int currentN = arr[i];
                if (currentN > arr[i + 1] && currentN > arr[i - 1])
                {
                    count++;
                }
            }
            return count;
        }
    }
}
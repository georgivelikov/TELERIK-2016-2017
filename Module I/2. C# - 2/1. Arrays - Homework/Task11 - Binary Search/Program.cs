using System;

namespace Task11___Binary_Search
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            int x = int.Parse(Console.ReadLine());
            int result = BinarySearch(arr, x, 0, n - 1);

            Console.WriteLine(result);
        }

        public static int BinarySearch<T>(T[] array, T item, int startIndex, int endIndex) where T : IComparable
        {
            if (endIndex < startIndex)
            {
                return -1;
            }

            else
            {
                int midPoint = startIndex + (endIndex - startIndex) / 2;

                if (array[midPoint].CompareTo(item) > 0)
                {
                    return BinarySearch(array, item, startIndex, midPoint - 1);
                }
                else if (array[midPoint].CompareTo(item) < 0)
                {
                    return BinarySearch(array, item, midPoint + 1, endIndex);
                }
                else
                {
                    return midPoint;
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task14___Quick_Sort
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

            QuickSort(arr, 0, arr.Length - 1);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        private static void QuickSort<T>(T[] collection, int start, int end) where T : IComparable
        {
            if (start >= end)
            {
                return;
            }

            T pivot = collection[start];
            int storeIndex = start + 1;

            for (int i = start + 1; i <= end; i++)
            {
                if (collection[i].CompareTo(pivot) < 0)
                {
                   Swap(collection, i, storeIndex);
                    storeIndex++;
                }
            }

            storeIndex--;
            Swap(collection, start, storeIndex);
            QuickSort(collection, start, storeIndex - 1);
            QuickSort(collection, storeIndex + 1, end);
        }

        private static void Swap<T>(T[] collection, int first, int second)
        {
            T oldFirst = collection[first];
            collection[first] = collection[second];
            collection[second] = oldFirst;
        }
    }
}

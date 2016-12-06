using System;
using System.Collections.Generic;
using System.Linq;

namespace Task03_Find_Numbers
{
    public class Program
    {
        private static int counter = 0;
        private static int index = -1;

        public static void Main()
        {
            var indeces = Console.ReadLine().Split(' ').Select(n => int.Parse(n)).ToArray();
            var numbers = Console.ReadLine().Split(' ').ToList();
            index = indeces[1];
            var res = QuickSort(numbers);
            Console.WriteLine(res[index]);
        }

        private static List<string> QuickSort(List<string> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            int pivotIndex = collection.Count / 2;
            string pivot = collection[pivotIndex];

            List<string> left = new List<string>();
            List<string> right = new List<string>();
            for (int i = 0; i < pivotIndex; i++)
            {
                if (String.Compare(collection[i], pivot, StringComparison.Ordinal) <= 0)
                {
                    left.Add(collection[i]);
                }
                else
                {
                    right.Add(collection[i]);
                }
            }
            for (int i = pivotIndex + 1; i < collection.Count; i++)
            {
                if (String.Compare(collection[i], pivot, StringComparison.Ordinal) < 0)
                {
                    left.Add(collection[i]);
                }
                else
                {
                    right.Add(collection[i]);
                }
            }

            var currentIndex = left.Count;
            if (currentIndex == index)
            {
                Console.WriteLine(collection[currentIndex]);
                Environment.Exit(0);
            }
            List<string> result = new List<string>();

            result.AddRange(QuickSort(left));
            result.Add(pivot);
            result.AddRange(QuickSort(right));

            return result;
        }
    }
}
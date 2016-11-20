using System;
using System.Collections.Generic;

namespace Task06
{
    public class Program
    {
        // Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.
        public static void Main()
        {
            var list = new List<int>() { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            var map = new SortedDictionary<int, int>();

            for (int i = 0; i < list.Count; i++)
            {
                var currentNumber = list[i];

                if (!map.ContainsKey(currentNumber))
                {
                    map.Add(currentNumber, 0);
                }

                map[currentNumber]++;
            }

            foreach (var item in map)
            {
                Console.WriteLine("{0} -> {1} times", item.Key, item.Value);
            }
        }
    }
}

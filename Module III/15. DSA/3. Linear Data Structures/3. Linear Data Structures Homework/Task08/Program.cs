using System;
using System.Collections.Generic;

namespace Task08
{
    // The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times.

    public class Program
    {
        public static void Main()
        {
            var list = new List<int>() { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
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
                if (list.Count / 2 + 1 <= item.Value)
                { 
                    Console.WriteLine("{0} -> {1} times", item.Key, item.Value);
                }            
            }
        }
    }
}

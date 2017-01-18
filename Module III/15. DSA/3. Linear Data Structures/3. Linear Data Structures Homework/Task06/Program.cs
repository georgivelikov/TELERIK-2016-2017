using System;
using System.Collections.Generic;

namespace Task06
{
    public class Program
    {
        // Write a program that removes from given sequence all numbers that occur odd number of times.
        public static void Main()
        {
            var list = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            var map = new Dictionary<int, int>();

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
                if (item.Value % 2 != 0)
                {
                    list.RemoveAll(x => x == item.Key);
                }
            }

            Console.WriteLine(string.Join(", ", list));
        }
    }
}

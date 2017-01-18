using System;
using System.Collections.Generic;

namespace Task01
{
    public class Program
    {
        public static void Main()
        {
            double[] arr = { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            var map = new Dictionary<double, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (!map.ContainsKey(arr[i]))
                {
                    map.Add(arr[i], 0);
                }

                map[arr[i]]++;
            }

            foreach (var item in map)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
        }
    }
}

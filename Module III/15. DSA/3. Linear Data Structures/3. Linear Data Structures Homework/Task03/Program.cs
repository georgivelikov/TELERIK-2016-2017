using System;
using System.Collections.Generic;

namespace Task03
{
    // Write a program that reads a sequence of integers(List<int>) ending with an empty line and sorts them in an increasing order.
    public class Program
    {
        public static void Main()
        {
            var list = new List<double>();
            var line = string.Empty;

            while (true)
            {
                line = Console.ReadLine();
                if (line == string.Empty)
                {
                    break;
                }

                var number = double.Parse(line);
                list.Add(number);
            }

            list.Sort();
            Console.WriteLine("Increasing: " + string.Join(", ", list));

            list.Reverse();
            Console.WriteLine("Decreasing: " + string.Join(", ", list));
        }
    }
}

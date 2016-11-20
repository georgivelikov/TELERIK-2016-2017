using System;
using System.Collections.Generic;

namespace Task04
{
    public class Program
    {
        // Write a program that removes from given sequence all negative numbers.

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

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] < 0)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }

            Console.WriteLine(string.Join(", ", list));
        }
    }
}

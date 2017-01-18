using System;
using System.Collections.Generic;
using System.Linq;

namespace Task01
{
    //Write a program that reads from the console a sequence of positive integer numbers.

    //The sequence ends when empty line is entered.
    //Calculate and print the sum and average of the elements of the sequence.
    //Keep the sequence in List<int>.

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

            Console.WriteLine(list.Sum());
            Console.WriteLine("{0:0.00}", list.Average());
        }
    }
}

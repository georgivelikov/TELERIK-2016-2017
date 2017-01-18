using System;
using System.Collections.Generic;

namespace Task01
{
    //Write a program that reads N integers from the console and reverses them using a stack.

    //Use the Stack<int> class.

    public class Program
    {
        public static void Main()
        {
            var stack = new Stack<double>();
            var line = string.Empty;

            while (true)
            {
                line = Console.ReadLine();
                if (line == string.Empty)
                {
                    break;
                }

                var number = double.Parse(line);
                stack.Push(number);
            }

            while (stack.Count != 0)
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}


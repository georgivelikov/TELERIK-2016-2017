using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.Recursion_Homework
{
    public class Program
    {
        private static Stack<int> stack = new Stack<int>();
         
        public static void Main()
        {
            int n = 3;

            SimulateLoops(n);
        }

        private static void SimulateLoops(int n)
        {
            if (stack.Count == n)
            {
                Console.WriteLine(string.Join(", ", stack.Reverse()));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                stack.Push(i);
                SimulateLoops(n);
                stack.Pop();
            }

        }
    }
}

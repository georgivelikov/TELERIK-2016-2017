using System;
using System.Collections.Generic;
using System.Linq;

namespace Task02
{
    public class Program
    {
        private static Stack<int> stack = new Stack<int>();

        public static void Main()
        {
            int n = 3;
            int k = 2;

            CalculateCombinations(1, n, k);
        }

        private static void CalculateCombinations(int start, int n, int k)
        {
            if (stack.Count == k)
            {
                Console.WriteLine(string.Join(", ", stack.Reverse()));
                return;
            }

            for (int i = start; i <= n; i++)
            {
                stack.Push(i);
                CalculateCombinations(i, n, k);
                stack.Pop();
            }
        }
    }
}

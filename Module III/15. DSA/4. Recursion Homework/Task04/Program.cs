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

            CalculatePermutations(n);
        }

        private static void CalculatePermutations(int n)
        {
            if (stack.Count == n)
            {
                Console.WriteLine(string.Join(", ", stack.Reverse()));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                if (!stack.Contains(i))
                {
                    stack.Push(i);
                    CalculatePermutations(n);
                    stack.Pop();
                }
            }
        }
    }
}

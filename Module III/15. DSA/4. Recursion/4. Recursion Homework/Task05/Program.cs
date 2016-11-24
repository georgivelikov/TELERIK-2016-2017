using System;
using System.Collections.Generic;
using System.Linq;

namespace Task02
{
    public class Program
    {
        private static Stack<string> stack = new Stack<string>();
        private static List<string> list = new List<string>() { "hi", "a", "b" };

        public static void Main()
        {
            int n = list.Count;
            int k = 2;

            CalculateCombinations(n, k);
        }

        private static void CalculateCombinations(int n, int k)
        {
            if (stack.Count == k)
            {
                Console.WriteLine(string.Join(", ", stack.Reverse()));
                return;
            }

            for (int i = 0; i < n; i++)
            {
                stack.Push(list[i]);
                CalculateCombinations(n, k);
                stack.Pop();
            }
        }
    }
}

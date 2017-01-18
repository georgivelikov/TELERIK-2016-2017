using System;

namespace Task12
{
    public class Program
    {
        public static void Main()
        {
            var stack = new CustomStack<int>();

            // Adding 10 elements
            for (int i = 1; i <= 10; i++)
            {
                stack.Push(i);
            }

            // "Removing last 5
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(stack.Pop());
            }

            Console.WriteLine("Last element after 5 removes: " + stack.Peek());
            Console.WriteLine("Count: " + stack.Count);

            for (int i = 1; i <= 50; i++)
            {
                stack.Push(i);
            }

            Console.WriteLine("Last element after 50 pushs: " + stack.Peek());
            Console.WriteLine("Count: " + stack.Count);
        }
    }
}

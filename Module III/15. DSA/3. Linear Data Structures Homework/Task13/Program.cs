using System;

namespace Task13
{
    public class Program
    {
        public static void Main()
        {
            var queue = new CustomQueue<int>();

            queue.Enqueue(1);
            queue.Enqueue(3);
            queue.Enqueue(13);
            queue.Enqueue(55);

            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
        }
    }
}

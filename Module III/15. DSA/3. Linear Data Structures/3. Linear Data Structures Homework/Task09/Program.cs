using System;
using System.Collections.Generic;

namespace Task09
{
    public class Program
    {
        //We are given the following sequence:

        //S1 = N;
        //S2 = S1 + 1;
        //S3 = 2*S1 + 1;
        //S4 = S1 + 2;
        //S5 = S2 + 1;
        //S6 = 2*S2 + 1;
        //S7 = S2 + 2;
        //...
        //Using the Queue<T> class write a program to print its first 50 members for given N.
        //Example: N= 2 → 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...

        public static void Main()
        {
            int n = 2;
            int counter = 1;
            var limit = 50;
            var queue = new Queue<int>();

            queue.Enqueue(n);

            while (counter <= limit)
            {
                var number = queue.Dequeue();
                Console.WriteLine("S{0} = {1}", counter, number);

                queue.Enqueue(number + 1);
                queue.Enqueue(2 * number + 1);
                queue.Enqueue(number + 2);

                counter++;
            }
        }
    }
}

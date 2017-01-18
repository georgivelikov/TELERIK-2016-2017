using System;
using System.Collections.Generic;
using System.Numerics;

namespace Task2
{
    // 04. Редица цветни топчета 100/100
    public class Program
    {
        public static void Main()
        {
            char[] input = Console.ReadLine().ToCharArray();

            Array.Sort(input);

            List<int> list = new List<int>();
            int count = 1;

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == input[i - 1])
                {
                    count++;
                    if (i == input.Length - 1)
                    {
                        list.Add(count);
                    }
                }
                else
                {
                    list.Add(count);
                    count = 1;
                }
            }
            BigInteger nFac = Factorial(input.Length);

            foreach(int num in list)
            {
                BigInteger x = Factorial(num);
                nFac /= x;
            }
            Console.WriteLine(nFac);
        }

        private static BigInteger Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }
    }
}
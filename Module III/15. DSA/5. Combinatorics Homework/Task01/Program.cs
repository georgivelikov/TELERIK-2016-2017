using System;
using System.Numerics;

namespace Task01
{
    // Задача 1 – Двоични пароли 100/100
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            int counter = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '*')
                {
                    counter++;
                }
            }

            BigInteger result = BigInteger.Pow(2, counter);
            Console.WriteLine(result);

        }
    }
}

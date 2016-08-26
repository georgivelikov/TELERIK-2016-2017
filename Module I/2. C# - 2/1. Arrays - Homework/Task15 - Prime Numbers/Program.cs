using System;
using System.Linq;

namespace Task15___Prime_Numbers
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            
            for (int i = n; i >= 0; i--)
            {
                bool isPrime = true;

                for (int j = 2; j <= Math.Sqrt(n); j++)
                {
                    if (n % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    Console.WriteLine(n);
                    return;
                }

                n--;
            }

        }
    }
}

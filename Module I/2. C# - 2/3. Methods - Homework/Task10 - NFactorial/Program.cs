using System;
using System.Collections.Generic;
using System.Numerics;

public class Program
{
    public static void Main()
    {
        long n = int.Parse(Console.ReadLine());

        Console.WriteLine(CalculateFactorial(n));
    }

    private static BigInteger CalculateFactorial(long n)
    {
        if (n == 0)
        {
            return 1;
        }

        return n * CalculateFactorial(n - 1);
    }
}


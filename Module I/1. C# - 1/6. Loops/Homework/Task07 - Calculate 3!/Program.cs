using System;
using System.Collections.Generic;
using System.Numerics;

public class Program
{
    public static void Main()
    {
        BigInteger n = BigInteger.Parse(Console.ReadLine());
        BigInteger k = BigInteger.Parse(Console.ReadLine());

        BigInteger nFac = 1;
        BigInteger kFac = 1;
        BigInteger nMinusKFac = 1;

        for (int i = 1; i <= n; i++)
        {
            nFac *= i;
            if (i <= k)
            {
                kFac *= i;
            }
            if (i <= n - k)
            {
                nMinusKFac *= i;
            }
        }

        BigInteger result = nFac / (kFac * nMinusKFac);
        Console.WriteLine(result);
    }
}


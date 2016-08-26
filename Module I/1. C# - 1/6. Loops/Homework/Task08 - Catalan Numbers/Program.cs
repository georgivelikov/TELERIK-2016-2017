using System;
using System.Numerics;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        BigInteger nFac = 1;
        BigInteger nDoubleFac = 1;
        BigInteger nPlusFac = 1;

        for (int i = 1; i <= 2 * n; i++)
        {
            nDoubleFac *= i;
            if (i <= n)
            {
                nFac *= i;
            }
            if (i <= n + 1)
            {
                nPlusFac *= i;
            }
        }

        BigInteger result = nDoubleFac / (nFac * nPlusFac);
        Console.WriteLine(result);
    }
}



using System;
using System.Numerics;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        BigInteger result = 1;
        for (int i = k + 1; i <= n; i++)
        {
            result *= i;
        }
        Console.WriteLine("{0}", result);
    }
}

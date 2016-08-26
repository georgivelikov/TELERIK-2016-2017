using System;

public class Program
{
    public static void Main()
    {
        ulong n = ulong.Parse(Console.ReadLine());
        double x = double.Parse(Console.ReadLine());

        ulong factorial = 1;
        double result = 1;

        for (ulong i = 1; i <= n; i++)
        {
            factorial *= i;
            result += factorial / Math.Pow(x, i);
        }

        Console.WriteLine("{0:0.00000}", result);
    }
}


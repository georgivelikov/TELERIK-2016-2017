using System;

public class Program
{
    public static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());

        Console.WriteLine("{0:0.00} {1:1.00}", a * b, (a + b) * 2);
    }
}


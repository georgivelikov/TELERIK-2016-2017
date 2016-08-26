using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double x = Math.PI * double.Parse(Console.ReadLine()) / 180;
        double sinX = Math.Sin(x);

        double area = (a * b * sinX) / 2;

        Console.WriteLine("{0:0.00}", area);

    }
}


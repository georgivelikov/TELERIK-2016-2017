using System;

public class Program
{
    public static void Main()
    {
        double r = double.Parse(Console.ReadLine());
        double per = 2 * r * Math.PI;
        double area = Math.PI * Math.Pow(r, 2);
        Console.WriteLine("{0:f2} {1:f2}", per, area);
    }
}


using System;

public class Program
{
    public static void Main()
    {
        double r = 2;
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());

        double c = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        if (r < c)
        {
            Console.WriteLine("no {0:0.00}", c);
        }
        else
        {
            Console.WriteLine("yes {0:0.00}", c);
        }
    }
}


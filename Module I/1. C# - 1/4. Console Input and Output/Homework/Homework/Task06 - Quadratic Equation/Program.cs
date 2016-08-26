using System;

public class Program
{
    public static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());

        double D = Math.Pow(b, 2) - 4 * a * c;

        if (D < 0)
        {
            Console.WriteLine("no real roots");
        }
        else if (D == 0)
        {
            double x = -1 * b / (2 * a);
            Console.WriteLine("{0:f2}", x);
        }
        else
        {
            double x1 = (-1 * b - Math.Sqrt(D)) / (2 * a);
            Console.WriteLine("{0:f2}", x1);

            double x2 = (-1 * b + Math.Sqrt(D)) / (2 * a);
            Console.WriteLine("{0:f2}", x2);
        }
    }
}


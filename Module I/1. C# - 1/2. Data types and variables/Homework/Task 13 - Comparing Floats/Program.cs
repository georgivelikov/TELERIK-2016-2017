using System;

public class Program
{
    public static void Main()
    {
        double eps = 0.000001f;

        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());

        if (Math.Abs(a - b) >= eps) 
        {
            Console.WriteLine("false");
        }
        else
        {
            Console.WriteLine("true");
        }
    }
}


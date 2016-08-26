using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());

        if (a == 0 || b == 0 || c == 0)
        {
            Console.WriteLine(0);
            return;
        }

        if (a > 0 && b > 0 && c > 0)
        {
            Console.WriteLine("+");
        }
        else if (a > 0 && b > 0 && c < 0)
        {
            Console.WriteLine("-");
        }
        else if (a < 0 && b > 0 && c > 0)
        {
            Console.WriteLine("-");
        }
        else if (a > 0 && b < 0 && c > 0)
        {
            Console.WriteLine("-");
        }
        else if (a < 0 && b < 0 && c > 0)
        {
            Console.WriteLine("+");
        }
        else if (a < 0 && b > 0 && c < 0)
        {
            Console.WriteLine("+");
        }
        else if (a > 0 && b < 0 && c < 0)
        {
            Console.WriteLine("+");
        }
        else if (a < 0 && b < 0 && c < 0)
        {
            Console.WriteLine("-");
        }
    }
}


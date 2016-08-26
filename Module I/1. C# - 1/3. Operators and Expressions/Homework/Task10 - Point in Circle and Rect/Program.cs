using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        double cX = 1;
        double cY = 1;
        double r = 1.5;
        double top = 1;
        double left = -1;
        double w = 6;
        double h = 2;

        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());

        if (Math.Pow(x - cX, 2) + Math.Pow(y - cY, 2) <= Math.Pow(r, 2))
        {
            Console.Write("inside circle");
        }
        else
        {
            Console.Write("outside circle");
        }

        if (x >= left && x <= left + w && y >= top - h && y <= top)
        {
            Console.Write(" inside rectangle");
        }
        else
        {
            Console.Write(" outside rectangle");
        }
    }
}


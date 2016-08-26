using System;

public class Program
{
    public static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        double d = double.Parse(Console.ReadLine());
        double e = double.Parse(Console.ReadLine());
        //double biggest = a;

        //if (biggest <= b)
        //{
        //    biggest = b;
        //}

        //if (biggest <= c)
        //{
        //    biggest = c;
        //}

        //if (biggest <= d)
        //{
        //    biggest = d;
        //}

        //if (biggest <= e)
        //{
        //    biggest = e;
        //}

        //Console.WriteLine(biggest);

        if (a >= b && a >= c && a >= d && a >= e)
        {
            Console.WriteLine(a);
        }
        else
        {
            if (b >= c && b >= d && b >= e)
            {
                Console.WriteLine(b);
            }
            else
            {
                if (c >= d && c >= e)
                {
                    Console.WriteLine(c);
                }
                else
                {
                    if (d >= e)
                    {
                        Console.WriteLine(d);
                    }
                    else
                    {
                        Console.WriteLine(e);
                    }
                }
            }
        }
    }
}

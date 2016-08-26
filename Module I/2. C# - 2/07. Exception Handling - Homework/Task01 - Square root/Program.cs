using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        try
        {
            double x = double.Parse(Console.ReadLine());
            if (x < 0)
            {
                throw new Exception();
            }
            double res = Math.Sqrt(x);
            Console.WriteLine("{0:0.000}", res);

        }
        catch (Exception)
        {
            Console.WriteLine("Invalid number");
        }
        finally
        {
            Console.WriteLine("Good bye");
        }
    }
}


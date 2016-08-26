using System;

public class Program
{
    public static void Main()
    {
        int x = int.Parse(Console.ReadLine());

        if (x % 2 == 0)
        {
            Console.WriteLine("even {0}", x);
        }
        else
        {
            Console.WriteLine("odd {0}", x);
        }
    }
}


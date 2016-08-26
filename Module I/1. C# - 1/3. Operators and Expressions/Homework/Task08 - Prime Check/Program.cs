using System;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        if (n <= 1)
        {
            Console.WriteLine("false");
            return;
        }

        for (int i = 2; i < n; i++)
        {
            if (n % i == 0)
            {
                Console.WriteLine("false");
                return;
            }
        }

        Console.WriteLine("true");
    }
}


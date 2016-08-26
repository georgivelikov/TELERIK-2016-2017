using System;

public class Program
{
    
    public static void Main()
    {
        int n = 1;

        for (int i = 2; i < 12; i++)
        {
            Console.WriteLine(i * n);
            n *= -1;
        }
    }
}


using System;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double result = 0;
        for (int i = 0; i < n; i++)
        {
            result += double.Parse(Console.ReadLine());
        }

        Console.WriteLine(result);
    }
}


using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        string[] arr = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        try
        {
            int x = int.Parse(Console.ReadLine());
            if (x < 0 || x >= 10)
            {
                Console.WriteLine("not a digit");
                return;
            }

            Console.WriteLine(arr[x]);
        }
        catch (Exception)
        {
            Console.WriteLine("not a digit");
        }
    }
}


using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        LinkedList<char> result = new LinkedList<char>();
        int n = int.Parse(Console.ReadLine());

        while (n > 0)
        {
            if (n % 2 == 0)
            {
                result.AddFirst('0');
            }
            else
            {
                result.AddFirst('1');
            }

            n /= 2;
        }

        Console.WriteLine(string.Join("", result));
    }
}

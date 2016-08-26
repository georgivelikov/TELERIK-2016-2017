using System;
using System.Collections.Generic;
using System.Net;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        if (n == 1)
        {
            Console.WriteLine(0);
            return;
        }

        long previous = 0;
        long next = 1;

        List<long> list = new List<long>();
        list.Add(previous);
        list.Add(next);
        for (int i = 0; i < n - 2; i++)
        {
            long current = previous + next;
            list.Add(current);
            previous = next;
            next = current;
        }

        Console.WriteLine(string.Join(", ", list));
    }
}


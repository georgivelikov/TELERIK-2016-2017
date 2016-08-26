using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        string[] arr = new[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        HashSet<string> set = new HashSet<string>(arr);

        string str = Console.ReadLine();

        if (set.Contains(str))
        {
            Console.WriteLine("yes {0}", str);
        }
        else
        {
            Console.WriteLine("no {0}", str);
        }
    }
}


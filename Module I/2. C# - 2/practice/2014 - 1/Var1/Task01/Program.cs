using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    public static void Main()
    {
        ulong n = ulong.Parse(Console.ReadLine());

        Dictionary<ulong, string> map = new Dictionary<ulong, string>();
        map.Add(0, @"LON+");
        map.Add(1, @"VK-");
        map.Add(2, @"*ACAD");
        map.Add(3, @"^MIM");
        map.Add(4, @"ERIK|");
        map.Add(5, @"SEY&");
        map.Add(6, @"EMY>>");
        map.Add(7, @"/TEL");
        map.Add(8, @"<<DON");

        List<string> result = new List<string>();
        if (n == 0)
        {
            Console.WriteLine("LON+");
            return;
        }
        while (n > 0)
        {
            result.Add(map[n % 9]);
            n /= 9;
        }

        result.Reverse();
        Console.WriteLine(string.Join(string.Empty, result));
    }
}


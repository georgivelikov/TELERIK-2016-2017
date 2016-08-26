using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

public class Program
{
    public static void Main()
    {
        char[] first = Console.ReadLine().ToCharArray();
        string sign = Console.ReadLine();
        char[] second = Console.ReadLine().ToCharArray();

        Dictionary<string, int> map = new Dictionary<string, int>();
        map.Add("cad", 0);
        map.Add("xoz", 1);
        map.Add("nop", 2);
        map.Add("cyk", 3);
        map.Add("min", 4);
        map.Add("mar", 5);
        map.Add("kon", 6);
        map.Add("iva", 7);
        map.Add("ogi", 8);
        map.Add("yan", 9);

        Dictionary<BigInteger, string> map2 = new Dictionary<BigInteger, string>();
        map2.Add(0, "cad");
        map2.Add(1, "xoz");
        map2.Add(2, "nop");
        map2.Add(3, "cyk");
        map2.Add(4, "min");
        map2.Add(5, "mar");
        map2.Add(6, "kon");
        map2.Add(7, "iva");
        map2.Add(8, "ogi");
        map2.Add(9, "yan");

        string current = string.Empty;
        BigInteger result1 = 0;
        BigInteger result2 = 0;
        BigInteger counter = 1;

        for (int i = first.Length - 1; i >= 0; i -= 3)
        {
            for (int j = i; j > i - 3; j--)
            {
                current = first[j] + current;
            }

            int num = map[current];
            result1 += counter * num;
            current = string.Empty;
            counter *= 10;
        }

        current = string.Empty;
        counter = 1;
        for (int i = second.Length - 1; i >= 0; i -= 3)
        {
            for (int j = i; j > i - 3; j--)
            {
                current = second[j] + current;
            }

            int num = map[current];
            result2 += counter * num;
            current = string.Empty;
            counter *= 10;
        }

        BigInteger result = 0;
        if (sign == "-")
        {
            result = result1 - result2;
        }
        else
        {
            result = result1 + result2;
        }

        Console.WriteLine(result);
        string final = string.Empty;
        while (result > 0)
        {
            BigInteger currentNum = result % 10;
            final = map2[currentNum] + final;
            result /= 10;
        }

        Console.WriteLine(final);
    }
}


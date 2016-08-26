using System;
using System.Collections.Generic;
using System.Numerics;

public class Program
{
    public static void Main()
    {
        Dictionary<string, int> map = new Dictionary<string, int>();
        string line = Console.ReadLine();
        char[] arr = line.ToCharArray();
        Array.Reverse(arr);

        map.Add("rwaR", 0);
        map.Add("rrrR", 1);
        map.Add("tssH", 2);
        map.Add("tssS", 3);
        map.Add("rrrG", 4);
        map.Add("rraR", 5);
        map.Add("rrrM", 6);
        map.Add("tssP", 7);
        map.Add("haaU", 8);
        map.Add("ahaU", 9);
        map.Add("zzzZ", 10);
        map.Add("uuaB", 11);
        map.Add("vajD", 12);
        map.Add("uayM", 13);
        map.Add("hurG", 14);

        BigInteger counter = 1;
        BigInteger result = 0;
        for (int i = 0; i < arr.Length; i += 4)
        {
            string str = String.Empty;
            for (int j = 0; j < 4; j++)
            {
                str += arr[i + j];
            }

            result += map[str] * counter;
            counter *= 15;
        }

        Console.WriteLine(result);

    }
}


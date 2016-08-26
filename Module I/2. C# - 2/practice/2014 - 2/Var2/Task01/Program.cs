using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text;

public class Program
{
    public static void Main()
    {
        Dictionary<string, int> map = new Dictionary<string, int>();
        map.Add("f", 0);
        map.Add("NIb", 1);
        map.Add("CEJBo", 2);
        map.Add("LVARTNm", 3);
        map.Add("QNKVPl", 4);
        map.Add("EWNp", 5);
        map.Add("Th", 6);
        string line = Console.ReadLine();

        StringBuilder sb = new StringBuilder();
        BigInteger counter = 1;
        BigInteger result = 0;
        for (int i = line.Length - 1; i >= 0; i--)
        {
            sb.Append(line[i]);
            if (map.ContainsKey(sb.ToString()))
            {
                result += map[sb.ToString()] * counter;
                counter *= 7;
                sb.Clear();
            }
        }

        Console.WriteLine(result);
    }
}


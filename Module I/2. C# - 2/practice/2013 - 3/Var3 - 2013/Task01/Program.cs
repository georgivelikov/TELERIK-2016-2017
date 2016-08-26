using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

public class Program
{
    public static void Main()
    {
        Dictionary<string, int> map = new Dictionary<string, int>();
        map.Add("-!", 0);
        map.Add("**", 1);
        map.Add("!!!", 2);
        map.Add("&&", 3);
        map.Add("&-", 4);
        map.Add("!-", 5);
        map.Add("*!!!", 6);
        map.Add("&*!", 7);
        map.Add("!!**!-", 8);

        BigInteger result = 0;

        string input = Console.ReadLine();
        string str = string.Empty;
        string resultString = string.Empty;
        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];
            str += c;

            if (map.ContainsKey(str))
            {
                resultString += map[str];
                str = string.Empty;
            }
        }

        char[] arr = resultString.ToCharArray();
        int len = arr.Length;
        for (int i = 0; i < arr.Length; i++)
        {
            result += BigInteger.Pow(9, (len - 1 - i)) * BigInteger.Parse(arr[i].ToString());
        }

        Console.WriteLine(result);
    }
}


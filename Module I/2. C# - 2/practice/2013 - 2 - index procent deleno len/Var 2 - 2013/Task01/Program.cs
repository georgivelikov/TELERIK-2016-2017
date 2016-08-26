using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();
        BigInteger result = 0;
        int len = input.Length;
        string current = string.Empty;
        string helper = string.Empty;
        for (int i = 0; i < len; i++)
        {
            char c = input[i];
            current += c;
            if (Char.IsUpper(c))
            {
                int num = ConvertToNumber(current);
                helper += " " + num;
            }
            else
            {
                continue;
            }

            current = string.Empty;
        }

        int[] arr = helper.Trim().Split(' ').Select(x => int.Parse(x)).ToArray();

        Array.Reverse(arr);
        for (int i = 0; i < arr.Length; i++)
        {
            result += arr[i] * BigInteger.Pow(168, i);
        }

        Console.WriteLine(result);
    }

    private static int ConvertToNumber(string str)
    {
        if (str.Length == 1)
        {
            return str[0] - 65;
        }
        else if (str.Length == 2)
        {
            int first = str[0] - 96;
            int second = str[1] - 65;

            return (first * 26 + second);
        }
        else
        {
            return -1;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Text;

public class Program
{
    public static void Main()
    {
        char[] input = Console.ReadLine().ToCharArray();
        StringBuilder sb = new StringBuilder();
        for (int i = input.Length - 1; i >= 0; i--)
        {
            sb.Append(input[i]);
        }

        Console.WriteLine(sb.ToString());
    }
}


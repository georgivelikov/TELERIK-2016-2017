using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    public static void Main()
    {
        char[] arr = Console.ReadLine().ToCharArray();
        StringBuilder sb = new StringBuilder();
        sb.Append(arr[0]);
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] != arr[i - 1])
            {
                sb.Append(arr[i]);
            }
        }

        Console.WriteLine(sb);
    }
}


using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        ulong dec = ulong.Parse(Console.ReadLine());
        List<string> binResult = new List<string>();
        if (dec == 0)
        {
            Console.WriteLine(0);
            return;
        }

        while (dec > 0)
        {
            string currentBinResult = (dec % 2).ToString();
            binResult.Add(currentBinResult);
            dec /= 2;
        }

        binResult.Reverse();
        Console.WriteLine(string.Join("", binResult));
    }
}


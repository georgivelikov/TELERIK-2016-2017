using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        string bin = Console.ReadLine();
        ulong decResult = 0;


        for (int i = bin.Length - 1; i >= 0; i--)
        {
            int currentChar = int.Parse(bin[i].ToString());
            decResult += (ulong)(Math.Pow(2, bin.Length - 1 - i) * currentChar);
        }

        Console.WriteLine(decResult);
    }
}


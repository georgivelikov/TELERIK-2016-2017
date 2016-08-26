using System;
using System.Collections.Generic;
using System.Numerics;

public class Program
{
    public static void Main()
    {
        BigInteger first = BigInteger.Parse(Console.ReadLine());
        string numberInFirst = Console.ReadLine();
        BigInteger second = BigInteger.Parse(Console.ReadLine());
        BigInteger resultInDecimal = 0;
        List<string> resultInSecond = new List<string>();

        Dictionary<string, BigInteger> symbols = new Dictionary<string, BigInteger>();
        symbols.Add("0", 0);
        symbols.Add("1", 1);
        symbols.Add("2", 2);
        symbols.Add("3", 3);
        symbols.Add("4", 4);
        symbols.Add("5", 5);
        symbols.Add("6", 6);
        symbols.Add("7", 7);
        symbols.Add("8", 8);
        symbols.Add("9", 9);
        symbols.Add("A", 10);
        symbols.Add("B", 11);
        symbols.Add("C", 12);
        symbols.Add("D", 13);
        symbols.Add("E", 14);
        symbols.Add("F", 15);

        Dictionary<BigInteger, string> numsToSymbols = new Dictionary<BigInteger, string>();
        numsToSymbols.Add(0, "0");
        numsToSymbols.Add(1, "1");
        numsToSymbols.Add(2, "2");
        numsToSymbols.Add(3, "3");
        numsToSymbols.Add(4, "4");
        numsToSymbols.Add(5, "5");
        numsToSymbols.Add(6, "6");
        numsToSymbols.Add(7, "7");
        numsToSymbols.Add(8, "8");
        numsToSymbols.Add(9, "9");
        numsToSymbols.Add(10, "A");
        numsToSymbols.Add(11, "B");
        numsToSymbols.Add(12, "C");
        numsToSymbols.Add(13, "D");
        numsToSymbols.Add(14, "E");
        numsToSymbols.Add(15, "F");

        // first to decimal
        for (int i = numberInFirst.Length - 1; i >= 0; i--)
        {
            BigInteger current = symbols[numberInFirst[i].ToString()];
            resultInDecimal += current * BigInteger.Pow(first, numberInFirst.Length - 1 - i);
        }

        // decimal to second
        while (resultInDecimal > 0)
        {
            string current = numsToSymbols[resultInDecimal % second];
            resultInSecond.Add(current);
            resultInDecimal /= second;

        }

        resultInSecond.Reverse();
        Console.WriteLine(string.Join("", resultInSecond));
    }
}


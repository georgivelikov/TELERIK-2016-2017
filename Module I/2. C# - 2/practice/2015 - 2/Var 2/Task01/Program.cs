using System;
using System.Collections.Generic;
using System.Numerics;

public class Program
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split();
        BigInteger resultInDecimal = 0;
        List<char> resultInSecond = new List<char>();
        List<string> finalResult = new List<string>();
        Dictionary<char, BigInteger> symbols = new Dictionary<char, BigInteger>();
        symbols.Add('a', 0);
        symbols.Add('b', 1);
        symbols.Add('c', 2);
        symbols.Add('d', 3);
        symbols.Add('e', 4);
        symbols.Add('f', 5);
        symbols.Add('g', 6);
        symbols.Add('h', 7);
        symbols.Add('i', 8);
        symbols.Add('j', 9);
        symbols.Add('k', 10);
        symbols.Add('l', 11);
        symbols.Add('m', 12);
        symbols.Add('n', 13);
        symbols.Add('o', 14);
        symbols.Add('p', 15);
        symbols.Add('q', 16);
        symbols.Add('r', 17);
        symbols.Add('s', 18);
        symbols.Add('t', 19);
        symbols.Add('u', 20);

        Dictionary<BigInteger, char> numsToSymbols = new Dictionary<BigInteger, char>();
        numsToSymbols.Add(0, 'a');
        numsToSymbols.Add(1, 'b');
        numsToSymbols.Add(2, 'c');
        numsToSymbols.Add(3, 'd');
        numsToSymbols.Add(4, 'e');
        numsToSymbols.Add(5, 'f');
        numsToSymbols.Add(6, 'g');
        numsToSymbols.Add(7, 'h');
        numsToSymbols.Add(8, 'i');
        numsToSymbols.Add(9, 'j');
        numsToSymbols.Add(10, 'k');
        numsToSymbols.Add(11, 'l');
        numsToSymbols.Add(12, 'm');
        numsToSymbols.Add(13, 'n');
        numsToSymbols.Add(14, 'o');
        numsToSymbols.Add(15, 'p');
        numsToSymbols.Add(16, 'q');
        numsToSymbols.Add(17, 'r');
        numsToSymbols.Add(18, 's');
        numsToSymbols.Add(19, 't');
        numsToSymbols.Add(20, 'u');
        numsToSymbols.Add(21, 'v');
        numsToSymbols.Add(22, 'w');
        numsToSymbols.Add(23, 'x');
        numsToSymbols.Add(24, 'y');
        numsToSymbols.Add(25, 'z');

        foreach (var str in input)
        {
            string first = str;
            // first to decimal
            for (int i = first.Length - 1; i >= 0; i--)
            {
                BigInteger current = symbols[first[i]];
                resultInDecimal += current * BigInteger.Pow(21, first.Length - 1 - i);
            }

            // decimal to second
            while (resultInDecimal > 0)
            {
                char current = numsToSymbols[resultInDecimal % 26];
                resultInSecond.Add(current);
                resultInDecimal /= 26;

            }

            resultInSecond.Reverse();
            string result = string.Join(string.Empty, resultInSecond);

            finalResult.Add(result);
            resultInSecond.Clear();
        }

        Console.WriteLine(string.Join(" ", finalResult));
    }
}


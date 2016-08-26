using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        string word = Console.ReadLine();
        word = word.Replace(@"\", string.Empty);
        Console.WriteLine(word.PadRight(20, '*'));
    }
}


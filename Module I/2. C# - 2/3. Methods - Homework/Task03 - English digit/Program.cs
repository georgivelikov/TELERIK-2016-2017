using System;

public class Program
{
    public static void Main()
    {
        string line = Console.ReadLine();

        Console.WriteLine(LastDigit(line));
    }

    private static string LastDigit(string line)
    {
        string[] arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        string lastDigit = line[line.Length - 1].ToString();

        return arr[int.Parse(lastDigit)];
    }
}


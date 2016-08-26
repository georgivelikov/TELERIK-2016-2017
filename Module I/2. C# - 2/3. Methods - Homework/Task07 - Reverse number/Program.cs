using System;

public class Program
{
    public static void Main()
    {
        string line = Console.ReadLine();

        Console.WriteLine(ReverseString(line));
    }

    private static string ReverseString(string line)
    {
        char[] arr = line.ToCharArray();
        char[] reversed = new char[arr.Length];

        for (int i = 0; i < reversed.Length; i++)
        {
            reversed[i] = arr[arr.Length - 1 - i];
        }

        return new string(reversed);
    }
}


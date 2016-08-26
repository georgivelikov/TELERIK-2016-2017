using System;

public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();
        long result = 0;
        int pow = 0;
        for (int i = input.Length - 1; i >= 0; i--)
        {
            int current = int.Parse(input[i].ToString());
            result += (long)Math.Pow(2, pow) * current;
            pow++;
        }

        Console.WriteLine(result);
    }
}


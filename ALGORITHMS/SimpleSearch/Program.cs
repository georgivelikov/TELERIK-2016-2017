using System;

public class Program
{
    public static void Main()
    {
        string text = Console.ReadLine();
        string pattern = Console.ReadLine();
        int counter = 0;

        int m = pattern.Length;
        int n = text.Length;

        for (int i = 0; i <= n - m; i++)
        {
            bool matched = true;
            for (int j = 0; j < m; j++)
            {
                if (text[i + j] != pattern[j])
                {
                    matched = false;
                    break;
                }
            }

            if (matched)
            {
                counter++;
            }
        }

        Console.WriteLine(counter);
    }
}


using System;

public class Program
{
    public static void Main()
    {
        string text = Console.ReadLine();
        string pattern = Console.ReadLine();

        int n = text.Length;
        int m = pattern.Length;

        if (m > n)
        {
            return;
        }

        // precompute

        int[] failLinks = new int[m + 1];
        failLinks[0] = -1;

        for (int i = 1; i < m; i++)
        {
            int j = failLinks[i];
            while (j >= 0 && pattern[j] != pattern[i])
            {
                j = failLinks[j];
            }
            failLinks[i + 1] = j + 1;
        }

        // search

        int matched = 0;
        for (int i = 0; i < n; i++)
        {
            while (matched >= 0 && text[i] != pattern[matched])
            {
                matched = failLinks[matched];
            }

            matched++;

            if (matched == m)
            {
                Console.WriteLine("Matched at {0}", i - m + 1);
                matched = failLinks[matched];
            }
        }
    }
}


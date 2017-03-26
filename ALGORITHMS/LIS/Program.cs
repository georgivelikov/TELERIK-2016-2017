﻿
using System;
using System.Collections.Generic;

public class LongestIncreasingSubsequence
{
    public static void Main()
    {
        var sequence = new[] { 3, 14, 5, 12, 15, 7, 8, 9, 11, 10, 1 };
        var longestSeq = FindLongestIncreasingSubsequence(sequence);
        Console.WriteLine("Longest increasing subsequence (LIS)");
        Console.WriteLine("  Length: {0}", longestSeq.Length);
        Console.WriteLine("  Sequence: [{0}]", string.Join(", ", longestSeq));
    }

    public static int[] FindLongestIncreasingSubsequence(int[] sequence)
    {
        int[] len = new int[sequence.Length];
        int[] prev = new int[sequence.Length];
        int maxLen = 0;
        int lastIndex = -1;

        for (int i = 0; i < sequence.Length; i++)
        {
            len[i] = 1;
            prev[i] = -1;

            for (int j = 0; j < i; j++)
            {
                if (sequence[j] <= sequence[i] && len[j] + 1 >= len[i])
                {
                    len[i] = len[j] + 1;
                    prev[i] = j;
                }
            }

            if (len[i] > maxLen)
            {
                lastIndex = i;
                maxLen = len[i];
            }
        }

        var longestSeq = new List<int>();
        while (lastIndex != -1)
        {
            longestSeq.Add(sequence[lastIndex]);
            lastIndex = prev[lastIndex];
        }

        longestSeq.Reverse();

        return longestSeq.ToArray();
    }
}



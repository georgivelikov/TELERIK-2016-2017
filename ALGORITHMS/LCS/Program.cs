using System;
using System.Collections.Generic;

public class LongestCommonSubsequence
{
    public static void Main()
    {
        var firstStr = "tree";
        var secondStr = "team";

        var lcs = FindLongestCommonSubsequence(firstStr, secondStr);

        Console.WriteLine("Longest common subsequence:");
        Console.WriteLine("  first  = {0}", firstStr);
        Console.WriteLine("  second = {0}", secondStr);
        Console.WriteLine("  lcs    = {0}", lcs);
    }

    public static string FindLongestCommonSubsequence(string firstStr, string secondStr)
    {
        int firstLen = firstStr.Length + 1;
        int secondLen = secondStr.Length + 1;

        int[,] matrix = new int[firstLen, secondLen];
        for (int i = 1; i < firstLen; i++)
        {
            for (int j = 1; j < secondLen; j++)
            {
                if (firstStr[i - 1] == secondStr[j - 1])
                {
                    matrix[i, j] = matrix[i - 1, j - 1] + 1;
                }
                else
                {
                    matrix[i, j] = Math.Max(matrix[i - 1, j], matrix[i, j - 1]);
                }
            }
        }

        string result = RetrieveLCS(firstStr, secondStr, matrix);
        return result;
    }

    private static string RetrieveLCS(string firstStr, string secondStr, int[,] matrix)
    {
        List<char> sequence = new List<char>();
        int i = firstStr.Length;
        int j = secondStr.Length;

        while (i > 0 && j > 0)
        {
            if (firstStr[i - 1] == secondStr[j - 1])
            {
                sequence.Add(firstStr[i - 1]); // may be secondStr[j - 1], the same
                i--;
                j--;
            }
            else if (matrix[i, j] == matrix[i - 1, j])
            {
                i--;
            }
            else
            {
                j--;
            }
        }

        sequence.Reverse();

        return new string(sequence.ToArray());
    }

}



using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        string word = Console.ReadLine();
        string text = Console.ReadLine();

        string[] sentences = text.Split('.');
        HashSet<char> separators = new HashSet<char>();

        for (int i = 0; i < text.Length; i++)
        {
            char c = text[i];
            if (text[i] != '.' && !((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z')))
            {
                separators.Add(text[i]);
            }
        }

        StringBuilder result = new StringBuilder();
        char[] arr = new List<char>(separators).ToArray();

        foreach (var sentence in sentences)
        {
            string[] words = sentence.Split(arr, StringSplitOptions.RemoveEmptyEntries);

            foreach (var currentWord in words)
            {
                if (String.Compare(word, currentWord.Trim()) == 0)
                {
                    result.Append(sentence.Trim() + ". ");
                    break;
                }
            }
        }

        string final = result.ToString();
        final = Regex.Replace(final, "\\s+", " ");
        Console.WriteLine(final);
    }
}
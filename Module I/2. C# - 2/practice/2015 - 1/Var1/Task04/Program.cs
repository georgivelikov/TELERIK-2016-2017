using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Programm
{
    public static void Main()
    {
        Dictionary<string, List<string>> methodNames = new Dictionary<string, List<string>>();
        string currentMethodName = string.Empty;

        int n = int.Parse(Console.ReadLine());

        string line = string.Empty;
        int previousIndex = 0;

        for (int i = 0; i < n; i++)
        {
            line = Console.ReadLine();
            Regex reg = new Regex("\\s+");
            line = reg.Replace(line, " ");
            line = line.Trim();
            if (!line.Contains("("))
            {
                continue;
            }

            if (line.IndexOf("static") == 0)
            {
                string methodName = ExtractScopeMethodName(line);
                methodNames.Add(methodName, new List<string>());
                currentMethodName = methodName;
                continue;
            }

            for (int j = 0; j < line.Length; j++)
            {
                char c = line[j];
                if (c == '(')
                {
                    string name = ExractMethodName(line, j, previousIndex);
                    if (name != string.Empty)
                    {
                        methodNames[currentMethodName].Add(name);
                    }

                    previousIndex = j;
                }
            }

            previousIndex = 0;
        }

        foreach (var pair in methodNames)
        {
            if (pair.Value.Count == 0)
            {
                Console.WriteLine("{0} -> None", pair.Key);
            }
            else
            {
                Console.WriteLine("{0} -> {1} -> {2}", pair.Key, pair.Value.Count, string.Join(", ", pair.Value));
            }
        }
    }

    private static string ExtractScopeMethodName(string line)
    {
        int openingBracketIndex = line.IndexOf("(");
        List<char> list = new List<char>();
        char[] arr = line.ToCharArray();
        for (int i = openingBracketIndex - 1; i >= 0; i--)
        {
            char c = arr[i];
            if (arr[i] == ' ' && list.Count != 0)
            {
                break;
            }

            list.Add(c);
        }

        list.Reverse();
        char[] result = list.ToArray();
        string str = new string(result);
        return str.Trim();
    }

    private static string ExractMethodName(string line, int index, int previousIndex)
    {
        List<char> list = new List<char>();
        string newLine = line.Substring(previousIndex, index - previousIndex);
        if (newLine.Contains("new") || newLine.Contains(">"))
        {
            return string.Empty;
        }

        char[] arr = newLine.ToCharArray();
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            char c = arr[i];
            if ((c == ' ' || c == '.' || c == '(' || c == '!') && list.Count != 0)
            {
                break;
            }

            list.Add(c);
        }

        list.Reverse();
        if (list.Count == 0)
        {
            return string.Empty;
        }

        char checher = list[0];
        if (checher.ToString().ToLower() == list[0].ToString()) // check for (i =0; i < ......)
        {
            return string.Empty;
        }

        char[] result = list.ToArray();
        string str = new string(result);
        return str.Trim();
    }
}
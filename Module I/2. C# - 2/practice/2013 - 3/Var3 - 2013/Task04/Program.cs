using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    public static void Main()
    {
        Stack<string> scope = new Stack<string>();
        int n = int.Parse(Console.ReadLine());
        string[] ot = { "<upper>", "<lower>", "<toggle>", "<del>", "<rev>" };
        string[] ct = { "</upper>", "</lower>", "</toggle>", "</del>", "</rev>" };
        HashSet<string> openTags = new HashSet<string>(ot);
        HashSet<string> closeTags = new HashSet<string>(ct);
        StringBuilder tag = new StringBuilder();
        StringBuilder result = new StringBuilder();
        Dictionary<string, Stack<List<char>>> map = new Dictionary<string, Stack<List<char>>>();

        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();
            

            for (int j = 0; j < line.Length; j++)
            {
                char c = line[j];
                if (c == '<')
                {
                    tag.Clear();
                    tag.Append(c);
                    do
                    {
                        j++;
                        c = line[j];
                        tag.Append(c);
                    }
                    while (c != '>');
                    if (openTags.Contains(tag.ToString()))
                    {
                        scope.Push(tag.ToString());
                        if (!map.ContainsKey(tag.ToString()))
                        {
                            map.Add(tag.ToString(), new Stack<List<char>>());
                        }

                        map[tag.ToString()].Push(new List<char>());
                    }
                    else if (closeTags.Contains(tag.ToString()))
                    {
                        string currentTag = tag.ToString().Replace("/", string.Empty);
                        List<char> currentText = ApplyEffect(tag.ToString(), map[currentTag].Peek());
                        if (j == line.Length - 1)
                        {
                            currentText.Add('\n');
                        }
                        scope.Pop();
                        map[currentTag].Pop();
                        if (scope.Count == 0)
                        {
                            result.Append(new string(currentText.ToArray()));
                        }
                        else
                        {
                            map[scope.Peek()].Peek().AddRange(currentText);
                        }
                    }
                }
                else
                {
                    if (scope.Count == 0)
                    {
                        result.Append(c);
                        if (j == line.Length - 1)
                        {
                            result.Append('\n');
                        }
                    }
                    else
                    {
                        map[scope.Peek()].Peek().Add(c);
                        if (j == line.Length - 1)
                        {
                            map[scope.Peek()].Peek().Add('\n');
                        }
                    }
                }
            }
        }

        Console.WriteLine(result);
    }

    private static List<char> ApplyEffect(string tag, List<char> text)
    {
        List<char> result = new List<char>();
        if (tag == "</upper>")
        {
            result = text.Select(x => Char.ToUpper(x)).ToList();
        }
        else if (tag == "</rev>")
        {
            result = new List<char>(text);
            result.Reverse();
        }
        else if (tag == "</lower>")
        {
            result = text.Select(x => Char.ToLower(x)).ToList();
        }
        else if (tag == "</toggle>")
        {
            for (int i = 0; i < text.Count; i++)
            {
                char c = text[i];
                if (Char.IsLower(c))
                {
                    result.Add(Char.ToUpper(c));
                }
                else if (Char.IsUpper(c))
                {
                    result.Add(Char.ToLower(c));
                }
                else
                {
                    result.Add(c);
                }
            }
        }
        else if (tag == "</del>")
        {
            return result;
        }

        return result;
    }
}


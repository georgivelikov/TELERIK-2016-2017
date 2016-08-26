using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        string[] variables = {
                                "sbyte", "byte", "short", "ushort", "int", "uint", "long", "ulong",
                                "float", "double", "decimal", "bool", "char", "string"
                              };
        HashSet<string> set = new HashSet<string>(variables);

        Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
        map.Add("Methods", new List<string>());
        map.Add("Loops", new List<string>());
        map.Add("Conditional Statements", new List<string>());

        Regex regex = new Regex(@"(\w+)\s*\?*\s+(\w+)");
        Stack<string> stack = new Stack<string>();

        string currentScope = string.Empty;

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine().Trim();
            string[] arr = line.Split();
            string firstWord = arr[0];

            // method declaration
            if (firstWord == "static")
            {
                currentScope = "Methods";
                stack.Push(currentScope);
                int index = line.IndexOf("(");
                line = line.Substring(index);
                MatchCollection matches = regex.Matches(line);
                foreach (Match match in matches)
                {
                    string type = match.Groups[1].ToString();
                    if (set.Contains(type))
                    {
                        string name = match.Groups[2].ToString();
                        map[stack.Peek()].Add(name);
                    }
                }
            }
            // if-else declaration
            else if (firstWord == "if" || firstWord == "else")
            {
                currentScope = "Conditional Statements";
                stack.Push(currentScope);
                MatchCollection matches = regex.Matches(line);
                foreach (Match match in matches)
                {
                    string type = match.Groups[1].ToString();
                    if (set.Contains(type))
                    {
                        string name = match.Groups[2].ToString();
                        map[stack.Peek()].Add(name);
                    }
                }
            }
            // loop declaration
            else if (firstWord == "while" || firstWord == "for" || firstWord == "foreach")
            {
                currentScope = "Loops";
                stack.Push(currentScope);
                MatchCollection matches = regex.Matches(line);
                foreach (Match match in matches)
                {
                    string type = match.Groups[1].ToString();
                    if (set.Contains(type))
                    {
                        string name = match.Groups[2].ToString();
                        map[stack.Peek()].Add(name);
                    }
                }
            }
            // end of scope
            else if (firstWord == "}")
            {
                if (stack.Count > 0)
                {
                    stack.Pop();
                }

            }
            // in the scope of some of the above
            else
            {
                MatchCollection matches = regex.Matches(line);
                foreach (Match match in matches)
                {
                    string type = match.Groups[1].ToString();
                    if (set.Contains(type))
                    {
                        string name = match.Groups[2].ToString();
                        map[stack.Peek()].Add(name);
                    }
                }
            }
        }

        foreach (var pair in map)
        {
            if (pair.Value.Count == 0)
            {
                Console.WriteLine(pair.Key + " -> None");
            }
            else
            {
                Console.WriteLine(pair.Key + " -> " + pair.Value.Count + " -> " + string.Join(", ", pair.Value));
            }
            
        }
    }
}


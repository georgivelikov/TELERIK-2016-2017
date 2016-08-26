using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class Program
{
    private static char[] chars = { '+', '-', '=', '<', '>', '*', '\\', '%', '&', '^', '|' };
    private static HashSet<char> operators = new HashSet<char>(chars);

    private static char[] chars2 = { '.', ';', '!', '(', '[' };
    private static HashSet<char> marks = new HashSet<char>(chars2);

    public static void Main()
    {
        string[] splitPatterns = { "//" };
        int n = int.Parse(Console.ReadLine());
        List<string> list = new List<string>();
        int brackets = 0;

        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine().Trim();
            if (line == string.Empty)
            {
                continue;
            }

            StringBuilder sb = new StringBuilder();

            if (line.Contains('}'))
            {
                brackets--;
            }

            if (line.Contains('{'))
            {
                brackets++;
            }

            string[] str = line.Split(splitPatterns, StringSplitOptions.None);
            if (str.Length > 1)
            {
                string ss = "";

                if (str[0].Contains("{"))
                {
                   ss = new string(' ', 4 * (brackets - 1)) + "//" + str[1];
                }
                else
                {
                    ss = new string(' ', 4 * brackets) + "//" + str[1];
                }
               
                list.Add(ss);
                if (str[0].Trim() != string.Empty)
                {
                    line = str[0].Trim();
                }
                else
                {
                    continue;
                }
            }

            line = Regex.Replace(line, @"\s+", " ");

            if (line.Contains("{"))
            {
                line = new string(' ', (brackets - 1) * 4) + line + " ";
            }
            else
            {
                line = new string(' ', brackets * 4) + line + " ";
            }
 
            for (int j = 0; j < line.Length; j++)
            {
                char c = line[j];
                if (operators.Contains(c))
                {
                    if (line[j - 1] != ' ')
                    {
                        sb.Append(' ');
                    }

                    sb.Append(c);
                    if (line[j + 1] != ' ')
                    {
                        sb.Append(' ');
                    }
                }
                else if (marks.Contains(c))
                {
                    if (line[j - 1] == ' ' && sb[sb.Length - 1] == ' ')
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }

                    sb.Append(c);
                    if (line[j + 1] == ' ')
                    {
                        j++;
                    }
                }
                else if (c == ')' || c == ']')
                {
                    if (line[j - 1] == ' ')
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }

                    sb.Append(c);
                    if (line[j + 1] != ' ' && line[j + 1] != ';')
                    {
                        sb.Append(' ');
                    }
                }
                else if (c == ',')
                {
                    if (line[j - 1] == ' ')
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }

                    sb.Append(c);
                    if (line[j + 1] != ' ')
                    {
                        sb.Append(' ');
                    }
                }
                else
                {
                    sb.Append(c);
                }
            }
            string result = sb.ToString();

            result = Regex.Replace(result, @"(?<=[a-zA-Z])\s-\s(?=[a-zA-Z])", "-");
            result = Regex.Replace(result, @"(?<=[=+\*!&^%\|])\s+(?=[=+*\!=&^%\|])", string.Empty);
            result = Regex.Replace(result, "(?<=[^!])!(?=[a-zA-Z\'\"])", " !");
            result = Regex.Replace(result, "\\)\\s\\)", "))");
            result = Regex.Replace(result, "\\)\\s\\)", "))");
            list.Add(result.TrimEnd());
        }
        Console.WriteLine(  );
        Console.WriteLine(string.Join("\n", list).Trim());
    }
}


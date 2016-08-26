using System;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();
        Regex regex = new Regex(@"(\w+):\/\/([^\/]+)(.+)");
        Match match = regex.Match(input);
        Console.WriteLine("[protocol] = {0}", match.Groups[1]);
        Console.WriteLine("[server] = {0}", match.Groups[2]);
        Console.WriteLine("[resource] = {0}", match.Groups[3]);
    }
}


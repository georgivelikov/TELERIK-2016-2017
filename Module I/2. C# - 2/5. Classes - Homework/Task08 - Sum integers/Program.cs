using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Console.WriteLine(Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray().Sum());
    }
}


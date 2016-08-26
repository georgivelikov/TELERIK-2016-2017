using System;

public class Program
{
    public static void Main()
    {
        long p = long.Parse(Console.ReadLine());
        long n = long.Parse(Console.ReadLine());
        Console.WriteLine(Convert.ToString(p, 2).PadLeft(55, '0').ToCharArray()[55 - 1 - n]);
    }
}


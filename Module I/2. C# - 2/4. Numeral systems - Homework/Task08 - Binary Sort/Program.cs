using System;

public class Program
{
    public static void Main()
    {
        short num = short.Parse(Console.ReadLine());

        Console.WriteLine(Convert.ToString(num, 2).PadLeft(16, '0'));
    }
}

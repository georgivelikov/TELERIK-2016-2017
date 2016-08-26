using System;

public class Program
{
    public static void Main()
    {
        long x = long.Parse(Console.ReadLine());
        char[] arr = Convert.ToString(x, 2).PadLeft(32, '0').ToCharArray();
        Console.WriteLine(arr[arr.Length - 4]);
    }
}


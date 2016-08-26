using System;

public class Program
{
    public static void Main(string[] args)
    {
        int zeroCounter = 0;
        int n = int.Parse(Console.ReadLine());
        int i = 1;

        while (Math.Pow(5, i) < n)
        {
            zeroCounter += (int)n / (int)(Math.Pow(5, i));
            i++;
        }
        Console.WriteLine(zeroCounter);
    }
}



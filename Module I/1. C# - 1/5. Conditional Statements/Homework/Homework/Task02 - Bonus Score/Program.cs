using System;

public class Program
{
    public static void Main()
    {
        int a = int.Parse(Console.ReadLine());

        if (a > 0 && a <= 3)
        {
            Console.WriteLine(a * 10);
        }
        else if (a > 3 && a <= 6)
        {
            Console.WriteLine(a * 100);
        }
        else if (a > 6 && a <= 9)
        {
            Console.WriteLine(a * 1000);
        }
        else
        {
            Console.WriteLine("invalid score");
        }
    }
}


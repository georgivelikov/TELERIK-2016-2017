using System;

public class Program
{
    public static void Main()
    {
        int x = int.Parse(Console.ReadLine());
        if (x % 5 == 0 && x % 7 == 0)
        {
            Console.WriteLine("true {0}", x);
        }
        else
        {
            Console.WriteLine("false {0}", x);
        }
    }
}


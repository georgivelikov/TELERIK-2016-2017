using System;

class Program
{
    static void Main()
    {
        string x = Console.ReadLine();
        if (x.Length < 3)
        {
            Console.WriteLine("false 0");
            return;
        }

        if (x[x.Length - 3] == '7')
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine("false {0}", x[x.Length - 3]);
        }
    }
}


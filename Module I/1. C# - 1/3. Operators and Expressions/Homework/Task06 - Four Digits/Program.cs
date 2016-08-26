using System;
using System.Text;

public class Program
{
    public static void Main()
    {
        string str = Console.ReadLine();
        Console.WriteLine(int.Parse(str[0].ToString()) + int.Parse(str[1].ToString()) + int.Parse(str[2].ToString()) + int.Parse(str[3].ToString()));
        Console.WriteLine(str[3].ToString() + str[2] + str[1] + str[0]);
        Console.WriteLine(str[3].ToString() + str[0] + str[1] + str[2]);
        Console.WriteLine(str[0].ToString() + str[2] + str[1] + str[3]);
    }
}


using System;

public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();

        switch (input)
        {
            case "integer":
                int x = int.Parse(Console.ReadLine());
                Console.WriteLine(x + 1);
                return;
            case "real":
                double y = double.Parse(Console.ReadLine());
                Console.WriteLine("{0:f2}", y + 1);
                return;
            case "text":
                string str = Console.ReadLine();
                Console.WriteLine(str + "*");
                return;
        }
    }
}


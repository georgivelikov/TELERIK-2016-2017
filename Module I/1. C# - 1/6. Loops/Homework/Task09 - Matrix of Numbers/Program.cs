using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int counter = 1;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(j + counter + " ");
            }
            Console.WriteLine();
            counter++;
        }
    }
}


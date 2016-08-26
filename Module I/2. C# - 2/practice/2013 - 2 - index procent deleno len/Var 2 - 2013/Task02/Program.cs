using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int[] arr = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
        int maxPath = int.MinValue;
        int currentIndex = 0;
        int step = 0;
        int currentPath = 1;

        for (int k = 0; k < arr.Length; k++)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                currentIndex = k;
                currentPath = 1;
                step = i;

                while (true)
                {
                    int prev = arr[currentIndex];
                    currentIndex += step;

                    if (currentIndex >= arr.Length)
                    {
                        currentIndex = currentIndex % arr.Length;
                    }

                    int currentNum = arr[currentIndex];

                    if (currentNum <= prev)
                    {
                        if (currentPath > maxPath)
                        {
                            maxPath = currentPath;
                        }

                        break;
                    }

                    currentPath++;
                    prev = arr[currentIndex];
                }
            }
        }

        Console.WriteLine(maxPath);
    }
}


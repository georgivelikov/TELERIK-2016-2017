using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

public class Program
{
    private static bool[,] matrix;
    private static int[] list;
    private static bool[] set;
    private static int cats;
    private static int songs;
    private static Dictionary<int, int> start;
    private static int min = int.MaxValue;
    private static bool doesCatKnowSong = false;
    private static int counter = 0;

    public static void Main()
    {
        string[] lineOne = Console.ReadLine().Split();
        string[] lineTwo = Console.ReadLine().Split();
        cats = int.Parse(lineOne[0]);
        songs = int.Parse(lineTwo[0]);
        set = new bool[songs + 1];
        matrix = new bool[cats, songs];
        list = new int[cats];
        for (int i = 0; i < cats; i++)
        {
            list[i] = -1;
        }

        start = new Dictionary<int, int>();
        while (true)
        {
            string line = Console.ReadLine();
            if (line == "Mew!")
            {
                break;
            }

            string[] arr = line.Split();
            int catNumber = int.Parse(arr[1]);
            int songNumber = int.Parse(arr[4]);
            matrix[catNumber - 1, songNumber - 1] = true;
        }

        for (int i = 0; i < cats; i++)
        {
            doesCatKnowSong = false;
            for (int j = 0; j < songs; j++)
            {
                if (matrix[i, j])
                {
                    start.Add(i, j);
                    doesCatKnowSong = true;
                    break;
                }
            }

            if (!doesCatKnowSong)
            {
                Console.WriteLine("No concert!");
                return;
            }
        }

        Stopwatch s = new Stopwatch();
        s.Start();
        DFS(0);
        s.Stop();
        Console.WriteLine(min);
        Console.WriteLine(s.Elapsed);
    }

    private static void DFS(int cat)
    {
        for (int song = start[cat]; song < songs; song++)
        {
            if (matrix[cat, song] && list[cat] == -1)
            {
                list[cat] = song;
                if (cat == cats - 1)
                {
                    CountUnique();
                    if (counter < min)
                    {
                        min = counter;
                    }

                    counter = 0;
                }
                else
                {
                    DFS(cat + 1);
                }

                list[cat] = -1;
            }
        }
    }

    private static void CountUnique()
    {
        foreach (int item in list)
        {
            if (item != -1)
            {
                set[item] = true;
            }
        }

        foreach (var item in set)
        {
            if (item)
            {
                counter++;
            }
        }

        Array.Clear(set, 0, set.Length);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static string[] objects;
    private static string[] elements;
    private static List<string> helper = new List<string>();
    private static List<string> final = new List<string>();
    private static bool[] used;
    private static Dictionary<int, List<string>> walls = new Dictionary<int, List<string>>();
    private static bool[] takenWalls;
    private static int n;

    public static void Main()
    {
        n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            objects = Console.ReadLine().Split();
            walls.Add(i, new List<string>());
            var currentWallVariation = string.Format("({0})", string.Join(", ", objects));
            walls[i].Add(currentWallVariation);
            helper.Add(currentWallVariation);
            Array.Reverse(objects);
            currentWallVariation = string.Format("({0})", string.Join(", ", objects));
            walls[i].Add(currentWallVariation);
            helper.Add(currentWallVariation);
        }

        elements = new string[helper.Count];
        used = new bool[elements.Length + 1];
        takenWalls = new bool[n];

        for (int i = 0; i < helper.Count; i++)
        {
            elements[i] = helper[i];
        }

        var arr = new int[n];
        GenerateVariations(arr);

        Console.WriteLine(final.Count);
        final.Sort();

        foreach (var item in final)
        {
            Console.WriteLine(item);
        }
    }

    private static void GeneratePermutationsSecond(int start, int end, int wallNumber) // ARRAY SHOULD BE SORTED !!!!!!!!!!
    {
        PrintPermutations(wallNumber);

        for (int left = end - 1; left >= start; left--)
        {
            for (int right = left + 1; right <= end; right++)
            {
                if (objects[left] != objects[right])
                {
                    Swap(ref objects[left], ref objects[right]);
                    GeneratePermutationsSecond(left + 1, end, wallNumber);
                }
            }

            // Undo all modifications done by the
            // previous recursive calls and swaps
            var firstElement = objects[left];
            for (int i = left; i <= end - 1; i++)
            {
                objects[i] = objects[i + 1];
            }

            objects[end] = firstElement;
        }
    }

    private static void GenerateVariations(int[] arr, int index = 0)
    {
        if (index >= arr.Length)
        {
            PrintVariations(arr);
        }
        else
        {
            var unique = new HashSet<string>();
            for (int i = 0; i < elements.Length; i++)
            {
                if (!unique.Contains(elements[i]))
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        arr[index] = i;
                        GenerateVariations(arr, index + 1);
                        used[i] = false;
                        unique.Add(elements[i]);
                    }
                }
            }
        }
    }

    private static void PrintPermutations(int wallNumber)
    {
        var currentWallVariation = string.Format("({0})", string.Join(", ", objects));
        walls[wallNumber].Add(currentWallVariation);
        helper.Add(currentWallVariation);
    }

    private static void PrintVariations(int[] arr)
    {
        var currentFrame = arr.Select(i => elements[i]).ToArray();
        bool valid = true;

        for (int i = 0; i < currentFrame.Length; i++)
        {
            var currentWall = currentFrame[i];
            bool validWall = false;
            foreach (var wall in walls)
            {
                foreach (var wallVar in wall.Value)
                {
                    if(!takenWalls[wall.Key] && wallVar == currentWall)
                    {
                        takenWalls[wall.Key] = true;
                        validWall = true;
                        break;
                    }
                }

                if (validWall)
                {
                    break;
                }
            }

            if (!validWall)
            {
                valid = false;
                break;
            }
        }
        takenWalls = new bool[n];
        if (valid)
        {
            var curr = string.Join(" | ", currentFrame);
            final.Add(curr);
        }
        
    }

    private static void Swap<T>(ref T first, ref T second)
    {
        T oldFirst = first;
        first = second;
        second = oldFirst;
    }
}




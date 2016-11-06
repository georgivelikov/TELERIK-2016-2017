using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        const string EndComand = "END";
        const string FirstDimensionSymbol = "A";
        const string SecondDimensionSymbol = "B";
        const string ThirdDimensionSymbol = "C";
        const string ForthDimensionSymbol = "D";
        const string HarrySymbol = "@";

        int[] dimensions = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
        int[] harryCoordinates = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
        int countOfBasiliscs = int.Parse(Console.ReadLine());

        int movesCount = 0;
        
        SortedDictionary<string, int[]> basiliscHolder = new SortedDictionary<string, int[]>();

        for (int i = 0; i < countOfBasiliscs; i++)
        {
            string[] basiliscInput = Console.ReadLine().Split();
            string name = basiliscInput[0];
            int[] basiliscInputCoordinates = new int[4];
            basiliscInputCoordinates[0] = int.Parse(basiliscInput[1]);
            basiliscInputCoordinates[1] = int.Parse(basiliscInput[2]);
            basiliscInputCoordinates[2] = int.Parse(basiliscInput[3]);
            basiliscInputCoordinates[3] = int.Parse(basiliscInput[4]);
            basiliscHolder.Add(name, basiliscInputCoordinates);
        }

        while (true)
        {
            string command = Console.ReadLine();
            if (command == EndComand)
            {
                break;
            }

            string[] commandArgs = command.Split();
            string currentName = commandArgs[0];
            string dimensionAsString = commandArgs[1];
            int step = int.Parse(commandArgs[2]);
            int dimensionAsNumber = 0;

            if (dimensionAsString == FirstDimensionSymbol)
            {
                dimensionAsNumber = 0;
            }
            else if (dimensionAsString == SecondDimensionSymbol)
            {
                dimensionAsNumber = 1;
            }
            else if (dimensionAsString == ThirdDimensionSymbol)
            {
                dimensionAsNumber = 2;
            }
            else if (dimensionAsString == ForthDimensionSymbol)
            {
                dimensionAsNumber = 3;
            }

            if (currentName == HarrySymbol)
            {
                movesCount++;
                int currentIndex = harryCoordinates[dimensionAsNumber];
                if (step >= 0)
                {
                    currentIndex += step;
                    if (currentIndex >= dimensions[dimensionAsNumber])
                    {
                        currentIndex = dimensions[dimensionAsNumber] - 1;
                    }
                }
                else
                {
                    currentIndex += step;
                    if (currentIndex < 0)
                    {
                        currentIndex = 0;
                    }
                }

                harryCoordinates[dimensionAsNumber] = currentIndex;
            }
            else
            {
                int currentIndex = basiliscHolder[currentName][dimensionAsNumber];
                if (step >= 0)
                {
                    currentIndex += step;
                    if (currentIndex >= dimensions[dimensionAsNumber])
                    {
                        currentIndex = dimensions[dimensionAsNumber] - 1;
                    }
                }
                else
                {
                    currentIndex += step;
                    if (currentIndex < 0)
                    {
                        currentIndex = 0;
                    }
                }

                basiliscHolder[currentName][dimensionAsNumber] = currentIndex;
            }

            int[] basiliscCoordinates;
            if (currentName == HarrySymbol)
            {
                foreach (var basilisc in basiliscHolder)
                {
                    basiliscCoordinates = basilisc.Value;
                    if (basiliscCoordinates[0] == harryCoordinates[0] && basiliscCoordinates[1] == harryCoordinates[1] && basiliscCoordinates[2] == harryCoordinates[2]
                        && basiliscCoordinates[3] == harryCoordinates[3])
                    {
                        Console.WriteLine("{0}: \"Step {1} was the worst you ever made.\"", basilisc.Key, movesCount);
                        Console.WriteLine(
                            "{0}: \"You will regret until the rest of your life... All 3 seconds of it!\"",
                            basilisc.Key);
                        return;
                    }
                }
            }
            else
            {
                basiliscCoordinates = basiliscHolder[currentName];
                if (basiliscCoordinates[0] == harryCoordinates[0] && basiliscCoordinates[1] == harryCoordinates[1] && basiliscCoordinates[2] == harryCoordinates[2]
                    && basiliscCoordinates[3] == harryCoordinates[3])
                {
                    Console.WriteLine("{0}: \"You thought you could escape, didn't you?\" - {1}", currentName, movesCount);
                    return;
                }
            }
        }

        Console.WriteLine("@: \"I am the chosen one!\" - {0}", movesCount);
    }
}

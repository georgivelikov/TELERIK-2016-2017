using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int[] array = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
        List<double> pointsCollected = new List<double>();
        int currentIndex = 0;
        string stopCommand = "stop";
        string rightDirectionString = "right";

        while (true)
        {
            string command = Console.ReadLine();
            if (command == stopCommand)
            {
                break;
            }

            string[] commandArgs = command.Split();
            int repetitions = int.Parse(commandArgs[0]);
            int step = int.Parse(commandArgs[2]);
            string direction = commandArgs[1];
            double currentSum = 0;

            if (direction == rightDirectionString)
            {
                for (int i = 0; i < repetitions; i++)
                {
                    currentIndex = (currentIndex + step) % array.Length;
                    currentSum += array[currentIndex];
                }
            }
            else
            {
                for (int i = 0; i < repetitions; i++)
                {
                    if (currentIndex - (step % array.Length) >= 0)
                    {
                        currentIndex -= step % array.Length;
                        currentSum += array[currentIndex];
                    }
                    else
                    {
                        currentIndex = array.Length + currentIndex - (step % array.Length);
                        currentSum += array[currentIndex];
                    }
                }
            }

            pointsCollected.Add(currentSum);
        }


        Console.WriteLine("{0:0.0}", pointsCollected.Average());
    }
}


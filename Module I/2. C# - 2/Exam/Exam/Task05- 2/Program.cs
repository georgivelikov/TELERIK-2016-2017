using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

public class Program
{
    private static Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
    private static HashSet<int> visited = new HashSet<int>();
    private static BigInteger currentCounter = 0;
    private static BigInteger totalCounter = 0;

    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        bool[,] graph1 = new bool[n, n];
        bool[,] graph2 = new bool[n, n]; // pazi ot prepovtarqniq, primerno: 11-2 2-11 11-2

        for (int i = 0; i < n; i++)
        {
            graph.Add(i, new List<int>());
        }

        while (true)
        {
            string line = Console.ReadLine();
            if (line == "-1 -1")
            {
                break;
            }

            int[] arr = line.Split().Select(x => int.Parse(x)).ToArray();

            int targetRow = arr[0];
            int targetCol = arr[1];

            if (!graph1[targetRow, targetCol] && !graph2[targetRow, targetCol] && !graph2[targetCol, targetRow])
            {
                graph1[targetRow, targetCol] = true;
                graph2[targetRow, targetCol] = true;
                graph2[targetCol, targetRow] = true;
                
            }

            else
            {
                graph1[targetRow, targetCol] = false;
                graph1[targetCol, targetRow] = false;
            }
        }

        Print(graph1);

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (graph1[row, col])
                {
                    graph[row].Add(col);
                    graph[col].Add(row);
                }
            }
        }

        foreach (var item in graph)
        {
            DFS(item.Key);
            if (currentCounter > 1)
            {
                Console.WriteLine(currentCounter);
                totalCounter += CalculatePossibleFlights(currentCounter - 1);
            }

            currentCounter = 0;
        }

        Console.WriteLine(totalCounter);
    }

    private static void DFS(int node)
    {
        if (!visited.Contains(node))
        {
            currentCounter++;
            visited.Add(node);
            for (int i = 0; i < graph[node].Count; i++)
            {
                DFS(graph[node][i]);
            }
        }
    }

    private static BigInteger CalculatePossibleFlights(BigInteger currentCount)
    {
        BigInteger result = 0;
        for (int i = 1; i <= currentCount; i++)
        {
            BigInteger a = CalculateFactorial(currentCount);
            BigInteger b = CalculateFactorial(i);
            BigInteger c = CalculateFactorial(currentCount - i);

            result += a / (b * c);
        }

        return result;

    }

    private static BigInteger CalculateFactorial(BigInteger number)
    {
        BigInteger result = 1;
        for (int i = 1; i <= number; i++)
        {
            result *= i;
        }

        return result;
    }
    private static void Print(bool[,] matrix)
    {
        Console.ForegroundColor = ConsoleColor.White;
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            Console.Write(i.ToString().PadLeft(3, ' '));
        }

        Console.WriteLine();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(i.ToString().PadLeft(2, ' '));
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("T".PadRight(3, ' '));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("F ".PadRight(3, ' '));
                }
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}


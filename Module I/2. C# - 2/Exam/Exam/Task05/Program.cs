using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    private static HashSet<int> visited = new HashSet<int>();
    private static bool nodeFound = false;
    private static Dictionary<int, List<int>> graph;
    private static Dictionary<int, HashSet<int>> graph2;

    public static void Main()
    {
        graph = new Dictionary<int, List<int>>();
        graph2 = new Dictionary<int, HashSet<int>>();
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            graph.Add(i, new List<int>());
            graph2.Add(i, new HashSet<int>());
        }

        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();
            if (line == "None")
            {
                continue;
            }

            int[] arr = line.Split().Select(x => int.Parse(x)).ToArray();
            graph[i] = line.Split().Select(x => int.Parse(x)).ToList();
        }

        while (true)
        {
            string line = Console.ReadLine();
            if (line == "Have a break")
            {
                break;
            }
            int[] coordinates = line.Split().Select(x => int.Parse(x)).ToArray();
            int start = coordinates[0];
            int end = coordinates[1];

            if (graph[start].Count == 0)
            {
                Console.WriteLine("No flights available.");
            }
            else if (graph[start].Contains(end))
            {
                Console.WriteLine("There is a direct flight.");
            }
            else if (!graph[start].Contains(end))
            {
                DFS(start, end);
                if (nodeFound)
                {
                    Console.WriteLine("There are flights, unfortunately they are not direct, grandma :(");
                }
                else
                {
                    Console.WriteLine("No flights available.");
                }

                nodeFound = false;
                visited.Clear();
            }
        }
    }

    private static void DFS(int node, int searchedNode)
    {
        visited.Add(node);
        if (graph[node].Contains(searchedNode))
        {
            nodeFound = true;
            return;
        }
        else
        {
            for (int i = 0; i < graph[node].Count; i++)
            {
                if (!visited.Contains(graph[node][i]))
                {
                    DFS(graph[node][i], searchedNode);
                }
            }
        }
    }
}


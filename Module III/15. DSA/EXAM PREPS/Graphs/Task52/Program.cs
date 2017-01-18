using System;
using System.Collections.Generic;
using System.Linq;

namespace Task51
{
    public class Program
    {
        private static Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        private static HashSet<int> visited = new HashSet<int>();
        private static int n = 0;
        private static Dictionary<int, int> components = new Dictionary<int, int>();
        private static Dictionary<int, List<int>> components2 = new Dictionary<int, List<int>>();
        private static Dictionary<int, Dictionary<int, bool>> components3 = new Dictionary<int, Dictionary<int, bool>>();
        private static int counter = 0;
        private static int flightCounter = 0;

        public static void Main()
        {
            n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                graph.Add(i, new List<int>());
            }

            List<string> commands = new List<string>();
            while (true)
            {
                var line = Console.ReadLine();
                if (line == "-1 -1")
                {
                    break;
                }
                commands.Add(line);
                var list = line.Split().Select(int.Parse).ToList();
                graph[list[0]].Add(list[1]);
                graph[list[1]].Add(list[0]);
            }

            for (int i = 0; i < n; i++)
            {
                components2.Add(i, new List<int>());
                if (!visited.Contains(i))
                {
                    DFS(i, counter);
                    counter++;
                }
            }

            for (int i = 0; i < counter; i++)
            {
                for (int j = 0; j < components2[i].Count; j++)
                {
                    components3.Add(components2[i][j], new Dictionary<int, bool>());
                }
            }
            for (int i = 0; i < commands.Count; i++)
            {
                var line = commands[i];
                var list = line.Split().Select(int.Parse).ToList();
                var a = list[0];
                var b = list[1];


            }

            Console.WriteLine(flightCounter);
        }

        private static void DFS(int node, int counter)
        {
            if (!visited.Contains(node))
            {
                visited.Add(node);
                components.Add(node, counter);
                components2[counter].Add(node);
                for (int i = 0; i < graph[node].Count; i++)
                {
                    DFS(graph[node][i], counter);
                }
            }
        }
    }
}

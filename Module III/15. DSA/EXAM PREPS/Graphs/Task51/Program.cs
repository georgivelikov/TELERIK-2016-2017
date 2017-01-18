using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task51
{
    public class Program
    {
        private static Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        private static HashSet<int> visited = new HashSet<int>();
        private static HashSet<int>[] links;
        private static int n = 0;
        private static bool flag = false;
        private static Dictionary<int, int> components = new Dictionary<int, int>();
        private static int counter = 0;

        public static void Main()
        {
            n = int.Parse(Console.ReadLine());
            links = new HashSet<int>[n];

            for (int i = 0; i < n; i++)
            {
                graph.Add(i, new List<int>());
                links[i] = new HashSet<int>();
            }
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();

                if (line == "None")
                {
                    continue;
                }
                var list = line.Split().Select(int.Parse).ToList();
                for (int j = 0; j < list.Count; j++)
                {
                    graph[i].Add(list[j]);
                    graph[list[j]].Add(i);

                    links[i].Add(list[j]);
                    links[list[j]].Add(i);
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (!visited.Contains(i))
                {
                    DFS(i, counter);
                    counter++;
                }
            }


            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Have a break")
                {
                    break;
                }

                var coords = line.Split().Select(int.Parse).ToList();
                int a = coords[0];
                int b = coords[1];

                if (links[a].Contains(b))
                {
                    Console.WriteLine("There is a direct flight.");
                }
                else
                {

                    if (components[a] == components[b])
                    {
                        Console.WriteLine("There are flights, unfortunately they are not direct, grandma :(");
                    }
                    else
                    {
                        Console.WriteLine("No flights available.");
                    }
                }
            }
        }

        private static void DFS(int node, int counter)
        {
            if (!visited.Contains(node))
            {
                visited.Add(node);
                components.Add(node, counter);
                for (int i = 0; i < graph[node].Count; i++)
                {
                    DFS(graph[node][i], counter);
                }
            }
        }
    }
}

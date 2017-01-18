using System;
using System.Collections.Generic;
using System.Linq;

namespace Task01
{
    public class Program
    {
        static Dictionary<int, List<int>>graph = new Dictionary<int, List<int>>();
        static Dictionary<int, int> firstMap = new Dictionary<int, int>();
        static Dictionary<int, HashSet<int>> secondMap = new Dictionary<int, HashSet<int>>();
        static HashSet<int> visited = new HashSet<int>();
        static int firstCounter = 0;
        static int secondCounter = 0;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                graph.Add(i, new List<int>());
                firstMap.Add(i, 0);
                secondMap.Add(i, new HashSet<int>());

                string line = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    if(line[j] == '1')
                    {
                        graph[i].Add(j);
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                DFS(i, i);
                //Console.WriteLine(i + " -> " + visited.Count);
                if(visited.Count == n)
                {
                    firstCounter++;
                }
                visited.Clear();
            }

            var secondCounter = secondMap.Where(x => x.Value.Count == n - 1).Count();
            Console.WriteLine(firstCounter);
            Console.WriteLine(secondCounter);
        }

        private static void DFS(int node, int root)
        {
            if (!visited.Contains(node))
            {
                visited.Add(node);
                for (int i = 0; i < graph[node].Count; i++)
                {
                    DFS(graph[node][i], root);
                }
            }

            if (!secondMap[node].Contains(root) && node != root)
            {
                secondMap[node].Add(root);
            }
        }
    }
}

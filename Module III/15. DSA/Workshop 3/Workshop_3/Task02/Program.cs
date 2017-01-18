using System;
using System.Collections.Generic;

namespace _03.Diameter_Again
{
    public class Program
    {
        private static Dictionary<int, Dictionary<int, int>> tree;
        private static bool[] visited;
        private static int lastNode;
        private static long maxSum = -1;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            tree = new Dictionary<int, Dictionary<int, int>>();

            for (int i = 0; i < n - 1; i++)
            {
                string[] line = Console.ReadLine().Split();
                int firstNode = int.Parse(line[0]);
                int secondNode = int.Parse(line[1]);
                int weight = int.Parse(line[2]);

                if (!tree.ContainsKey(firstNode))
                {
                    tree.Add(firstNode, new Dictionary<int, int>());
                }
                tree[firstNode].Add(secondNode, weight);

                if (!tree.ContainsKey(secondNode))
                {
                    tree.Add(secondNode, new Dictionary<int, int>());
                }
                tree[secondNode].Add(firstNode, weight);
            }

            visited = new bool[n];
            DFS(0, 0);

            visited = new bool[n];
            DFS(lastNode, 0);

            Console.WriteLine(maxSum);
        }

        private static void DFS(int source, int sum)
        {
            visited[source] = true;

            foreach (var item in tree[source])
            {
                if (visited[item.Key])
                {
                    continue;
                }

                sum += item.Value;
                DFS(item.Key, sum);
                if (sum > maxSum)
                {
                    maxSum = sum;
                    lastNode = item.Key;
                }
                sum -= item.Value;
            }

            visited[source] = false;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Task02
{
    public class Program
    {
        static int[] nodes;
        static List<int>[] graph;
        static HashSet<int> visited = new HashSet<int>();
        static bool[] startNodes;
        static int[] memo;
        static int current = 0;
        static int max = 0;
        static int finalMax = 0;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            nodes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            startNodes = new bool[n];
            graph = new List<int>[n];
            memo = new int[n];

            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();

                string line = Console.ReadLine();

                if (line != "0")
                {
                    graph[i] = line.Split().Select(x => int.Parse(x) - 1).ToList();
                    for (int j = 0; j < graph[i].Count; j++)
                    {
                        startNodes[graph[i][j]] = true;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                max = DFS(i, 0);
                if (max > finalMax)
                {
                    finalMax = max;
                }

                memo[i] = max;
            }

            Console.WriteLine(finalMax);
        }

        public static int DFS(int nodeIndex, int sum)
        {
            if (visited.Contains(nodeIndex))
            {
                Console.WriteLine(-1);
                Environment.Exit(0);
            }

            sum = nodes[nodeIndex];
            visited.Add(nodeIndex);

            var currentBest = 0;
            for (int i = 0; i < graph[nodeIndex].Count; i++)
            {
                var currentSum = memo[graph[nodeIndex][i]] == 0 ? DFS(graph[nodeIndex][i], sum) : memo[graph[nodeIndex][i]];
                if(currentSum > currentBest)
                {
                    currentBest = currentSum;
                }
            }

            visited.Remove(nodeIndex);
            memo[nodeIndex] = sum + currentBest;
            return sum + currentBest;
        }
    }
}
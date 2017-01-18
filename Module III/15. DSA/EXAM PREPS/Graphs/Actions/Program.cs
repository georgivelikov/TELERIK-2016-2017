using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        // var customComparer = new CustomComparer();
        var graph = new List<List<int>>();

        int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = nm[0];
        int m = nm[1];

        for (int i = 0; i < n; i++)
        {
            graph.Add(new List<int>());
        }

        for (int i = 0; i < m; i++)
        {
            int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();

            graph[line[0]].Add(line[1]);
        }

        var sorter = new TopologicalSorter(graph);
        var result = sorter.TopSort();
        Console.WriteLine(string.Join("\n", result));
    }
}

// USE FUCKING DFS TOP SORT IDIOT WHEN NOT STRING
public class TopologicalSorter
{
    private List<List<int>> graph;

    public TopologicalSorter(List<List<int>> graph)
    {
        this.graph = graph;
    }

    public ICollection<int> TopSort()
    {
        return this.SourceRemoval();
    }

    private ICollection<int> SourceRemoval()
    {
        Dictionary<int, int> predecessorCount = new Dictionary<int, int>();
        for (int i = 0; i < this.graph.Count; i += 1)
        {
            if (!predecessorCount.ContainsKey(i))
            {
                predecessorCount[i] = 0;
            }

            foreach (var childNode in graph[i])
            {
                if (!predecessorCount.ContainsKey(childNode))
                {
                    predecessorCount[childNode] = 0;
                }

                predecessorCount[childNode]++;
            }
        }

        var removedNodes = new List<int>();
        while (true)
        {
            var nodeToRemove = 0;

            bool found = false;
            for (int i = 0; i < this.graph.Count; i++)
            {
                if (predecessorCount[i] == 0)
                {
                    nodeToRemove = i;
                    found = true;
                }
            }
            
            if (!found)
            {
                break;
            }

            foreach (var child in this.graph[nodeToRemove])
            {
                predecessorCount[child]--;
            }
            this.graph.RemoveAt(nodeToRemove);
            
            removedNodes.Add(nodeToRemove);
        }

        if (this.graph.Count > 0)
        {
            throw new InvalidOperationException("A cycle detected in the graph");
        }

        return removedNodes;
    }
}

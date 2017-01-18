using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        // var customComparer = new CustomComparer();
        var graph = new Dictionary<char, List<char>>();

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var line = Console.ReadLine().ToCharArray();

            for (int j = 0; j < line.Length; j++)
            {
                if (!graph.ContainsKey(line[j]))
                {
                    graph.Add(line[j], new List<char>());
                }
                for (int k = j + 1; k < line.Length; k++)
                {
                    graph[line[j]].Add(line[k]);
                }

                graph[line[j]].Sort();
            }
        }

        var sorter = new TopologicalSorter(graph);
        var result = sorter.TopSort();
        Console.WriteLine(string.Join("", result));
    }
}

// USE FUCKING DFS TOP SORT IDIOT WHEN NOT STRING
public class TopologicalSorter
{
    private SortedDictionary<char, List<char>> graph;

    public TopologicalSorter(IDictionary<char, List<char>> graph)
    {
        this.graph = new SortedDictionary<char, List<char>>(graph);
    }

    public ICollection<char> TopSort()
    {
        return this.SourceRemoval();
    }

    private ICollection<char> SourceRemoval()
    {
        Dictionary<char, int> predecessorCount = new Dictionary<char, int>();
        foreach (var node in this.graph)
        {
            if (!predecessorCount.ContainsKey(node.Key))
            {
                predecessorCount[node.Key] = 0;
            }

            foreach (var childNode in node.Value)
            {
                if (!predecessorCount.ContainsKey(childNode))
                {
                    predecessorCount[childNode] = 0;
                }

                predecessorCount[childNode]++;
            }
        }

        var removedNodes = new List<char>();
        while (true)
        {
            var nodeToRemove = this.graph.Keys.FirstOrDefault(x => predecessorCount[x] == 0);
            if (nodeToRemove == '\0')
            {
                break;
            }

            foreach (var child in this.graph[nodeToRemove])
            {
                predecessorCount[child]--;
            }

            this.graph.Remove(nodeToRemove);
            removedNodes.Add(nodeToRemove);
        }

        if (this.graph.Count > 0)
        {
            throw new InvalidOperationException("A cycle detected in the graph");
        }

        return removedNodes;
    }
}


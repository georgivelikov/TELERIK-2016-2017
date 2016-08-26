using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;

public class Program
{
    public static void Main()
    {
        // var customComparer = new CustomComparer();
        var graph = new Dictionary<string, List<string>>();

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] line = Console.ReadLine().Split();
            if (line[2] == "before")
            {
                if (!graph.ContainsKey(line[0]))
                {
                    graph.Add(line[0], new List<string>());
                }

                if (!graph.ContainsKey(line[3]))
                {
                    graph.Add(line[3], new List<string>());
                }

                graph[line[0]].Add(line[3]);
            }
            else
            {
                if (!graph.ContainsKey(line[3]))
                {
                    graph.Add(line[3], new List<string>());
                }

                if (!graph.ContainsKey(line[0]))
                {
                    graph.Add(line[0], new List<string>());
                }

                graph[line[3]].Add(line[0]);
            }
        }

        var sorter = new TopologicalSorter(graph);
        var result = sorter.TopSort();
        Console.WriteLine(string.Join("", result));
    }
}

public class TopologicalSorter
{
    private SortedDictionary<string, List<string>> graph;
    private HashSet<string> visitedNodes = new HashSet<string>(); // for DFS TopSort
    private LinkedList<string> sortedNodes = new LinkedList<string>(); // for DFS TopSort
    private List<string> cycleNodes = new List<string>(); // for DFS TopSort

    public TopologicalSorter(IDictionary<string, List<string>> graph)
    {
        this.graph = new SortedDictionary<string, List<string>>(graph); // could add custom comparer for the key
    }

    public ICollection<string> TopSort()
    {
        return this.SourceRemoval();
    }

    private ICollection<string> SourceRemoval()
    {
        Dictionary<string, int> predecessorCount = new Dictionary<string, int>();
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

        var removedNodes = new List<string>();
        while (true)
        {
            var nodeToRemove = this.graph.Keys.FirstOrDefault(x => predecessorCount[x] == 0);
            if (nodeToRemove == "0" && removedNodes.Count == 0)
            {
                nodeToRemove = this.graph.Keys.FirstOrDefault(x => predecessorCount[x] == 0 && x != "0");
            }

            if (nodeToRemove == null)
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

    private void TopSortDfs(string node)
    {
        if (this.cycleNodes.Contains(node))
        {
            throw new InvalidOperationException("A cycle detected in the graph");

        }

        if (!this.visitedNodes.Contains(node))
        {
            this.visitedNodes.Add(node);
            this.cycleNodes.Add(node);

            if (this.graph.ContainsKey(node))
            {
                foreach (var child in this.graph[node])
                {
                    this.TopSortDfs(child);
                }
            }

            this.cycleNodes.Remove(node);
            this.sortedNodes.AddFirst(node);
        }
    }
}


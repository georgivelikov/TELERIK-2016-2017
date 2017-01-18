using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    // 100/100
    public static void Main()
    {
        var graphForSort = new Dictionary<string, List<string>>();
        var graph = new Dictionary<string, List<string>>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();
            graph.Add(i.ToString(), new List<string>());

            for (int j = 0; j < n; j++)
            {
                if (!graphForSort.ContainsKey(j.ToString()))
                {
                    graphForSort.Add(j.ToString(), new List<string>());
                }
                if (line[j] == 'Y')
                {
                    graph[i.ToString()].Add(j.ToString());
                    graphForSort[j.ToString()].Add(i.ToString());
                }
            }
        }

        var sorter = new TopologicalSorter(graphForSort);
        var result = sorter.TopSort();
        // Console.WriteLine(string.Join(" - ", result));
        var memory = new long[n];
        long totalSum = 0;

        for (int i = 0; i < result.Count; i++)
        {
            var currentNode = result[i];
            var currentNodeIndex = int.Parse(result[i]);
            if (graph[currentNode].Count == 0)
            {
                memory[currentNodeIndex] = 1;
                totalSum += memory[currentNodeIndex];
            }
            else
            {
                long currentSum = 0;
                foreach (var item in graph[currentNode])
                {
                    var itemIndex = int.Parse(item);
                    currentSum += memory[itemIndex];
                }

                memory[currentNodeIndex] = currentSum;
                totalSum += currentSum;
            }
        }

        Console.WriteLine(totalSum);
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

    public IList<string> TopSort()
    {
        return this.SourceRemoval();
        //foreach (var node in this.graph.Keys)
        //{
        //    this.TopSortDfs(node);
        //}

        //return this.sortedNodes;
    }

    private IList<string> SourceRemoval()
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

            // Specific to the Bad Cat! problem, could be useful
            // if (nodeToRemove == "0" && removedNodes.Count == 0) 
            // {
            //     nodeToRemove = this.graph.Keys.FirstOrDefault(x => predecessorCount[x] == 0 && x != "0");
            // }
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

//public class CustomComparer : Comparer<string>
//{
//    public override int Compare(string x, string y)
//    {
//        if (x.CompareTo(y) > 0)
//        {
//            return -1;
//        }
//        else if (x.CompareTo(y) < 0)
//        {
//            return 1;
//        }
//        else
//        {
//            return 0;
//        }
//    }
//}

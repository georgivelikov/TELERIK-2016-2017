using System;
using System.Collections.Generic;
using System.Linq;

public class PrimAlgorithmPriorityQueue
{
    // Prim's mimimum spanning tree (MST) algorithm, implemented
    // with priority queue. Running time: O(M * log(M))
    // Learn more at: http://algs4.cs.princeton.edu/43mst/

    private static List<Edge> edges = new List<Edge>()
                                          {
                                              new Edge("C", "D", 20),
                                              new Edge("D", "B", 2),
                                              new Edge("D", "E", 8),
                                              new Edge("I", "H", 7),
                                              new Edge("B", "A", 4),
                                              new Edge("C", "E", 7),
                                              new Edge("G", "H", 8),
                                              new Edge("I", "G", 10),
                                              new Edge("A", "D", 9),
                                              new Edge("E", "F", 12),
                                              new Edge("C", "A", 5)
                                          };

    public static void Main()
    {
        var graph = BuildGraph();
        var spanningTreeNodes = new HashSet<string>();
        var spannngTreeEdges = new List<Edge>();

        // Start Prim's algorithm from each node not still in the spanning tree
        foreach (var startNode in graph.Keys)
        {
            if (!spanningTreeNodes.Contains(startNode))
            {
                Prim(graph, spanningTreeNodes, startNode, spannngTreeEdges);
            }
        }

        Console.WriteLine("Minimum spanning forest weight: " + spannngTreeEdges.Sum(e => e.Weight));
        foreach (var edge in spannngTreeEdges)
        {
            Console.WriteLine(edge);
        }
    }

    private static void Prim(
        Dictionary<string, List<Edge>> graph,
        HashSet<string> spanningTreeNodes,
        string startNode,
        List<Edge> spannngTreeEdges)
    {
        spanningTreeNodes.Add(startNode);
        var priorityQueue = new BinaryHeap<Edge>();
        foreach (var edge in graph[startNode])
        {
            priorityQueue.Enqueue(edge);
        }

        while (priorityQueue.Count > 0)
        {
            var smallestEdge = priorityQueue.ExtractMin();
            if (spanningTreeNodes.Contains(smallestEdge.StartNode) ^ spanningTreeNodes.Contains(smallestEdge.EndNode))
            {
                var nonTreeNode = spanningTreeNodes.Contains(smallestEdge.StartNode)
                                      ? smallestEdge.EndNode
                                      : smallestEdge.StartNode;
                spannngTreeEdges.Add(smallestEdge);
                spanningTreeNodes.Add(nonTreeNode);
                foreach (Edge newEdge in graph[nonTreeNode])
                {
                    if (newEdge != smallestEdge)
                    {
                        priorityQueue.Enqueue(newEdge);
                    }
                }
            }
        }
    }

    private static Dictionary<string, List<Edge>> BuildGraph()
    {
        var graph = new Dictionary<string, List<Edge>>();
        foreach (var edge in edges)
        {
            if (!graph.ContainsKey(edge.StartNode))
            {
                graph.Add(edge.StartNode, new List<Edge>());
            }
            graph[edge.StartNode].Add(edge);
            if (!graph.ContainsKey(edge.EndNode))
            {
                graph.Add(edge.EndNode, new List<Edge>());
            }
            graph[edge.EndNode].Add(edge);
        }

        return graph;
    }

    public class Edge : IComparable<Edge>
    {
        public string StartNode { get; set; }

        public string EndNode { get; set; }

        public int Weight { get; set; }

        public Edge(string startNode, string endNode, int weight)
        {
            this.StartNode = startNode;
            this.EndNode = endNode;
            this.Weight = weight;
        }

        public int CompareTo(Edge other)
        {
            int weightCompared = this.Weight.CompareTo(other.Weight);
            return weightCompared;
        }

        public override string ToString()
        {
            return string.Format("({0} {1}) -> {2}", this.StartNode, this.EndNode, this.Weight);
        }
    }

    public class BinaryHeap<T>
        where T : IComparable<T>
    {
        private List<T> heap;

        public BinaryHeap()
        {
            this.heap = new List<T>();
        }

        public BinaryHeap(T[] elements)
        {
            this.heap = new List<T>(elements);
            for (int i = this.heap.Count / 2; i >= 0; i--)
            {
                this.HeapifyDown(i);
            }
        }

        public int Count
        {
            get
            {
                return this.heap.Count;
            }
        }

        public T ExtractMin()
        {
            var min = this.heap[0];
            this.heap[0] = this.heap[heap.Count - 1];
            this.heap.RemoveAt(this.heap.Count - 1);
            if (this.heap.Count > 0)
            {
                this.HeapifyDown(0);
            }
            return min;
        }

        public T PeekMin()
        {
            var min = this.heap[0];
            return min;
        }

        public void Enqueue(T node)
        {
            this.heap.Add(node);
            this.HeapifyUp(this.heap.Count - 1);
        }

        private void HeapifyDown(int i)
        {
            var left = 2 * i + 1;
            var right = 2 * i + 2;
            var smallest = i;
            if (left < this.heap.Count && this.heap[left].CompareTo(this.heap[smallest]) < 0)
            {
                smallest = left;
            }
            if (right < this.heap.Count && this.heap[right].CompareTo(this.heap[smallest]) < 0)
            {
                smallest = right;
            }
            if (smallest != i)
            {
                T old = this.heap[i];
                this.heap[i] = this.heap[smallest];
                this.heap[smallest] = old;
                this.HeapifyDown(smallest);
            }
        }

        private void HeapifyUp(int i)
        {
            var parent = (i - 1) / 2;
            while (i > 0 && this.heap[i].CompareTo(this.heap[parent]) < 0)
            {
                T old = this.heap[i];
                this.heap[i] = this.heap[parent];
                this.heap[parent] = old;
                i = parent;
                parent = (i - 1) / 2;
            }
        }
    }
}

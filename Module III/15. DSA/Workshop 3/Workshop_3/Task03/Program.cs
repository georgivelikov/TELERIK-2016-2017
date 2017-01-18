using System;
using System.Collections.Generic;
using System.Linq;

public class PrimAlgorithmPriorityQueue
{
    private static List<Edge> edges = new List<Edge>();
    private static int[,] graph;
    private static int[,] b;
    private static int[,] d;
    private static bool[] used;
    private static int mst = 0;
    private static int n;
    public static void Main()
    {
        n = int.Parse(Console.ReadLine());
        graph = new int[n, n];
        b = new int[n, n];
        d = new int[n, n];
        used = new bool[n];

        for (int i = 0; i < n; i++)
        {
            char[] arr = Console.ReadLine().ToCharArray();
            for (int j = 0; j < arr.Length; j++)
            {
                graph[i, j] = arr[j] - '0';
            }
        }

        for (int i = 0; i < n; i++)
        {
            char[] arr = Console.ReadLine().ToCharArray();
            for (int j = 0; j < arr.Length; j++)
            {
                if (Char.IsUpper(arr[j]))
                {
                    b[i, j] = arr[j] - 'A';
                }
                else
                {
                    b[i, j] = arr[j] - 'a' + 26;
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            char[] arr = Console.ReadLine().ToCharArray();
            for (int j = 0; j < arr.Length; j++)
            {
                if (Char.IsUpper(arr[j]))
                {
                    d[i, j] = arr[j] - 'A';
                }
                else
                {
                    d[i, j] = arr[j] - 'a' + 26;
                }
            }
        }

        var visited = new HashSet<Edge>();


        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i < j && graph[i, j] == 1)
                {
                    mst += d[i, j];
                }
               
                graph[i, j] = graph[i, j] == 0 ? b[i, j] : -1 * d[i, j];
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {

                var edge = new Edge(i, j, graph[i, j]);
                edges.Add(edge);
                
            }
        }

        var minimumSpanningForest = KruskalAlgorithm.Kruskal(n, edges);

        long res = minimumSpanningForest.Sum(e => e.Weight) + mst;
        Console.WriteLine(res);

    }
    private static void Print(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(" " + matrix[i, j]);
            }

            Console.WriteLine();
        }
    }

    private static Dictionary<int, List<Edge>> BuildGraph()
    {
        var g = new Dictionary<int, List<Edge>>();
        foreach (var edge in edges)
        {
            if (!g.ContainsKey(edge.StartNode))
            {
                g.Add(edge.StartNode, new List<Edge>());
            }
            g[edge.StartNode].Add(edge);
            if (!g.ContainsKey(edge.EndNode))
            {
                g.Add(edge.EndNode, new List<Edge>());
            }
            g[edge.EndNode].Add(edge);
        }

        return g;
    }

    public class KruskalAlgorithm
    {
        public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
        {
            edges.Sort();

            var parent = new int[numberOfVertices];
            for (int i = 0; i < numberOfVertices; i++)
            {
                parent[i] = i;
            }

            var spanningTree = new List<Edge>();
            foreach (var edge in edges)
            {
                int rootStartNode = FindRoot(edge.StartNode, parent);
                int rootEndNode = FindRoot(edge.EndNode, parent);
                if (rootStartNode != rootEndNode)
                {
                    spanningTree.Add(edge);
                    parent[rootStartNode] = rootEndNode;
                }
            }

            return spanningTree;
        }

        public static int FindRoot(int node, int[] parent)
        {
            int root = node;
            while (parent[root] != root)
            {
                root = parent[root];
            }

            while (node != root)
            {
                var oldParent = parent[node];
                parent[node] = root;
                node = oldParent;
            }

            return root;
        }
    }
    public class Edge : IComparable<Edge>
    {
        public int StartNode { get; set; }

        public int EndNode { get; set; }

        public int Weight { get; set; }

        public Edge(int startNode, int endNode, int weight)
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

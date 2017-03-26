using System;
using System.Collections.Generic;
using System.Linq;

namespace Kruskal
{
    public class Program
    {
        public static void Main()
        {
            int numberOfVertices = 9;
            var graphEdges = new List<Edge>
            {
                new Edge(0, 3, 9),
                new Edge(0, 5, 4),
                new Edge(0, 8, 5),
                new Edge(1, 4, 8),
                new Edge(1, 7, 7),
                new Edge(2, 6, 12),
                new Edge(3, 5, 2),
                new Edge(3, 6, 8),
                new Edge(3, 8, 20),
                new Edge(4, 7, 10),
                new Edge(6, 8, 7)
            };

            var minimumSpanningForest = KruskalAlgorithm.Kruskal(numberOfVertices, graphEdges);

            Console.WriteLine("Minimum spanning forest weight: " +
                            minimumSpanningForest.Sum(e => e.Weight));

            foreach (var edge in minimumSpanningForest)
            {
                Console.WriteLine(edge);
            }
        }
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
                    parent[rootStartNode] = rootEndNode; // parent[rootEndNode] = rootStartNode; matter?
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
        public Edge(int startNode, int endNode, int weight)
        {
            this.StartNode = startNode;
            this.EndNode = endNode;
            this.Weight = weight;
        }

        public int StartNode { get; set; }

        public int EndNode { get; set; }

        public int Weight { get; set; }

        public int CompareTo(Edge other)
        {
            int weightCompared = this.Weight.CompareTo(other.Weight);
            return weightCompared;
        }

        public override string ToString()
        {
            return $"({this.StartNode} {this.EndNode}) -> {this.Weight}";
        }
    }
}

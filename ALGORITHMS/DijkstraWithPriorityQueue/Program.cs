using System.Collections.Generic;

namespace Dijkstra
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var nodes = new Dictionary<int, Node>();
            nodes.Add(0, new Node(0));
            nodes.Add(1, new Node(1));
            nodes.Add(2, new Node(2));
            nodes.Add(3, new Node(3));
            nodes.Add(4, new Node(4));
            nodes.Add(5, new Node(5));
            nodes.Add(6, new Node(6));
            nodes.Add(7, new Node(7));
            nodes.Add(8, new Node(8));
            nodes.Add(9, new Node(9));
            nodes.Add(10, new Node(10));
            nodes.Add(11, new Node(11));

            var graph = new Dictionary<Node, Dictionary<Node, int>>()
            {
                { nodes[0], new Dictionary<Node, int>() { { nodes[6], 10 }, { nodes[8], 12 } } },
                { nodes[1], new Dictionary<Node, int>() { { nodes[4], 20 }, { nodes[7], 26 }, { nodes[9], 5 }, { nodes[11], 6 } } },
                { nodes[2], new Dictionary<Node, int>() { { nodes[7], 15 }, { nodes[8], 14 }, { nodes[11], 9 } } },
                { nodes[3], new Dictionary<Node, int>() { { nodes[10], 7 } } },
                { nodes[4], new Dictionary<Node, int>() { { nodes[1], 20 }, { nodes[5], 5 }, { nodes[6], 17 }, { nodes[11], 11 } } },
                { nodes[5], new Dictionary<Node, int>() { { nodes[4], 5 }, { nodes[6], 6 }, { nodes[8], 3 }, { nodes[11], 33 } } },
                { nodes[6], new Dictionary<Node, int>() { { nodes[0], 10 }, { nodes[4], 17 }, { nodes[5], 6 } } },
                { nodes[7], new Dictionary<Node, int>() { { nodes[1], 26 }, { nodes[2], 15 }, { nodes[9], 3 }, { nodes[11], 20 } } },
                { nodes[8], new Dictionary<Node, int>() { { nodes[0], 12 }, { nodes[2], 14 }, { nodes[5], 3 } } },
                { nodes[9], new Dictionary<Node, int>() { { nodes[1], 5 }, { nodes[7], 3 } } },
                { nodes[10], new Dictionary<Node, int>() { { nodes[3], 7 } } },
                { nodes[11], new Dictionary<Node, int>() { { nodes[1], 6 }, { nodes[2], 9 }, { nodes[4], 11 }, { nodes[5], 33 }, { nodes[7], 20} } }
            };

            PrintPath(graph, nodes, 0, 9);
            PrintPath(graph, nodes, 0, 2);
            PrintPath(graph, nodes, 0, 10);
            PrintPath(graph, nodes, 0, 11);
            PrintPath(graph, nodes, 0, 1);
        }

        public static void PrintPath(Dictionary<Node, Dictionary<Node, int>> graph, Dictionary<int, Node> nodes, int sourceNode, int destinationNode)
        {
            Console.Write(
                "Shortest path [{0} -> {1}]: ",
                sourceNode,
                destinationNode);

            var path = DijkstraWithPriorityQueue.DijkstraAlgorithm(graph, nodes[sourceNode], nodes[destinationNode]);

            if (path == null)
            {
                Console.WriteLine("no path");
            }
            else
            {
                var formattedPath = string.Join("->", path);
                Console.WriteLine("{0} (length {1})", formattedPath, nodes[destinationNode].DistanceFromStart);
            }
        }
    }

    public class DijkstraWithPriorityQueue
    {
        public static List<int> DijkstraAlgorithm(Dictionary<Node, Dictionary<Node, int>> graph, Node sourceNode, Node destinationNode)
        {
            int[] previous = new int[graph.Count];
            bool[] visited = new bool[graph.Count];
            PriorityQueue<Node> priorityQueue = new PriorityQueue<Node>();

            for (int i = 0; i < previous.Length; i++)
            {
                previous[i] = -1;
            }

            sourceNode.DistanceFromStart = 0;
            priorityQueue.Enqueue(sourceNode);

            while (priorityQueue.Count > 0)
            {
                var currentNode = priorityQueue.ExtractMin();

                if (currentNode.Id == destinationNode.Id)
                {
                    break;
                }

                foreach (var edge in graph[currentNode])
                {
                    if (!visited[edge.Key.Id])
                    {
                        priorityQueue.Enqueue(edge.Key);
                        visited[edge.Key.Id] = true;
                    }

                    var distance = currentNode.DistanceFromStart + edge.Value;
                    if (distance < edge.Key.DistanceFromStart)
                    {
                        edge.Key.DistanceFromStart = distance;
                        previous[edge.Key.Id] = currentNode.Id;
                        priorityQueue.DecreaseKey(edge.Key);
                    }
                }
            }

            if (previous[destinationNode.Id] == -1)
            {
                return null;
            }

            List<int> path = new List<int>();
            int current = destinationNode.Id;
            while (current != -1)
            {
                path.Add(current);
                current = previous[current];
            }

            path.Reverse();
            return path;
        }
    }

    public class Node : IComparable<Node>
    {
        // set default value for the distance equal to positive infinity
        public Node(int id, double distance = double.PositiveInfinity)
        {
            this.Id = id;
            this.DistanceFromStart = distance;
        }

        public int Id { get; set; }

        public double DistanceFromStart { get; set; }

        public int CompareTo(Node other)
        {
            return this.DistanceFromStart.CompareTo(other.DistanceFromStart);
        }
    }

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private Dictionary<T, int> searchCollection;
        private List<T> heap;

        public PriorityQueue()
        {
            this.heap = new List<T>();
            this.searchCollection = new Dictionary<T, int>();
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
            var last = this.heap[this.heap.Count - 1];
            this.searchCollection[last] = 0;
            this.heap[0] = last;
            this.heap.RemoveAt(this.heap.Count - 1);
            if (this.heap.Count > 0)
            {
                this.HeapifyDown(0);
            }

            this.searchCollection.Remove(min);

            return min;
        }

        public T PeekMin()
        {
            return this.heap[0];
        }

        public void Enqueue(T element)
        {
            this.searchCollection.Add(element, this.heap.Count);
            this.heap.Add(element);
            this.HeapifyUp(this.heap.Count - 1);
        }

        private void HeapifyDown(int i)
        {
            var left = (2 * i) + 1;
            var right = (2 * i) + 2;
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
                this.searchCollection[old] = smallest;
                this.searchCollection[this.heap[smallest]] = i;
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
                this.searchCollection[old] = parent;
                this.searchCollection[this.heap[parent]] = i;
                this.heap[i] = this.heap[parent];
                this.heap[parent] = old;

                i = parent;
                parent = (i - 1) / 2;
            }
        }

        public void DecreaseKey(T element)
        {
            int index = this.searchCollection[element];
            this.HeapifyUp(index);
        }
    }
}

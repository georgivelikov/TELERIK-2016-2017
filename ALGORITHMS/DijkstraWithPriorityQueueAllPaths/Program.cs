using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem05___Friends_of_Pesho
{
    public class Program
    {
        //100/100
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(y => int.Parse(y)).ToArray();

            int n = numbers[0];
            int m = numbers[1];
            int h = numbers[2];

            var nodes = new Dictionary<int, Node>();

            for (int i = 0; i < n; i++)
            {
                nodes.Add(i + 1, new Node(i + 1));
            }

            int[] hospitals = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            for (int i = 0; i < hospitals.Length; i++)
            {
                nodes[hospitals[i]].IsHospital = true;
            }

            var graph = new Dictionary<Node, Dictionary<Node, int>>();
            for (int i = 0; i < n; i++)
            {
                graph.Add(nodes[i + 1], new Dictionary<Node, int>());
            }

            for (int i = 0; i < m; i++)
            {
                int[] inputEdge = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

                graph[nodes[inputEdge[0]]].Add(nodes[inputEdge[1]], inputEdge[2]);
                graph[nodes[inputEdge[1]]].Add(nodes[inputEdge[0]], inputEdge[2]);
            }

            var min = int.MaxValue;

            var hospitalsSet = new HashSet<int>(hospitals);
            var firstNotHospital = nodes.FirstOrDefault(x => !x.Value.IsHospital).Key;

            for (int i = 0; i < hospitals.Length; i++)
            {
                var currentHospital = hospitals[i];
                var allPaths = DijkstraWithPriorityQueue.DijkstraAlgorithm(graph, nodes[currentHospital], nodes[firstNotHospital]);
                var currentPath = 0;

                for (int j = 0; j < allPaths.Length; j++)
                {
                    if (!nodes[j + 1].IsHospital)
                    {
                        currentPath += allPaths[j];
                    }
                }

                for (int k = 0; k < n; k++)
                {
                    nodes[k + 1].DistanceFromStart = double.PositiveInfinity;
                }

                if (currentPath < min && currentPath != 0)
                {
                    min = currentPath;
                }
            }

            Console.WriteLine(min);
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

        public static int FindMinPath(Dictionary<Node, Dictionary<Node, int>> graph, Dictionary<int, Node> nodes, int sourceNode, int destinationNode)
        {
            var path = DijkstraWithPriorityQueue.DijkstraAlgorithm(graph, nodes[sourceNode], nodes[destinationNode]);

            if (path == null)
            {
                return 0;
            }
            else
            {
                return (int)nodes[destinationNode].DistanceFromStart;
            }
        }

        public class DijkstraWithPriorityQueue
        {
            public static int[] DijkstraAlgorithm(Dictionary<Node, Dictionary<Node, int>> graph, Node sourceNode, Node destinationNode)
            {
                int[] previous = new int[graph.Count];
                bool[] visited = new bool[graph.Count];
                PriorityQueue<Node> priorityQueue = new PriorityQueue<Node>();
                int[] paths = new int[graph.Count];

                for (int i = 0; i < previous.Length; i++)
                {
                    previous[i] = -1;
                }

                sourceNode.DistanceFromStart = 0;
                priorityQueue.Enqueue(sourceNode);

                while (priorityQueue.Count > 0)
                {
                    var currentNode = priorityQueue.ExtractMin();

                    //if (currentNode.Id == destinationNode.Id)
                    //{
                    //    break;
                    //}

                    foreach (var edge in graph[currentNode])
                    {
                        if (!visited[edge.Key.Id])
                        {
                            
                            visited[edge.Key.Id] = true;
                            priorityQueue.Enqueue(edge.Key);
                        }

                        var distance = currentNode.DistanceFromStart + edge.Value;
                        if (distance < edge.Key.DistanceFromStart && !edge.Key.IsHospital)
                        {
                            edge.Key.DistanceFromStart = distance;
                            previous[edge.Key.Id] = currentNode.Id;
                            priorityQueue.DecreaseKey(edge.Key);
                            paths[edge.Key.Id] = (int)distance;
                        }
                    }
                }

                //if (previous[destinationNode.Id] == -1)
                //{
                //    return null;
                //}
                 
                Console.WriteLine(string.Join(" ", paths));

                return paths;
            }
        }

        public class Node : IComparable<Node>
        {
            // set default value for the distance equal to positive infinity
            public Node(int id, double distance = double.PositiveInfinity)
            {
                this.Id = id - 1;
                this.DistanceFromStart = distance;
            }

            public int Id { get; set; }

            public double DistanceFromStart { get; set; }

            public bool IsHospital { get; set; }

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
}

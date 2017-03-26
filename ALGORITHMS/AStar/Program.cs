namespace AStarAlgorithm
{
    using System;
    using System.Collections.Generic;

    public class Programm
    {

        //private static char[,] map =
        //{
        //    { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
        //    { '-', '-', '-', 'W', '*', '-', '-', '-', '-', '-', '-' },
        //    { '-', '-', '-', 'W', 'W', 'W', 'W', 'W', '-', '-', '-' },
        //    { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
        //    { '-', '-', '-', '-', '-', '-', '-', 'P', '-', '-', '-' },
        //    { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' }
        //};

        private static char[,] map =
        {
                    { '-', '-', '-', '-', '-' },
                    { '-', '-', '*', '-', '-' },
                    { '-', 'W', 'W', 'W', '-' },
                    { '-', '-', '-', '-', '-' },
                    { '-', '-', 'P', '-', '-' },
                    { '-', '-', '-', '-', '-' }
         };

        //private static char[,] map =
        //{
        //    { '-', '-', '-', '-', 'W', '-', '-', '-', 'W', '*', '-' },
        //    { '-', 'W', '-', '-', 'W', '-', '-', '-', 'W', '-', '-' },
        //    { 'P', '-', 'W', '-', 'W', '-', '-', '-', 'W', '-', '-' },
        //    { '-', 'W', '-', '-', 'W', 'W', 'W', '-', 'W', 'W', '-' },
        //    { '-', '-', '-', 'W', 'W', '-', '-', '-', '-', 'W', '-' },
        //    { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' }
        //};

        static void Main()
        {
            var playerCoords = FindObjectCoordinates('P');
            var destinationCoords = FindObjectCoordinates('*');

            var aStar = new AStar(map);
            var cells = aStar.FindShortestPath(playerCoords, destinationCoords);
            foreach (var cellInPath in cells)
            {
                var row = cellInPath[0];
                var col = cellInPath[1];
                map[row, col] = '@';
            }

            PrintMap();
        }

        static int[] FindObjectCoordinates(char obj)
        {
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    if (map[row, col] == obj)
                    {
                        return new[] { row, col };
                    }
                }
            }

            throw new ArgumentException("Object not present on map");
        }

        static void PrintMap()
        {
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    if (map[row, col] == '@')
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }

                    Console.Write(map[row, col]);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" ");
                }

                Console.WriteLine();
            }
        }
    }

    public class AStar
    {
        private readonly PriorityQueue<Node> openNodesByFCost;
        private readonly HashSet<Node> closedSet;
        private readonly char[,] map;
        private readonly Node[,] graph;


        public AStar(char[,] map)
        {
            this.map = map;
            this.closedSet = new HashSet<Node>();
            this.openNodesByFCost = new PriorityQueue<Node>();
            this.graph = new Node[map.GetLength(0), map.GetLength(1)];
        }

        public List<int[]> FindShortestPath(int[] startCoords, int[] endCoords)
        {
            var startNode = this.GetNode(startCoords[0], startCoords[1]);
            startNode.GCost = 0;
            this.openNodesByFCost.Enqueue(startNode);

            while (this.openNodesByFCost.Count > 0)
            {
                var currentNode = this.openNodesByFCost.ExtractMin();
                this.closedSet.Add(currentNode);

                if (currentNode.Row == endCoords[0] && currentNode.Col == endCoords[1])
                {
                    return ReconstructPath(currentNode);
                }

                var neighbours = this.GetNeighbours(currentNode);
                foreach (var neighbour in neighbours)
                {
                    if (this.closedSet.Contains(neighbour))
                    {
                        continue;
                    }

                    var gCost = currentNode.GCost + this.CalculateGCost(neighbour, currentNode);
                    if (gCost < neighbour.GCost)
                    {
                        neighbour.GCost = gCost;
                        neighbour.Parent = currentNode;
                        if (!this.openNodesByFCost.Contains(neighbour))
                        {
                            neighbour.HCost = this.CalculateHCost(neighbour, endCoords);
                            this.openNodesByFCost.Enqueue(neighbour);
                        }
                        else
                        {
                            this.openNodesByFCost.DecreaseKey(neighbour);
                        }
                    }
                }
            }

            return new List<int[]>(0);
        }

        private int CalculateHCost(Node neighbour, int[] endCoords)
        {
            return this.GetDistance(neighbour.Row, neighbour.Col, endCoords[0], endCoords[1]);
        }

        private int CalculateGCost(Node node, Node prev)
        {
            return this.GetDistance(node.Row, node.Col, prev.Row, prev.Col);
        }

        private int GetDistance(int r1, int c1, int r2, int c2)
        {
            var deltaX = Math.Abs(c1 - c2);
            var deltaY = Math.Abs(r1 - r2);

            if (deltaX > deltaY)
            {
                return 14 * deltaY + 10 * (deltaX - deltaY);
            }

            return 14 * deltaX + 10 * (deltaY - deltaX);
        }

        private List<Node> GetNeighbours(Node node)
        {
            var neighbours = new List<Node>();

            var maxRow = this.graph.GetLength(0);
            var maxCol = this.graph.GetLength(1);
            for (int row = node.Row - 1; row <= node.Row + 1 && row < maxRow; row++)
            {
                if (row < 0)
                {
                    continue;
                }
                for (int col = node.Col - 1; col <= node.Col + 1 && col < maxCol; col++) //!!!!!!!!!!Char for WALL!!!!!!!!!!
                {
                    if (col < 0 || this.map[row, col] == 'W' || (node.Row == row && node.Col == col))
                    {
                        continue;
                    }

                    var neighbour = this.GetNode(row, col);
                    neighbours.Add(neighbour);
                }
            }

            return neighbours;
        }

        private Node GetNode(int row, int col)
        {
            return this.graph[row, col] ?? (this.graph[row, col] = new Node(row, col));
        }

        private static List<int[]> ReconstructPath(Node currentNode)
        {
            var cells = new List<int[]>();
            while (currentNode != null)
            {
                cells.Add(new[] { currentNode.Row, currentNode.Col });
                currentNode = currentNode.Parent;
            }

            return cells;
        }
    }

    internal class Node : IComparable<Node>
    {
        public Node(int row, int col)
        {
            this.Row = row;
            this.Col = col;
            this.GCost = int.MaxValue;
            this.HCost = int.MaxValue;
        }

        public Node(int col, int row, Node parent)
            : this(col, row)
        {
            this.Parent = parent;
        }

        public int Col { get; set; }

        public int Row { get; set; }

        public Node Parent { get; set; }

        public int HCost { get; set; }

        public int GCost { get; set; }

        public List<Node> Neighbours { get; set; }

        public override bool Equals(object obj)
        {
            var other = (Node)obj;

            return this.Col == other.Col && this.Row == other.Row;
        }

        public int FCost
        {
            get
            {
                return this.HCost + GCost;
            }
        }

        public int CompareTo(Node other)
        {
            if (this.FCost == other.FCost)
            {
                return this.HCost.CompareTo(other.HCost);
            }

            return this.FCost.CompareTo(other.FCost);
        }

        public override string ToString()
        {
            return string.Format("({0},{1}), G:{2}, H:{3}, F:{4}",
                this.Row, this.Col, this.GCost, this.HCost, this.FCost);
        }
    }

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private readonly Dictionary<T, int> searchCollection;
        private readonly List<T> heap;

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

        public bool Contains(T node)
        {
            return this.searchCollection.ContainsKey(node);
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

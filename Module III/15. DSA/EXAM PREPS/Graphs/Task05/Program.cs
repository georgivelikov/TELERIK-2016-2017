using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static List<int> path = new List<int>();

    public static void Main()
    {
        int verticeCount = int.Parse(Console.ReadLine());

        var edges = new List<Edge>();

        while (true)
        {
            string line = Console.ReadLine();

            if (line == string.Empty)
            {
                break;
            }

            var arr = line.Split(' ').Select(int.Parse).ToArray();
            var edge = new Edge(arr[0], arr[1], arr[2]);
            edges.Add(edge);
        }

        var startNode = 0;
        var destination = verticeCount - 1;
        var result = FindShortestPathBellmanFord(startNode, destination, verticeCount, edges);

        Console.WriteLine("Value: " + result.Item1);
        Console.WriteLine("Path: " + result.Item2);
    }

    private static Tuple<int, string> FindShortestPathBellmanFord(int startNode, int destination, int verticeCount, List<Edge> edges)
    {
        var distance = new long[verticeCount];
        var previous = new int[verticeCount];
        for (int i = 0; i < distance.Length; i++)
        {
            distance[i] = int.MaxValue;
            previous[i] = -1;
        }

        distance[startNode] = 0;
        bool continueAlg = true;
        for (int i = 0; i < verticeCount - 1 && continueAlg; i++)
        {
            continueAlg = false;
            foreach (Edge edge in edges)
            {
                if (distance[edge.Start] + edge.Distance < distance[edge.End])
                {
                    distance[edge.End] = distance[edge.Start] + edge.Distance;
                    previous[edge.End] = edge.Start;
                    continueAlg = true;
                }
            }
        }

        for (int i = 0; i < verticeCount - 1; i++)
        {
            foreach (Edge edge in edges)
            {
                if (distance[edge.Start] + edge.Distance < distance[edge.End])
                {
                    Console.WriteLine("Negative cycle");
                    Environment.Exit(0);
                }
            }
        }

        var dis = (int)distance[destination];
        if(dis == int.MaxValue)
        {
            Console.WriteLine("Could not reach last vertex");
            Environment.Exit(0);
        }
        int current = destination;
        while (current != -1)
        {
            path.Add(current);
            current = previous[current];
        }

        path.Reverse();

        return new Tuple<int, string>(dis, string.Join(" > ", path));
    }
}

public class Edge
{
    public Edge(int start, int end, int distance)
    {
        this.Start = start;
        this.End = end;
        this.Distance = distance;
    }

    public int Start { get; set; }

    public int End { get; set; }

    public int Distance { get; set; }
}



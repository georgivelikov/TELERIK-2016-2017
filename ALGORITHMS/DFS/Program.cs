using System;
using System.Collections.Generic;

public class Program
{
    private static List<string> nodeNames;
    private static List<List<int>> childNodes;
    private static HashSet<int> visited;

    // Works with connected graph only
    // Other way is with Dictionary<string, List<string>>
    public static void Main()
    {
        string[] names = { "Ruse", "Sofia", "Pleven", "Varna", "Bourgas", "Stara Zagora", "Plovdiv" };
        nodeNames = new List<string>(names);

        childNodes = new List<List<int>>();
        childNodes.Add(new List<int> { 3, 6 }); // children of node 0 (Ruse)
        childNodes.Add(new List<int> { 2, 3, 4, 5, 6 }); // successors of node 1 (Sofia)
        childNodes.Add(new List<int> { 1, 4, 5 }); // successors of node 2 (Pleven)
        childNodes.Add(new List<int> { 0, 1, 5 }); // successors of node 3 (Varna)
        childNodes.Add(new List<int> { 1, 2, 6 }); // successors of node 4 (Bourgas)
        childNodes.Add(new List<int> { 1, 2, 3 }); // successors of node 5 (Stara Zagora)
        childNodes.Add(new List<int> { 0, 1, 4 }); // successors of node 6 (Plovdiv)

        visited = new HashSet<int>();

        // Start DFS from node 4 (Bourgas)
        DFS(4);
    }

    private static void DFS(int node)
    {
        if (!visited.Contains(node))
        {
            visited.Add(node);
            Console.WriteLine("{0} ({1})", node, nodeNames[node]);
            for (int i = 0; i < childNodes[node].Count; i++)
            {
                DFS(childNodes[node][i]);
            }
        }
    }
}

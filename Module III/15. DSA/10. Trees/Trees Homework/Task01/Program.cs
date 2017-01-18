using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();
    private static Stack<int> currentPathStack = new Stack<int>();
    private static List<int> maxPathList = new List<int>();

    private static Stack<int> currentPathOfSumStack = new Stack<int>();
    private static List<Stack<int>> pathsOfSum = new List<Stack<int>>();

    private static List<int> curentSubtreeList = new List<int>();
    private static List<List<int>> subtreesOfSum = new List<List<int>>();

    public static void Main()
    {
        Console.WriteLine("Enter number of nodes:");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter edges:");
        for (int i = 0; i < n - 1; i++)
        {
            string[] input = Console.ReadLine().Split();
            int parentValue = int.Parse(input[0]);
            Tree<int> parentNode = GetTreeNodeByValue(parentValue);
            int childValue = int.Parse(input[1]);
            Tree<int> childNode = GetTreeNodeByValue(childValue);
            parentNode.Children.Add(childNode);
            childNode.Parent = parentNode;
        }

        Console.WriteLine("Enter sum for paths: ");
        int p = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter sum for subtrees: ");
        int s = int.Parse(Console.ReadLine());

        var rootNode = FindRootNode();
        Console.WriteLine($"Root node: {rootNode}");

        var leafNodes = FindAllLeafs();
        Console.WriteLine($"Leaf nodes: {String.Join(", ", leafNodes)}");

        var middleNodes = FindAllMiddleNodes();
        Console.WriteLine($"Middle nodes: {String.Join(", ", middleNodes)}");

        FindLongestPath(rootNode);
        Console.WriteLine("{0} (length = {1})", String.Join(" -> ", maxPathList), maxPathList.Count);

        PathsOfSum(rootNode, p);
        Console.WriteLine("Paths of sum {0}:", p);
        foreach (var list in pathsOfSum)
        {
            Console.WriteLine(String.Join(" -> ", list));
        }

        var parents = nodeByValue.Values.Where(node => node.Children.Count > 0).ToList();
        foreach (var parent in parents)
        {
            FindSubtreeElements(parent);
            if (curentSubtreeList.Sum() == s)
            {
                subtreesOfSum.Add(new List<int>(curentSubtreeList));
            }
            curentSubtreeList.Clear();
        }

        Console.WriteLine("Subtrees of sum {0}:", s);
        foreach (var list in subtreesOfSum)
        {
            Console.WriteLine(String.Join(" + ", list));
        }
    }

    private static Tree<int> FindRootNode()
    {
        var rootNode = nodeByValue.Values.FirstOrDefault(node => node.Parent == null);
        return rootNode;
    }

    private static IEnumerable<Tree<int>> FindAllLeafs()
    {
        var leafNodes = nodeByValue.Values.Where(node => node.Parent != null && node.Children.Count == 0).ToList();
        return leafNodes.OrderBy(node => node.Value);
    }

    private static IEnumerable<Tree<int>> FindAllMiddleNodes()
    {
        var middleNodes = nodeByValue.Values.Where(node => node.Parent != null && node.Children.Count > 0).ToList();
        return middleNodes.OrderBy(node => node.Value);
    }

    private static Tree<int> GetTreeNodeByValue(int value)
    {
        if (!nodeByValue.ContainsKey(value))
        {
            nodeByValue[value] = new Tree<int>(value);
        }

        return nodeByValue[value];
    }

    private static void FindLongestPath(Tree<int> startNode)
    {
        currentPathStack.Push(startNode.Value);
        if (startNode.Children.Count > 0)
        {
            foreach (var child in startNode.Children)
            {
                FindLongestPath(child);
            }
        }
        else
        {
            if (currentPathStack.Count > maxPathList.Count)
            {
                maxPathList = new List<int>(currentPathStack);
            }
        }

        currentPathStack.Pop();
    }

    private static void PathsOfSum(Tree<int> startNode, int sum)
    {
        currentPathOfSumStack.Push(startNode.Value);
        if (startNode.Children.Count > 0)
        {
            foreach (var child in startNode.Children)
            {
                PathsOfSum(child, sum);
            }
        }
        else
        {
            if (currentPathOfSumStack.Sum() == sum)
            {
                var stack = new Stack<int>(currentPathOfSumStack);
                pathsOfSum.Add(stack);
            }
        }

        currentPathOfSumStack.Pop();
    }

    private static void FindSubtreeElements(Tree<int> parent)
    {
        curentSubtreeList.Add(parent.Value);
        foreach (var child in parent.Children)
        {
            FindSubtreeElements(child);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Task22
{
    public class Program
    {
        static List<int>[] nodes;
        static HashSet<int> visited = new HashSet<int>();
        static int currentPath = 0;
        static int maxPath = 0;
        static int lastNodeNumber = 0;
        static int[] vals;
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            nodes = new List<int>[n];
            vals = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            for (int i = 1; i <= n; i++)
            {
                nodes[i - 1] = new List<int>();
            }

            for (int i = 0; i < n - 1; i++)
            {
                int[] links = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var firstNode = links[0];
                var secondNode = links[1];

                nodes[firstNode - 1].Add(secondNode);
                nodes[secondNode - 1].Add(firstNode);
            }

            //Console.WriteLine(string.Join(" ", nodes));
            DFS(1);
            //Console.WriteLine(maxPath);
            visited.Clear();
            currentPath = 0;
            maxPath = 0;

            DFS(lastNodeNumber);
            Console.WriteLine(maxPath);  
        }

        public static void DFS(int nodeNumber)
        {
            if (!visited.Contains(nodeNumber))
            {
                visited.Add(nodeNumber);
                currentPath += vals[nodeNumber - 1];
                foreach (var item in nodes[nodeNumber - 1])
                {
                    DFS(item);
                }
                if(currentPath > maxPath)
                {
                    maxPath = currentPath;
                    lastNodeNumber = nodeNumber;
                }

                currentPath -= vals[nodeNumber - 1];
            }
        }
    }
}

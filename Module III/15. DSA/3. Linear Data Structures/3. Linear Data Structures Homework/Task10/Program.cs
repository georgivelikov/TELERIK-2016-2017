using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task10
{
    //We are given numbers N and M and the following operations:

    //N = N+1
    //N = N+2
    //N = N*2

    //Write a program that finds the shortest sequence of operations from the list above that starts from N and finishes in M.

    //Hint: use a queue.
    //Example: N = 5, M = 16
    //Sequence: 5 → 7 → 8 → 16

    public class Program
    {
        public static void Main()
        {
            int n = 5;
            int m = 16;

            var queue = new Queue<Node>();
            var solutionsQueue = new Queue<Node>();

            Node startNode = new Node(n);
            queue.Enqueue(startNode);

            int endCounter = 0;

            while (true)
            {
                var currentNode = queue.Dequeue();
                if (currentNode.Value == m)
                {
                    var endNode = currentNode;
                    solutionsQueue.Enqueue(endNode);
                }

                if (currentNode.Value > m)
                {
                    // if currentNode.Value > m, than there are no more than 2 previous values in the set that can be equal to m
                    endCounter++; 
                    if (endCounter >= 3)
                    {
                        break;
                    }
                }

                var n1 = new Node(currentNode.Value + 1);
                n1.PreviousValue = currentNode;

                var n2 = new Node(currentNode.Value + 2);
                n2.PreviousValue = currentNode;

                var n3 = new Node(currentNode.Value * 2);
                n3.PreviousValue = currentNode;

                queue.Enqueue(n1);
                queue.Enqueue(n2);
                queue.Enqueue(n3);
            }

            while (solutionsQueue.Count > 0)
            {
                var result = new Stack<int>();
                var endNode = solutionsQueue.Dequeue();
                while (true)
                {
                    if (endNode.PreviousValue != null)
                    {
                        result.Push(endNode.Value);
                        endNode = endNode.PreviousValue;
                    }
                    else
                    {
                        result.Push(endNode.Value);
                        break;
                    }
                }

                Console.WriteLine(string.Join(" -> ", result));
            }
        }

        public class Node
        {
            public Node(int value)
            {
                this.Value = value;
            }

            public int Value { get; set; }

            public Node PreviousValue { get; set; }
        }
    }
}

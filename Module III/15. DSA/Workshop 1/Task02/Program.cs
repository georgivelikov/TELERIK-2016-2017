using System;
using System.Collections.Generic;

public class Program
{
    // 100/100
    public static void Main()
    {
        string line = Console.ReadLine();
        int result = ProcessRPN(line);
        Console.WriteLine(result);
    }

    private static int ProcessRPN(string input)
    {
        string[] arr = input.Split();
        Stack<int> stack = new Stack<int>();
        foreach (string token in arr)
        {
            if (token != "+" && token != "-" && token != "/" && token != "*" && token != "^" && token != "&" && token != "|")
            {
                var num = int.Parse(token);
                stack.Push(num);
            }
            else
            {
                if (token == "+")
                {
                    int a = stack.Pop();
                    int b = stack.Pop();
                    stack.Push(a + b);
                }

                if (token == "-")
                {
                    int a = stack.Pop();
                    int b = stack.Pop();
                    stack.Push(b - a);
                }

                if (token == "*")
                {
                    int a = stack.Pop();
                    int b = stack.Pop();
                    stack.Push(a * b);
                }

                if (token == "/")
                {
                    int a = stack.Pop();
                    int b = stack.Pop();
                    stack.Push(b / a);
                }

                if (token == "^")
                {
                    int a = stack.Pop();
                    int b = stack.Pop();
                    stack.Push((int)((int)a ^ (int)b));
                }

                if (token == "&")
                {
                    int a = stack.Pop();
                    int b = stack.Pop();
                    stack.Push((int)((int)a & (int)b));
                }

                if (token == "|")
                {
                    int a = stack.Pop();
                    int b = stack.Pop();
                    stack.Push((int)((int)a | (int)b));
                }
            }
        }

        return stack.Pop();
    }
}


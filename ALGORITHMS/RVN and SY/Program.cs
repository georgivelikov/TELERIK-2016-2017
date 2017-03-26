using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        string line = Console.ReadLine();
        string adjustedLine = AdjustStringInput(line);

        //TODO: fix the intervals next to "+" sign, (2+3) throws Error, should be (2 + 3) 

        string[] input = adjustedLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Queue<string> queue = new Queue<string>();
        Stack<string> stack = new Stack<string>();
        Dictionary<string, int> operators = new Dictionary<string, int>();
        operators.Add("+", 1);
        operators.Add("-", 1);
        operators.Add("/", 2);
        operators.Add("*", 2);
        operators.Add("^", 3);
        operators.Add("(", 4);
        operators.Add(")", 4);


        string rvn = ConvertToRPN(stack, queue, input, operators);
        Console.WriteLine(rvn);
        double result = ProcessRPN(rvn);
        Console.WriteLine(result);
    }

    //Shuntung-yard
    private static string ConvertToRPN(Stack<string> stack, Queue<string> queue, string[] input, Dictionary<string, int> operators)
    {
        foreach (string token in input)
        {
            if (operators.ContainsKey(token))
            {
                if (stack.Count == 0)
                {
                    stack.Push(token);
                }
                else
                {
                    var last = stack.Peek();
                    if (token == "(")
                    {
                        stack.Push(token);
                    }
                    else if (token == ")")
                    {
                        while (true)
                        {
                            var op = stack.Pop();
                            if (op != "(")
                            {
                                queue.Enqueue(op);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else if (operators[last] >= operators[token] && operators[last] != 4)
                    {
                        var op = stack.Pop();
                        queue.Enqueue(op);
                        stack.Push(token);
                    }
                    else
                    {
                        stack.Push(token);
                    }
                }
            }
            else
            {
                queue.Enqueue(token);
            }
        }

        while (stack.Count != 0)
        {
            var op = stack.Pop();
            queue.Enqueue(op);
        }

        return string.Join(" ", queue);
    }

    private static double ProcessRPN(string input)
    {
        string[] arr = input.Split();
        Stack<double> stack = new Stack<double>();
        foreach (string token in arr)
        {
            if (token != "+" && token != "-" && token != "/" && token != "*" && token != "^")
            {
                var num = double.Parse(token);
                stack.Push(num);
            }
            else
            {
                if (token == "+")
                {
                    double a = stack.Pop();
                    double b = stack.Pop();
                    stack.Push(a + b);
                }

                if (token == "-")
                {
                    double a = stack.Pop();
                    double b = stack.Pop();
                    stack.Push(b - a);
                }

                if (token == "*")
                {
                    double a = stack.Pop();
                    double b = stack.Pop();
                    stack.Push(a * b);
                }

                if (token == "/")
                {
                    double a = stack.Pop();
                    double b = stack.Pop();
                    stack.Push(b / a);
                }

                if (token == "^")
                {
                    double a = stack.Pop();
                    double b = stack.Pop();
                    stack.Push(Math.Pow(b, a));
                }
            }
        }

        return stack.Pop();
    }

    private static string AdjustStringInput(string line)
    {
        line = line.Replace('—', '-');
        line = line.Replace('–', '-');
        string errorPattern = @"(\+\s*\+)|(\*\s*\*)|(\/\s*\/)";
        Regex errorRegex = new Regex(errorPattern);
        if (errorRegex.IsMatch(line))
        {
            throw new ArgumentException("error");
        }

        // TODO: adjust (2+3) Regex regForSignWithoutInterval = new Regex(@"(\d)(\+|\-|\*\/)(\d)");

        char[] arr = line.ToCharArray();
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < arr.Length - 1; i++)
        {
            sb.Append(arr[i]);
            if (arr[i] == '(')
            {
                sb.Append(' ');
                continue;
            }

            if (arr[i + 1] != '.' && !(arr[i + 1] < 57 && arr[i + 1] > 48))
            {
                sb.Append(' ');
            }
        }

        if (arr[arr.Length - 2] != '.' && arr[arr.Length - 2] != '-' && !(arr[arr.Length - 2] < 57 && arr[arr.Length - 2] > 48))
        {
            sb.Append(' ');
        }

        sb.Append(arr[arr.Length - 1]);

        return sb.ToString();
    }
}


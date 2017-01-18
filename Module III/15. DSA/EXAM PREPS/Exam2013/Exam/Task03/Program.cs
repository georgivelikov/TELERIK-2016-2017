using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Task03
{
    public class Program
    {
        public static void Main()
        {
            var list = new BigList<string>();
            Bag<string> names = new Bag<string>();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }

                string[] commandArgs = line.Split();

                if (commandArgs[0] == "Append")
                {
                    string name = commandArgs[1];
                    list.Add(name);
                    names.Add(name);

                    Console.WriteLine("OK");
                }
                else if (commandArgs[0] == "Insert")
                {
                    int position = int.Parse(commandArgs[1]);
                    string name = commandArgs[2];
                    if (position > list.Count || position < 0) // ?
                    {
                        Console.WriteLine("Error");
                    }
                    else
                    {
                        list.Insert(position, name);
                        names.Add(name);
                        Console.WriteLine("OK");
                    }
                }
                else if (commandArgs[0] == "Find")
                {
                    string name = commandArgs[1];
                    Console.WriteLine(names.NumberOfCopies(name));
                }
                else if (commandArgs[0] == "Serve")
                {
                    int count = int.Parse(commandArgs[1]);
                    if (count > list.Count)
                    {
                        Console.WriteLine("Error");
                    }
                    else
                    {
                        var fin = list.Range(0, count).ToList();
                        Console.WriteLine(string.Join(" ", fin));

                        names.RemoveMany(fin);
                        list.RemoveRange(0, count);              
                    }
                }
            }
        }
    }
}

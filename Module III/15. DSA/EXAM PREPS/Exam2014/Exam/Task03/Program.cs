using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace Task03
{
    public class Program
    {
        public static void Main()
        {
            HashSet<string> names = new HashSet<string>();
            OrderedMultiDictionary<double, Product> products = new OrderedMultiDictionary<double, Product>(true);
            OrderedBag<Product> products2 = new OrderedBag<Product>();
            Dictionary<string, SortedSet<Product>> byType = new Dictionary<string, SortedSet<Product>>();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "end")
                {
                    break;
                }

                string[] commandArgs = line.Split();
                string commandName = commandArgs[0];
                if (commandName == "add")
                {
                    string name = commandArgs[1];
                    double price = double.Parse(commandArgs[2]);
                    string type = commandArgs[3];
                    if (!names.Contains(name))
                    {
                        var product = new Product(name, price, type);
                        products2.Add(product);

                        if (!byType.ContainsKey(type))
                        {
                            byType.Add(type, new SortedSet<Product>());
                        }
                        byType[type].Add(product);
                        Console.WriteLine("Ok: Product {0} added successfully", name);
                        names.Add(name);
                        //prices.Add(price, product);
                    }
                    else
                    {
                        Console.WriteLine("Error: Product {0} already exists", name);
                    }
                }
                else if (commandName == "filter")
                {
                    var filterParam = commandArgs[2];
                    if (filterParam == "type")
                    {
                        var typeName = commandArgs[3];

                        if (!byType.ContainsKey(typeName))
                        {
                            Console.WriteLine("Error: Type {0} does not exists", typeName);
                        }
                        else
                        {
                            var result = byType[typeName].Take(10).ToList();
                            Console.WriteLine("Ok: {0}".Trim(), string.Join(", ", result));
                        }
                    }
                    else // prices
                    {
                        if (commandArgs.Length == 7)
                        {
                            double from = double.Parse(commandArgs[4]);
                            var productFrom = new Product("", from, "");
                            double to = double.Parse(commandArgs[6]);
                            var productTo = new Product("", to, "");

                            var result = products2.Range(productFrom, true, productTo, true).Take(10).ToList();
                            if (result.Count == 0)
                            {
                                Console.WriteLine("Ok: ");
                            }
                            else
                            {
                                Console.WriteLine("Ok: {0}", string.Join(", ", result));
                            }

                        }
                        else
                        {
                            if (commandArgs[3] == "from")
                            {
                                double from = double.Parse(commandArgs[4]);
                                var productFrom = new Product("", from, "");
                                var result = products2.RangeFrom(productFrom, true).Take(10).ToList();
                                if (result.Count == 0)
                                {
                                    Console.WriteLine("Ok: ");
                                }
                                else
                                {
                                    Console.WriteLine("Ok: {0}", string.Join(", ", result));
                                }
                            }
                            else
                            {
                                double to = double.Parse(commandArgs[4]);
                                var productTo = new Product("", to, "");
                                var result = products2.RangeTo(productTo, true).Take(10).ToList();
                                if (result.Count == 0)
                                {
                                    Console.WriteLine("Ok: ");
                                }
                                else
                                {
                                    Console.WriteLine("Ok: {0}", string.Join(", ", result));
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public class Product : IComparable<Product>
    {
        public Product(string name, double price, string type)
        {
            this.Name = name;
            this.Price = price;
            this.Type = type;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Type { get; set; }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Price);
        }
        public int CompareTo(Product other)
        {
            if (this.Name == other.Name)
            {
                return 0;
            }

            if (this.Price > other.Price)
            {
                return 1;
            }
            else if (this.Price < other.Price)
            {
                return -1;
            }
            else
            {
                return this.Name.CompareTo(other.Name);
            }
        }
    }
}

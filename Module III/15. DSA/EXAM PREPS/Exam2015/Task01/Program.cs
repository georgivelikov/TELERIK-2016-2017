using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    public class Program
    {
        public static void Main()
        {
            var set = new SortedSet<Unit>();
            var nameMap = new Dictionary<string, Unit>();

            while (true)
            {
                string line = Console.ReadLine();

                if(line == "end")
                {
                    break;
                }

                var command = line.Split(' ');
                
                if(command[0] == "add")
                {
                    var name = command[1];
                    var type = command[2];
                    var attack = int.Parse(command[3]);

                    if (nameMap.ContainsKey(name))
                    {
                        Console.WriteLine("FAIL: {0} already exists!", name);
                    }
                    else
                    {
                        var unit = new Unit(name, type, attack);
                        nameMap.Add(name, unit);
                        set.Add(unit);
                        Console.WriteLine("SUCCESS: {0} added!", name);
                    }
                }
                else if(command[0] == "remove")
                {
                    var name = command[1];

                    if (!nameMap.ContainsKey(name))
                    {
                        Console.WriteLine("FAIL: {0} could not be found!", name);
                    }
                    else
                    {
                        var unitToRemove = nameMap[name];
                        set.Remove(unitToRemove);
                        nameMap.Remove(name);
                        Console.WriteLine("SUCCESS: {0} removed!", name);
                    }
                }
                else if(command[0] == "find")
                {
                    var type = command[1];
                    var result = set.Where(x => x.Type == type).Take(10);

                    Console.WriteLine("RESULT: " + string.Join(", ", result));
                }
                else if(command[0] == "power")
                {
                    var count = int.Parse(command[1]);
                    var result = set.Take(count);

                    Console.WriteLine("RESULT: " + string.Join(", ", result));
                }
            }
        }

        public class Unit : IComparable<Unit>
        {
            public Unit(string name, string type, int attack)
            {
                this.Name = name;
                this.Type = type;
                this.Attack = attack;
            }

            public string Name { get; set; }

            public string Type { get; set; }

            public int Attack { get; set; }

            public override string ToString()
            {
                return string.Format("{0}[{1}]({2})", this.Name, this.Type, this.Attack);
            }

            public override bool Equals(object obj)
            {
                var newObj = (Unit)obj;
                return this.Name == newObj.Name;
            }

            public int CompareTo(Unit other)
            {
                if(this.Name == other.Name)
                {
                    return 0;
                }

                if(this.Attack > other.Attack)
                {
                    return -1;
                }
                else if(this.Attack < other.Attack)
                {
                    return 1;
                }
                else
                {
                    if(this.Name.CompareTo(other.Name) > 1)
                    {
                        return 1;
                    }
                    else if(this.Name.CompareTo(other.Name) < 1)
                    {
                        return -1;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
        }
    }
}

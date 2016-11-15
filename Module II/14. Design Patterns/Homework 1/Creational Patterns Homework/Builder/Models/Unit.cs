using System;
using System.Collections.Generic;

namespace Builder.Models
{
    public class Unit
    {
        private readonly string unitType;

        private readonly Dictionary<string, double> stats = new Dictionary<string, double>();

        public Unit(string unitType)
        {
            this.unitType = unitType;
        }

        public double this[string key]
        {
            get
            {
                return this.stats[key];
            }
            set
            {
                this.stats[key] = value;
            }
        }

        public void Print()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Unit Type: {0}", this.unitType);
            Console.WriteLine(" Life  : {0}", this["life"]);
            Console.WriteLine(" Mana : {0}", this["mana"]);
            Console.WriteLine(" AttackPoints: {0}", this["attackPoints"]);
            Console.WriteLine(" DefencePoints : {0}", this["deffencePoints"]);
        }
    }
}

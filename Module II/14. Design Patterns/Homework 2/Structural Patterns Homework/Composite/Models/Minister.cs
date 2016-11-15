using System;
using System.Collections.Generic;
using Composite.Contracts;

namespace Composite.Models
{
    public class Minister : Person, IMinister
    {
        private ICollection<IPerson> subordinates;
         
        public Minister(string name)
            : base(name)
        {
            this.subordinates = new List<IPerson>();
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + this.Name);
            foreach (var s in this.subordinates)
            {
                s.Display(depth + 2);
            }
        }

        public void AddSubordinate(IPerson subordinate)
        {
            this.subordinates.Add(subordinate);
        }
    }
}

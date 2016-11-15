using System;

namespace Composite.Models
{
    public class Clerk : Person
    {
        public Clerk(string name)
            : base(name)
        {
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + this.Name);
        }
    }
}

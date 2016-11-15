using System;
using Composite.Contracts;

namespace Composite.Models
{
    public abstract class Person : IPerson
    {
        private string name;

        public Person(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Person must have name");
            }

            this.name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public abstract void Display(int depth);
    }
}

namespace Tasks_05_07
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Person : IComparable<Person>
    {
        private string name;
        private uint age;

        public Person(string name, uint age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public uint Age
        {
            get
            {
                return this.age;
            }

            set
            {
                this.age = value;
            }
        }

        public override string ToString()
        {
            return this.Name + " " + this.Age + "y";
        }

        public int CompareTo(Person other)
        {
            if (this.Age.CompareTo(other.Age) > 0)
            {
                return 1;
            }
            else if (this.Age.CompareTo(other.Age) < 0)
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

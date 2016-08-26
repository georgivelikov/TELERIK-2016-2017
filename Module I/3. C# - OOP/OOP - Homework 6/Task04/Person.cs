namespace Task04
{
    using System;
    using System.Text;

    public class Person
    {
        private string name;
        private int age;

        public Person(string name)
        {
            this.name = name;
        }

        public Person(string name, int age)
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name can not be empty");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Person must have positive age!");
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this.Age == 0)
            {
                sb.AppendLine("Name: " + this.Name);
                sb.AppendLine("Age: unspecified");
            }
            else
            {
                sb.AppendLine("Name: " + this.Name);
                sb.AppendLine("Age: " + this.Age);
            }

            return sb.ToString();
        }
    }
}

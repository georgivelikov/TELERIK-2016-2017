namespace Task_01.People
{
    using System;

    public abstract class Person
    {
        private string name;
        private string commnet;

        public Person(string name, string comment = null)
        {
            this.Name = name;
            this.Comment = comment;
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
                    throw new ArgumentException("Person must have name");
                }

                this.name = value;
            }
        }

        public string Comment
        {
            get
            {
                return this.commnet;
            }

            set
            {
                this.commnet = value;
            }
        }
    }
}

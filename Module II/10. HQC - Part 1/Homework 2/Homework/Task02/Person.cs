namespace Task02
{
    public class Person
    {
        private string name;

        private int age;

        private GenderType gender;

        public Person(string name, int age, GenderType gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
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

        public int Age
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

        public GenderType Gender
        {
            get
            {
                return this.gender;
            }

            set
            {
                this.gender = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Hello, my name is {0}, I am {1} years old and I am {2}.", this.Name, this.Age, this.Gender);
        }
    }
}

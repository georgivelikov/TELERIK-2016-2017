namespace Task03___Task05
{
    using System;

    public class Student
    {
        private string firstName;

        private string lastName;

        private int age;

        public Student(string firstName, string lastName, int age)
        {
            this.FisrtName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FisrtName
        {
            get
            {
                return this.firstName;  
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid first name!");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid last name!");
                }

                this.lastName = value;
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
                if (value < 0 || value > 120)
                {
                    throw new ArgumentException("Invalid age!");
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            return this.FisrtName + " " + this.LastName + " " + this.Age;
        }
    }
}

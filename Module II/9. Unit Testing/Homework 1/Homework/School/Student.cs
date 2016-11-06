namespace School
{
    using System;

    public class Student
    {
        private string name;
        private int studentNumber;

        public Student(string name, int number)
        {
            this.Name = name;
            this.StudentNumber = number;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name can not be empty!");
                }

                this.name = value;
            }
        }

        public int StudentNumber
        {
            get
            {
                return this.studentNumber;
            }

            private set
            {
                if (value < 10000 || value > 99999)
                {
                    throw new ArgumentException("Student number must be between 10 000 and 99 999!");
                }
                this.studentNumber = value;
            }
        }
    }
}

namespace Task_01.People
{
    using System;

    public class Student : Person
    {
        private const uint MaxClassNumber = 30;

        private uint classNumber;

        public Student(string name, uint classNumber, string comment = null)
            : base(name, comment)
        {
            this.ClassNumber = classNumber;
        }

        public uint ClassNumber
        {
            get
            {
                return this.classNumber;
            }

            set
            {
                if (value > MaxClassNumber)
                {
                    throw new ArgumentException("Class number must not exceed max class number!");
                }

                this.classNumber = value;
            }
        }

        public override string ToString()
        {
            return this.Name + " no" + this.ClassNumber;
        }
    }
}

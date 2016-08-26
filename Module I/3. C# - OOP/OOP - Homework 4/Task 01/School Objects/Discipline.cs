namespace Task_01.School_Objects
{
    using System;

    public class Discipline
    {
        private const uint MaxNumberOfLectures = 20;
        private const uint MaxNumberOfExercises = 20;

        private string name;
        private uint numberOfLectures;
        private uint numberOfExercises;
        private string comment;

        public Discipline(string name, uint numberOfLectures, uint numberOfExercises, string comment = null)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExcercises = numberOfExercises;
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
                    throw new ArgumentException("Discipline must have name!");
                }

                this.name = value;
            }
        }

        public uint NumberOfLectures
        {
            get
            {
                return this.numberOfLectures;
            }

            set
            {
                if (value > MaxNumberOfLectures)
                {
                    throw new ArgumentException("Value exceeds maximum number of lectures!");
                }

                this.numberOfLectures = value;
            }
        }

        public uint NumberOfExcercises
        {
            get
            {
                return this.numberOfExercises;
            }

            set
            {
                if (value > MaxNumberOfExercises)
                {
                    throw new ArgumentException("Value exceeds maximum number of exercises!");
                }

                this.numberOfExercises = value;
            }
        }

        public string Comment
        {
            get
            {
                return this.comment;
            }

            set
            {
                this.comment = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}

namespace Task_03
{
    using System;

    public abstract class Animal : ISound
    {
        private string name;
        private uint age;
        private Sex sex;

        public Animal(string name, uint age, Sex sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
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
                    throw new ArgumentException("Animal must have name!");
                }

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

        public Sex Sex
        {
            get
            {
                return this.sex;
            }

            private set
            {
                this.sex = value;   
            }
        }

        public virtual void Sound()
        {
            
        }
    }
}

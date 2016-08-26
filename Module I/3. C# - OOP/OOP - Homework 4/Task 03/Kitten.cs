namespace Task_03
{
    using System;

    public class Kitten : Cat
    {
        private const Sex ConstSex = Sex.Female;

        public Kitten(string name, uint age)
            : base(name, age, ConstSex)
        {
        }

        public override void Sound()
        {
            Console.WriteLine("Girly Meow");
        }
    }
}

namespace Task_03
{
    using System;

    public class Cat : Animal
    {
        public Cat(string name, uint age, Sex sex)
            : base(name, age, sex)
        {
        }

        public override void Sound()
        {
            Console.WriteLine("Meow Meow");
        }
    }
}

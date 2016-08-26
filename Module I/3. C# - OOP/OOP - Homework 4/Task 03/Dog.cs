namespace Task_03
{
    using System;

    public class Dog : Animal
    {
        public Dog(string name, uint age, Sex sex)
            : base(name, age, sex)
        {
        }

        public override void Sound()
        {
            Console.WriteLine("Bau Bau");
        }
    }
}

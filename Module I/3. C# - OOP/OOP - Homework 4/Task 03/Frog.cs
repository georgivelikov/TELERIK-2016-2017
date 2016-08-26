namespace Task_03
{
    using System;

    public class Frog : Animal
    {
        public Frog(string name, uint age, Sex sex)
            : base(name, age, sex)
        {
        }

        public override void Sound()
        {
            Console.WriteLine("Qwak Qwak");
        }
    }
}

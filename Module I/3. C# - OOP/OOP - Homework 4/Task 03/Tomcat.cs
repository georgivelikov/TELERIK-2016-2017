namespace Task_03
{
    using System;

    public class Tomcat : Cat
    {
        private const Sex ConstSex = Sex.Male;

        public Tomcat(string name, uint age)
            : base(name, age, ConstSex)
        {
        }

        public override void Sound()
        {
            Console.WriteLine("Manly Meow");
        }
    }
}
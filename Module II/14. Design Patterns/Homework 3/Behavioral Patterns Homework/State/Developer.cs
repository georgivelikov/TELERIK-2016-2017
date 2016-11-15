using System;

using State.States;

namespace State
{
    public class Developer
    {
        public Developer()
        {
            this.Position = new Junior(this);
        }

        public Position Position { get; set; }

        public void ReadDependencyInjection()
        {
            this.Position.ReadDependencyInjection();
        }

        public void DrinkAlcohol()
        {
            this.Position.DrinkAlcohol();
        }

        public void DoJob()
        {
            Console.WriteLine(this.Position.DoJob());
        }
    }
}

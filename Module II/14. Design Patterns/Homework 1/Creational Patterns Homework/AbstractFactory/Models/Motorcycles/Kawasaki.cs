using AbstractFactory.Contracts;

namespace AbstractFactory.Models.Motorcycles
{
    public class Kawasaki : IMotorcycle
    {
        public override string ToString()
        {
            return "I am japanese motorcycle model Kawasaki";
        }
    }
}

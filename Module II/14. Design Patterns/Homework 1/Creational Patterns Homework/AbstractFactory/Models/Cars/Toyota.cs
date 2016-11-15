using AbstractFactory.Contracts;

namespace AbstractFactory.Models
{
    public class Toyota : ICar
    {
        public override string ToString()
        {
            return "I am japanese car model Toyota";
        }
    }
}

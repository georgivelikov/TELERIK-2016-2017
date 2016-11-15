using AbstractFactory.Contracts;

namespace AbstractFactory.Models
{
    public class Ford :ICar
    {
        public override string ToString()
        {
            return "I am american car model Ford";
        }
    }
}

using AbstractFactory.Contracts;

namespace AbstractFactory.Models.Motorcycles
{
    public class HarleyDavidson : IMotorcycle
    {
        public override string ToString()
        {
            return "I am american motorcycle model HarleyDavidson";
        }
    }
}

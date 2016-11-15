using AbstractFactory.Contracts;
using AbstractFactory.Models.Motorcycles;

namespace AbstractFactory.Models.Factories
{
    public class AmericaFactory : IVehicleFactory
    {
        public ICar CreateCar()
        {
            return new Ford();
        }

        public IMotorcycle CreateMotorcycle()
        {
            return new HarleyDavidson();
        }
    }
}

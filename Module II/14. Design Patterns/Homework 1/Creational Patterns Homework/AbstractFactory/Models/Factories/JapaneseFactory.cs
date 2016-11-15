using AbstractFactory.Contracts;
using AbstractFactory.Models.Motorcycles;

namespace AbstractFactory.Models.Factories
{
    public class JapaneseFactory : IVehicleFactory
    {
        public ICar CreateCar()
        {
            return new Toyota();
        }

        public IMotorcycle CreateMotorcycle()
        {
            return new Kawasaki();
        }
    }
}

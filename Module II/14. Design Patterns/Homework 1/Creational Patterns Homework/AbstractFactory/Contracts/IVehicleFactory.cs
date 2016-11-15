using System;
namespace AbstractFactory.Contracts
{
    public interface IVehicleFactory
    {
        ICar CreateCar();

        IMotorcycle CreateMotorcycle();
    }
}

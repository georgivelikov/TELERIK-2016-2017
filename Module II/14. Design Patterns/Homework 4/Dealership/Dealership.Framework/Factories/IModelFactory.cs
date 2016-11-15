using Dealership.Contracts;

namespace Dealership.Factories
{
    public interface IModelFactory
    {
        IVehicle GetCar(string make, string model, decimal price, int seats);

        IVehicle GetMotorcycle(string make, string model, decimal price, string category);

        IVehicle GetTruck(string make, string model, decimal price, int weightCapacity);
    }
}

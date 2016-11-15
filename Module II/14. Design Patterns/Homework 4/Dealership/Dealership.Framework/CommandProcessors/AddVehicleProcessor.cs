using System;

using Dealership.Common;
using Dealership.Framework.UserService;
using Dealership.Engine.Enums;
using Dealership.Contracts;
using Dealership.Factories;
using Dealership.Framework.Engine;

namespace Dealership.Framework.CommandProcessors
{
    public class AddVehicleProcessor : CommandProcessor
    {
        private IModelFactory modelFactory;

        public AddVehicleProcessor(IModelFactory modelFactory)
        {
            this.modelFactory = modelFactory;
        }

        public override bool CanProcess(ICommand command)
        {
            return command.Name == "AddVehicle";
        }

        public override string Process(ICommand command, IUserService userService)
        {
            if (userService.LoggedUser == null)
            {
                return Constants.UserNotLogged;
            }

            var type = command.Parameters[0];
            var make = command.Parameters[1];
            var model = command.Parameters[2];
            var price = decimal.Parse(command.Parameters[3]);
            var additionalParam = command.Parameters[4];

            var typeEnum = (VehicleType)Enum.Parse(typeof(VehicleType), type, true);

            IVehicle vehicle = null;

            if (typeEnum == VehicleType.Car)
            {
                vehicle = this.modelFactory.GetCar(make, model, price, int.Parse(additionalParam));
            }
            else if (typeEnum == VehicleType.Motorcycle)
            {
                vehicle = this.modelFactory.GetMotorcycle(make, model, price, additionalParam);
            }
            else if (typeEnum == VehicleType.Truck)
            {
                vehicle = this.modelFactory.GetTruck(make, model, price, int.Parse(additionalParam));
            }

            userService.LoggedUser.AddVehicle(vehicle);

            return string.Format(Constants.VehicleAddedSuccessfully, userService.LoggedUser.Username);
        }
    }
}

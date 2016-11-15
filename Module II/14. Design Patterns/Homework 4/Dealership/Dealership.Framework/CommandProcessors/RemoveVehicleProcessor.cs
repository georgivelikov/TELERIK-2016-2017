using Dealership.Common;
using Dealership.Contracts;
using Dealership.Framework.Engine;
using Dealership.Framework.UserService;

namespace Dealership.Framework.CommandProcessors
{
    public class RemoveVehicleProcessor : CommandProcessor
    {
        public override bool CanProcess(ICommand command)
        {
            return command.Name == "RemoveVehicle";
        }

        public override string Process(ICommand command, IUserService userService)
        {
            if (userService.LoggedUser == null)
            {
                return Constants.UserNotLogged;
            }

            var vehicleIndex = int.Parse(command.Parameters[0]) - 1;

            ValidateRange(vehicleIndex, 0, userService.LoggedUser.Vehicles.Count, Constants.RemovedVehicleDoesNotExist);

            var vehicle = userService.LoggedUser.Vehicles[vehicleIndex];

            userService.LoggedUser.RemoveVehicle(vehicle);

            return string.Format(Constants.VehicleRemovedSuccessfully, userService.LoggedUser.Username);
        }
    }
}

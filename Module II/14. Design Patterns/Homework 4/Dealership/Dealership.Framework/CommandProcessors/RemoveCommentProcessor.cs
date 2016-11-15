using Dealership.Common;
using Dealership.Contracts;
using Dealership.Framework.Engine;
using Dealership.Framework.UserService;

namespace Dealership.Framework.CommandProcessors
{
    public class RemoveCommentProcessor : CommandProcessor
    {
        public override bool CanProcess(ICommand command)
        {
            return command.Name == "RemoveComment";
        }

        public override string Process(ICommand command, IUserService userService)
        {
            if (userService.LoggedUser == null)
            {
                return Constants.UserNotLogged;

            }
            var vehicleIndex = int.Parse(command.Parameters[0]) - 1;
            var commentIndex = int.Parse(command.Parameters[1]) - 1;
            var username = command.Parameters[2];

            var user = userService.GetUser(username);

            if (user == null)
            {
                return string.Format(Constants.NoSuchUser, username);
            }

            ValidateRange(vehicleIndex, 0, user.Vehicles.Count, Constants.RemovedVehicleDoesNotExist);
            ValidateRange(commentIndex, 0, user.Vehicles[vehicleIndex].Comments.Count, Constants.RemovedCommentDoesNotExist);

            var vehicle = user.Vehicles[vehicleIndex];
            var comment = user.Vehicles[vehicleIndex].Comments[commentIndex];

            userService.LoggedUser.RemoveComment(comment, vehicle);

            return string.Format(Constants.CommentRemovedSuccessfully, userService.LoggedUser.Username);
        }
    }
}

using Dealership.Common;
using Dealership.Contracts;
using Dealership.Framework.Engine;
using Dealership.Framework.UserService;

namespace Dealership.Framework.CommandProcessors
{
    public class ShowVehiclesProcessor : CommandProcessor
    {
        public override bool CanProcess(ICommand command)
        {
            return command.Name == "ShowVehicles";
        }

        public override string Process(ICommand command, IUserService userService)
        {
            if (userService.LoggedUser == null)
            {
                return Constants.UserNotLogged;
            }

            var username = command.Parameters[0];

            var user = userService.GetUser(username.ToLower());

            if (user == null)
            {
                return string.Format(Constants.NoSuchUser, username);
            }

            return user.PrintVehicles();
        }
    }
}

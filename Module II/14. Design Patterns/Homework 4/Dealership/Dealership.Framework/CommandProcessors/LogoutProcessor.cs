using Dealership.Common;
using Dealership.Contracts;
using Dealership.Framework.Engine;
using Dealership.Framework.UserService;

namespace Dealership.Framework.CommandProcessors
{
    public class LogoutProcessor : CommandProcessor
    { 
        public override bool CanProcess(ICommand command)
        {
            return command.Name == "Logout";
        }

        public override string Process(ICommand command, IUserService userService)
        {
            if (userService.LoggedUser == null)
            {
                return Constants.UserNotLogged;
            }

            userService.LogOut();
            return Constants.UserLoggedOut;
        }
    }
}

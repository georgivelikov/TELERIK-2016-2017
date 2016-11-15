using Dealership.Common;
using Dealership.Contracts;
using Dealership.Framework.Engine;
using Dealership.Framework.UserService;

namespace Dealership.Framework.CommandProcessors
{
    public class LoginProcessor : CommandProcessor
    {
        public override bool CanProcess(ICommand command)
        {
            return command.Name == "Login";
        }

        public override string Process(ICommand command, IUserService userService)
        {
            var username = command.Parameters[0];
            var password = command.Parameters[1];

            if (userService.LoggedUser != null)
            {
                return string.Format(Constants.UserLoggedInAlready, userService.LoggedUser.Username);
            }

            var user = userService.GetUser(username.ToLower());

            if (user != null && user.Password == password)
            {
                userService.LogIn(user);
                return string.Format(Constants.UserLoggedIn, username);
            }

            return Constants.WrongUsernameOrPassword;
        }
    }
}

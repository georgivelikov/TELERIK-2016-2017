using System;

using Dealership.Common;
using Dealership.Contracts;
using Dealership.Engine.Enums;
using Dealership.Framework.Engine;
using Dealership.Framework.Factories;
using Dealership.Framework.UserService;

namespace Dealership.Framework.CommandProcessors
{
    public class RegisterProcessor : CommandProcessor
    {
        private IUserFactory userFactory;

        public RegisterProcessor(IUserFactory userFactory)
        {
            this.userFactory = userFactory;
        }

        public override bool CanProcess(ICommand command)
        {
            return command.Name == "RegisterUser";
        }

        public override string Process(ICommand command, IUserService userService)
        {
            var username = command.Parameters[0];
            var firstName = command.Parameters[1];
            var lastName = command.Parameters[2];
            var password = command.Parameters[3];

            var role = Role.Normal;

            if (command.Parameters.Count > 4)
            {
                role = (Role)Enum.Parse(typeof(Role), command.Parameters[4]);
            }

            if (userService.LoggedUser != null)
            {
                return string.Format(Constants.UserLoggedInAlready, userService.LoggedUser.Username);
            }

            if (userService.ContainsUser(username.ToLower()))
            {
                return string.Format(Constants.UserAlreadyExist, username);
            }

            var user = this.userFactory.CreateUser(username, firstName, lastName, password, role);
            userService.Register(user);
            userService.LogIn(user);
            return string.Format(Constants.UserRegisterеd, username);
        }
    }
}

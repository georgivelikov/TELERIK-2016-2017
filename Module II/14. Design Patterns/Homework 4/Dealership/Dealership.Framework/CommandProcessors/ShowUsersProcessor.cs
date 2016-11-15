using System.Text;

using Dealership.Common;
using Dealership.Contracts;
using Dealership.Engine.Enums;
using Dealership.Framework.Engine;
using Dealership.Framework.UserService;

namespace Dealership.Framework.CommandProcessors
{
    public class ShowUsersProcessor : CommandProcessor
    {
        public override bool CanProcess(ICommand command)
        {
            return command.Name == "ShowUsers";
        }

        public override string Process(ICommand command, IUserService userService)
        {
            if (userService.LoggedUser.Role != Role.Admin)
            {
                return Constants.YouAreNotAnAdmin;
            }

            var builder = new StringBuilder();
            builder.AppendLine("--USERS--");
            var counter = 1;
            foreach (var user in userService.GetAllUsers())
            {
                builder.AppendLine(string.Format("{0}. {1}", counter, user.ToString()));
                counter++;
            }

            return builder.ToString().Trim();
        }
    }
}

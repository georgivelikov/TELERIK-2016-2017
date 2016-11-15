using Dealership.Common;
using Dealership.Contracts;
using Dealership.Framework.Engine;
using Dealership.Framework.Factories;
using Dealership.Framework.UserService;

namespace Dealership.Framework.CommandProcessors
{
    public class AddCommentProcessor : CommandProcessor
    {
        private ICommentFactory commentFactory;

        public AddCommentProcessor(ICommentFactory commentFactory)
        {
            this.commentFactory = commentFactory;
        }

        public override bool CanProcess(ICommand command)
        {
            return command.Name == "AddComment";
        }

        public override string Process(ICommand command, IUserService userService)
        {
            if (userService.LoggedUser == null)
            {
                return Constants.UserNotLogged;
            }

            var content = command.Parameters[0];
            var author = command.Parameters[1];
            var vehicleIndex = int.Parse(command.Parameters[2]) - 1;

            var comment = this.commentFactory.CreateComment(content);
            comment.Author = userService.LoggedUser.Username;
            var user = userService.GetUser(author);

            if (user == null)
            {
                return string.Format(Constants.NoSuchUser, author);
            }

            ValidateRange(vehicleIndex, 0, user.Vehicles.Count, Constants.VehicleDoesNotExist);

            var vehicle = user.Vehicles[vehicleIndex];

            userService.LoggedUser.AddComment(comment, vehicle);

            return string.Format(Constants.CommentAddedSuccessfully, userService.LoggedUser.Username);
        }
    }
}

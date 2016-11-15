using Dealership.Contracts;
using Dealership.Framework.UserService;

namespace Dealership.Framework.Engine
{
    public interface ICommandProcessor
    {
        ICommandProcessor Successor { get; }

        void SetSuccessor(ICommandProcessor commandProcessor);

        string ProcessCommand(ICommand command, IUserService userService);

        bool CanProcess(ICommand command);

        string Process(ICommand command, IUserService userService);
    }
}

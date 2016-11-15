using System;

using Dealership.Common;
using Dealership.Contracts;
using Dealership.Framework.UserService;

namespace Dealership.Framework.Engine
{
    public abstract class CommandProcessor : ICommandProcessor
    {
        public ICommandProcessor Successor { get; private set; }

        public void SetSuccessor(ICommandProcessor commandProcessor)
        {
            this.Successor = commandProcessor;
        }

        public string ProcessCommand(ICommand command, IUserService userService)
        {
            if (this.CanProcess(command))
            {
                return this.Process(command, userService);
            }
            else if (this.Successor != null)
            {
                return this.Successor.ProcessCommand(command, userService);
            }
            else
            {
                return string.Format(Constants.InvalidCommand, command.Name);
            }
        }

        public abstract bool CanProcess(ICommand command);

        public abstract string Process(ICommand command, IUserService userService);

        protected static void ValidateRange(int? value, int min, int max, string message)
        {
            if (value < min || value >= max)
            {
                throw new ArgumentException(message);
            }
        }
    }
}

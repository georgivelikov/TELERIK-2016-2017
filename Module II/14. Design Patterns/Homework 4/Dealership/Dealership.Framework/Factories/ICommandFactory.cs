using Dealership.Contracts;

namespace Dealership.Framework.Factories
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string inputLine);
    }
}

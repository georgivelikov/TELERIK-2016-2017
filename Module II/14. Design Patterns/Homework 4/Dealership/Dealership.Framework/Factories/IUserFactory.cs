using Dealership.Engine.Enums;
using Dealership.Contracts;

namespace Dealership.Framework.Factories
{
    public interface IUserFactory
    {
        IUser CreateUser(string username, string firstName, string lastName, string password, Role role);
    }
}

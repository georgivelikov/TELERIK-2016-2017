using System.Collections.Generic;

namespace Dealership.Contracts
{
    public interface ICommand
    {
        string Name { get; }

        IList<string> Parameters { get; }
    }
}

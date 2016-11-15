using System.Collections.Generic;

namespace Decorator.Contracts
{
    public interface IPizza
    {
        ICollection<string> Ingredients { get;  }

        void Display();
    }
}

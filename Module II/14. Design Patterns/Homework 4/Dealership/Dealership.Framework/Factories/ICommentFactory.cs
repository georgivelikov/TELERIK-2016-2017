using Dealership.Contracts;

namespace Dealership.Framework.Factories
{
    public interface ICommentFactory
    {
        IComment CreateComment(string content);
    }
}

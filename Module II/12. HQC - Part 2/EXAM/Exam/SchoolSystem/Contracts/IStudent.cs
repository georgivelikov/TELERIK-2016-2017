using System.Collections.Generic;

namespace SchoolSystem.Contracts
{
    public interface IStudent : IPerson
    {
        IEnumerable<IMark> Marks { get; }

        int MarksCount { get; }

        void AddMark(IMark mark);

        string ListMarks();
    }
}

using SchoolSystem.Enums;
using SchoolSystem.Models;

namespace SchoolSystem.Contracts
{
    public interface ITeacher : IPerson
    {
        SubjectEnum Subject { get; }

        void AddMark(IStudent student, float markValue);
    }
}

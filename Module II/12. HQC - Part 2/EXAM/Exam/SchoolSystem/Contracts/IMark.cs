using SchoolSystem.Enums;

namespace SchoolSystem.Contracts
{
    public interface IMark
    {
        SubjectEnum Subject { get; }

        float MarkValue { get; }
    }
}

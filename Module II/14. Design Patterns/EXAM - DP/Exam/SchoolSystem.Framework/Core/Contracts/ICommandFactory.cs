using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework.Core.Contracts
{
    public interface ICommandFactory
    {
        ICommand GetCreateStudentCommand(IStudentFactory studentFactory);

        ICommand GetCreateTeacherCommand(ITeacherFactory teacherFactory);

        ICommand GetRemoveStudentCommand();

        ICommand GetRemoveTeacherCommand();

        ICommand GetStudentListMarksCommand();

        ICommand GetTeacherAddMarkCommand();
    }
}

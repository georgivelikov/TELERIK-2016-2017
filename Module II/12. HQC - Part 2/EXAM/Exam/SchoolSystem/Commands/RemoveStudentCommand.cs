using System.Collections.Generic;
using SchoolSystem.Contracts;

namespace SchoolSystem.Commands
{
    public class RemoveStudentCommand : Command
    {
        public override string Execute(IList<string> commandParams, ISchoolSystemData data)
        {
            var id = int.Parse(commandParams[0]);
            data.RemoveStudent(id);
            return $"Student with ID {id} was sucessfully removed.";
        }
    }
}
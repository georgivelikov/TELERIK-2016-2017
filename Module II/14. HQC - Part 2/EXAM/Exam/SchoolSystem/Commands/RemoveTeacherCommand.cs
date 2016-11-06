using System.Collections.Generic;
using SchoolSystem.Contracts;

namespace SchoolSystem.Commands
{
    public class RemoveTeacherCommand : Command
    {
        public override string Execute(IList<string> commandParams, ISchoolSystemData data)
        {
            var id = int.Parse(commandParams[0]);
            data.RemoveTeacher(id);
            return $"Teacher with ID {id} was sucessfully removed.";
        }
    }
}

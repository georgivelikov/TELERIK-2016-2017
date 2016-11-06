using System.Collections.Generic;
using SchoolSystem.Contracts;

namespace SchoolSystem.Commands
{
    public class StudentListMarksCommand : Command
    {
        public override string Execute(IList<string> commandParams, ISchoolSystemData data)
        {
            var id = int.Parse(commandParams[0]);
            var student = data.GetStudent(id);
            string result = student.ListMarks();
            return result;
        }
    }
}

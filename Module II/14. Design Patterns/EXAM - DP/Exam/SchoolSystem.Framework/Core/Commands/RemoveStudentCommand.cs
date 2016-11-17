using System;
using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class RemoveStudentCommand : ICommand
    {
        public string Execute(IList<string> parameters, ISchoolSystemData data)
        {
            var studentId = int.Parse(parameters[0]);
            if (data.GetStudent(studentId) == null)
            {
                throw new InvalidOperationException("The given key was not present in the dictionary.");
            }

            data.RemoveStudent(studentId);
            return $"Student with ID {studentId} was sucessfully removed.";
        }
    }
}

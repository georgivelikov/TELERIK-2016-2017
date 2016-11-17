using System;
using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class RemoveTeacherCommand : ICommand
    {
        public string Execute(IList<string> parameters, ISchoolSystemData data)
        {
            var teacherId = int.Parse(parameters[0]);

            if (data.GetTeacher(teacherId) == null)
            {
                throw new InvalidOperationException("The given key was not present in the dictionary.");
            }

            data.RemoveTeacher(teacherId);
            return $"Teacher with ID {teacherId} was sucessfully removed.";
        }
    }
}

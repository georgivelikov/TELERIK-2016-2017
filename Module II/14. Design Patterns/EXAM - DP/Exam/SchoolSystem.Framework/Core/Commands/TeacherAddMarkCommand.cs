using System;
using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class TeacherAddMarkCommand : ICommand
    {
        public string Execute(IList<string> parameters, ISchoolSystemData data)
        {
            var teacherId = int.Parse(parameters[0]);
            var studentId = int.Parse(parameters[1]);
            var mark = float.Parse(parameters[2]);

            if (data.GetTeacher(teacherId) == null)
            {
                throw new InvalidOperationException("The given key was not present in the dictionary.");
            }

            if (data.GetStudent(studentId) == null)
            {
                throw new InvalidOperationException("The given key was not present in the dictionary.");
            }

            var student = data.GetStudent(studentId);
            var teacher = data.GetTeacher(teacherId);

            teacher.AddMark(student, mark);
            return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {mark} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }
    }
}

using System.Collections.Generic;
using SchoolSystem.Contracts;

namespace SchoolSystem.Commands
{
    public class TeacherAddMarkCommand : Command
    {
        public override string Execute(IList<string> commandParams, ISchoolSystemData data)
        {
            var teacherId = int.Parse(commandParams[0]);
            var studentId = int.Parse(commandParams[1]);

            var student = data.GetStudent(studentId);
            var teacher = data.GetTeacher(teacherId);

            var markValue = float.Parse(commandParams[2]);

            teacher.AddMark(student, markValue);
            return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {markValue} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }
    }
}
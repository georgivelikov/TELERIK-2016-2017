using System;
using System.Collections.Generic;
using SchoolSystem.Contracts;
using SchoolSystem.Enums;
using SchoolSystem.Models;

namespace SchoolSystem.Commands
{
    public class CreateTeacherCommand : Command
    {
        private const int MinSubjectParam = 1;
        private const int MaxSubjectParam = 4;
        private const string InvalidSubjectMessage = "Subject param must be bewtween 1 and 4";

        public override string Execute(IList<string> commandParams, ISchoolSystemData data)
        {
            var firstName = commandParams[0];
            var lastName = commandParams[1];
            var subjectParam = int.Parse(commandParams[2]);
            if (subjectParam < MinSubjectParam || subjectParam > MaxSubjectParam)
            {
                throw new ArgumentException(InvalidSubjectMessage);
            }

            var subject = (SubjectEnum)subjectParam;
            var teacher = new Teacher(firstName, lastName, subject);
            data.AddTeacher(teacher);
            var currentId = data.LastTeacherId();

            return $"A new teacher with name {firstName} {lastName}, subject {subject} and ID {currentId} was created.";
        }
    }
}
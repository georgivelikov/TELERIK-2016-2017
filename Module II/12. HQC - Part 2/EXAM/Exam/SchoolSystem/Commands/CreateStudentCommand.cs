using System;
using System.Collections.Generic;
using SchoolSystem.Contracts;
using SchoolSystem.Enums;
using SchoolSystem.Models;

namespace SchoolSystem.Commands
{
    public class CreateStudentCommand : Command
    {
        private const int MinGrade = 1;
        private const int MaxGrade = 12;
        private const string IvalidGradeMessage = "Grade must be between 1 and 12";

        public override string Execute(IList<string> commandParams, ISchoolSystemData data)
        {
            var firstName = commandParams[0];
            var lastName = commandParams[1];
            var gradeParam = int.Parse(commandParams[2]);
            if (gradeParam < MinGrade || gradeParam > MaxGrade)
            {
                throw new ArgumentException(IvalidGradeMessage);
            }

            var grade = (GradeEnum)gradeParam;
            var student = new Student(firstName, lastName, grade);
            data.AddStudent(student);
            var currentId = data.LastStudentId();
            return $"A new student with name {firstName} {lastName}, grade {grade} and ID {currentId} was created.";
        }
    }
}

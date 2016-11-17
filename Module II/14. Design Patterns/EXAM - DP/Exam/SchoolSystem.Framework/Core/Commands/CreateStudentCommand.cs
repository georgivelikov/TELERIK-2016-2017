using System;
using System.Collections.Generic;

using SchoolSystem.Framework.Common;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateStudentCommand : ICommand
    {
        private IStudentFactory studentFactory;

        public CreateStudentCommand(IStudentFactory studentFactory)
        {
            if (studentFactory == null)
            {
                throw new ArgumentNullException($"Student Factory {Constants.NullProvidersExceptionMessage}");
            }

            this.studentFactory = studentFactory;
        }

        public string Execute(IList<string> parameters, ISchoolSystemData data)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = (Grade)int.Parse(parameters[2]);

            var student = this.studentFactory.CreateStudent(firstName, lastName, grade);

            data.AddStudent(student);

            return $"A new student with name {firstName} {lastName}, grade {grade} and ID {data.LastStudentId()} was created.";
        }
    }
}

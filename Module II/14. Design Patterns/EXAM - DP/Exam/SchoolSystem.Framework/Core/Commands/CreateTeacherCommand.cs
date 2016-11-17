using System;
using System.Collections.Generic;

using SchoolSystem.Framework.Common;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateTeacherCommand : ICommand
    {
        private ITeacherFactory teacherFactory;

        private IMarkFactory markFactory;

        public CreateTeacherCommand(ITeacherFactory teacherFactory, IMarkFactory markFactory)
        {
            if (teacherFactory == null)
            {
                throw new ArgumentNullException($"Teacher Factory {Constants.NullProvidersExceptionMessage}");
            }

            if (markFactory == null)
            {
                throw new ArgumentNullException($"Mark Factory {Constants.NullProvidersExceptionMessage}");
            }

            this.teacherFactory = teacherFactory;
            this.markFactory = markFactory;
        }

        public string Execute(IList<string> parameters, ISchoolSystemData data)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var subject = (Subject)int.Parse(parameters[2]);

            var teacher = this.teacherFactory.CreateTeacher(firstName, lastName, subject, this.markFactory);
            data.AddTeacher(teacher);

            return $"A new teacher with name {firstName} {lastName}, subject {subject} and ID {data.LastTeacherId()} was created.";
        }
    }
}

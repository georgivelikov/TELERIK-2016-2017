using System;

using SchoolSystem.Framework.Common;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Models.Abstractions;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Models
{
    public class Teacher : Person, ITeacher
    {
        public const int MaxStudentMarksCount = 20;

        private IMarkFactory markFactory;

        public Teacher(string firstName, string lastName, Subject subject, IMarkFactory markFactory)
            : base(firstName, lastName)
        {
            if (markFactory == null)
            {
                throw new ArgumentNullException($"Mark Factory {Constants.NullProvidersExceptionMessage}");
            }

            this.Subject = subject;
            this.markFactory = markFactory;
        }

        public Subject Subject { get; set; }

        public void AddMark(IStudent student, float mark)
        {
            if (student.Marks.Count >= MaxStudentMarksCount)
            {
                throw new ArgumentException($"The student's marks count exceed the maximum count of {MaxStudentMarksCount} marks");
            }

            var newMark = this.markFactory.CreateMark(this.Subject, mark);
            student.Marks.Add(newMark);
        }
    }
}

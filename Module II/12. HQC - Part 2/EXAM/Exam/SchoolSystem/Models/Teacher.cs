using SchoolSystem.Enums;
using SchoolSystem.Contracts;

namespace SchoolSystem.Models
{
    public class Teacher : Person, ITeacher
    {
        private SubjectEnum subject;

        public Teacher(string firstName, string lastName, SubjectEnum subject) 
            : base(firstName, lastName)
        {
            this.subject = subject;
        }

        public SubjectEnum Subject
        {
            get
            {
                return this.subject;
            }
        }

        public void AddMark(IStudent student, float markValue)
        {
            var newMark = new Mark(this.Subject, markValue);
            student.AddMark(newMark);
        }
    }
}

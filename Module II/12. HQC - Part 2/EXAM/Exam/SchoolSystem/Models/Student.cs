using System;
using System.Collections.Generic;
using System.Text;
using SchoolSystem.Enums;
using SchoolSystem.Contracts;

namespace SchoolSystem.Models
{
    public class Student : Person, IStudent
    {
        private const int MaxMarksCount = 20;
        private const string MaxMarksExceptionMessage = "Student can have more than 20 marks!";
        private const string StudentHasNoMarksMessage = "This student has no marks.";
        private const string StudentMarksStartMessage = "The student has these marks:";

        private GradeEnum grade;
        private ICollection<IMark> marks;

        public Student(string firstName, string lastName, GradeEnum grade)
            : base(firstName, lastName)
        {
            this.grade = grade;
            this.marks = new List<IMark>();
        }

        public GradeEnum Grade
        {
            get
            {
                return this.grade;
            }
        }

        public int MarksCount
        {
            get
            {
                return this.marks.Count;
            }
        }

        public IEnumerable<IMark> Marks
        {
            get
            {
                return this.marks;
            }
        }

        public void AddMark(IMark mark)
        {
            if (this.marks.Count >= MaxMarksCount)
            {
                throw new InvalidOperationException(MaxMarksExceptionMessage);
            }

            this.marks.Add(mark);
        }

        public string ListMarks()
        {
            if (this.marks.Count == 0)
            {
                return StudentHasNoMarksMessage;
            }

            StringBuilder result = new StringBuilder();
            result.AppendLine(StudentMarksStartMessage);
            foreach (var mark in this.marks)
            {
                result.Append(string.Format("{0} => {1}\n", mark.Subject, mark.MarkValue));
            }

            return result.ToString();
        }
    }
}

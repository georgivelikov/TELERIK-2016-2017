namespace School
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private const int MaxStudentsCount = 29;
        private ICollection<Student> students;
        private string courseName;

        public Course(string name)
        {
            this.CourseName = name;
            this.students = new HashSet<Student>();
        }

        public ICollection<Student> Students
        {
            get
            {
                return this.students;
            }
        }

        public string CourseName
        {
            get
            {
                return this.courseName;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Course must have name!");
                }

                this.courseName = value;
            }
        }

        public void AddStudent(Student st)
        {
            if (st == null)
            {
                throw new ArgumentNullException();
            }

            if (this.students.Contains(st))
            {
                throw new InvalidOperationException("Student is already signed for the course!");
            }

            if (this.students.Count == MaxStudentsCount)
            {
                throw new InvalidOperationException("Course is already full!");
            }

            this.students.Add(st);
        }

        public void RemoveStudent(Student st)
        {
            if (st == null)
            {
                throw new ArgumentNullException();
            }

            if (!this.students.Contains(st))
            {
                throw new InvalidOperationException("Student is not signed for the course!");
            }

            this.students.Remove(st);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism.Courses
{
    public abstract class Course
    {
        private string courseName;
        private string teacherName;
        private List<string> students = new List<string>();

        public Course(string courseName)
        {
            this.CourseName = courseName;
            this.TeacherName = null;
        }

        public Course(string courseName, string teacherName)
        {
            this.CourseName = courseName;
            this.TeacherName = teacherName;
        }

        public Course(string courseName, string teacherName, IList<string> students)
        {
            this.CourseName = courseName;
            this.TeacherName = teacherName;
            this.students = new List<string>(students);
        }

        public string CourseName
        {
            get
            {
                return this.courseName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Course name is the only parameter that can not be empty");
                }

                this.courseName = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            set
            {
                this.teacherName = value;
            }
        }

        public IEnumerable<string> Students
        {
            get
            {
                return this.students;
            }
        }

        public void AddStudent(string name)
        {
            if (name != null)
            {
                this.students.Add(name);
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("{ courseName = ");
            result.Append(this.CourseName);

            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());

            return result.ToString();
        }

        protected string GetStudentsAsString()
        {
            if (this.students == null || this.students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}

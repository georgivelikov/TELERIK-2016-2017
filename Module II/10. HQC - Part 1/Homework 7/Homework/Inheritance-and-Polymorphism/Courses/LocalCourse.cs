using System;
using System.Collections.Generic;
using System.Text;


namespace InheritanceAndPolymorphism.Courses
{
    public class LocalCourse : Course
    {
        private string lab;

        public LocalCourse(string courseName, string teacherName, IList<string> students, string lab)
            : base(courseName, teacherName, students)
        {
            this.Lab = lab;
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students)
            : this(courseName, teacherName, students, null)
        {
        }

        public LocalCourse(string courseName, string teacherName)
            : this(courseName, teacherName, new List<string>(), null)
        {
        }

        public LocalCourse(string courseName)
            : this(courseName, null, new List<string>(), null)
        {
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }

            set
            {
                this.lab = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("LocalCourse ");

            result.Append(base.ToString());

            if (this.Lab != null)
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
            }

            result.Append(" }");

            return result.ToString();
        }
    }
}

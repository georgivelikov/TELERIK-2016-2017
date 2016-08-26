namespace Task_01.School_Objects
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Task_01.People;

    public class Class
    {
        private string identifier;
        private List<Student> students;
        private List<Teacher> teachers;
        private string comment;
        private HashSet<uint> classNumbers;

        public Class(string identifier, string comment = null)
        {
            this.Identifier = identifier;
            this.students = new List<Student>();
            this.teachers = new List<Teacher>();
            this.comment = comment;
            this.classNumbers = new HashSet<uint>();
        }

        public string Identifier
        {
            get
            {
                return this.identifier;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Class must have identifier!");
                }

                this.identifier = value;
            }
        }

        public IEnumerable<Student> Students
        {
            get
            {
                return this.students;
            }   
        }

        public IEnumerable<Teacher> Teachers
        {
            get
            {
                return this.teachers;
            }
        }

        public string Comment
        {
            get
            {
                return this.comment;
            }

            set
            {
                this.comment = value;
            }
        }

        public void AddStudent(Student student)
        {
            if (this.classNumbers.Contains(student.ClassNumber))
            {
                throw new Exception("Student class number must be unique!");
            }

            this.students.Add(student);
            this.classNumbers.Add(student.ClassNumber);
        }

        public void AddTeacher(Teacher teacher)
        {
            this.teachers.Add(teacher);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.Identifier);
            sb.AppendLine("Students: ");
            sb.AppendLine(string.Join("\n", this.students));
            sb.AppendLine("Teachers: ");
            sb.AppendLine(string.Join("\n", this.teachers));

            return sb.ToString();
        }
    }
}

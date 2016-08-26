namespace Task01
{
    using System;
    using System.Text;

    using Task01.Enumerations;

    public class Student : ICloneable, IComparable<Student>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private int ssn;
        private string address;
        private string mobilePhone;
        private string email;
        private int course;
        private Speciality speciality;
        private Faculty faculty;
        private University university;

        public Student(
            string firstName,
            string middleName,
            string lastName, 
            int ssn, 
            string address, 
            string mobilePhone,
            string email,
            int course,
            Speciality speciality,
            Faculty faculty,
            University university)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.Address = address;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Course = course;
            this.Speciality = speciality;
            this.Faculty = faculty;
            this.University = university;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Student must have first name");
                }

                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Student must have middle name");
                }

                this.middleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Student must have last name");
                }

                this.lastName = value;
            }
        }

        public string FullName
        {
            get
            {
                return this.firstName + " " + this.middleName + " " + this.lastName;
            }
        }
        public int SSN
        {
            get
            {
                return this.ssn;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("SSN must be positve");
                }

                this.ssn = value;
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Student must have address");
                }

                this.address = value;
            }
        }

        public string MobilePhone
        {
            get
            {
                return this.mobilePhone;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Student must have mobile phone");
                }

                this.mobilePhone = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Student must have email");
                }

                this.email = value;
            }
        }

        public int Course
        {
            get
            {
                return this.course;
            }

            set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException("Student must be between 1st and 5th course");
                }

                this.course = value;
            }
        }

        public Speciality Speciality
        {
            get
            {
                return this.speciality;
            }

            set
            {
                this.speciality = value;
            }
        }

        public Faculty Faculty
        {
            get
            {
                return this.faculty;
            }

            set
            {
                this.faculty = value;
            }
        }

        public University University
        {
            get
            {
                return this.university;
            }

            set
            {
                this.university = value;
            }
        }

        public static bool operator ==(Student student, Student otherStudent)
        {
            return student.Equals(otherStudent);
        }

        public static bool operator !=(Student student, Student otherStudent)
        {
            return !(student == otherStudent);
        }

        public int CompareTo(Student other)
        {
            if (string.Compare(this.FullName, other.FullName, StringComparison.Ordinal) > 0)
            {
                return 1;
            }
            else if (string.Compare(this.FullName, other.FullName, StringComparison.Ordinal) < 0)
            {
                return -1;
            }
            else
            {
                if (this.SSN > other.SSN)
                {
                    return 1;
                }
                else if (this.SSN < other.SSN)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("First Name: " + this.FirstName);
            sb.AppendLine("Middle Name: " + this.MiddleName);
            sb.AppendLine("Last Name: " + this.LastName);
            sb.AppendLine("SSN: " + this.SSN);
            sb.AppendLine("Address: " + this.Address);
            sb.AppendLine("Mobile Phone: " + this.MobilePhone);
            sb.AppendLine("Email: " + this.Email);
            sb.AppendLine("Course: " + this.Course);
            sb.AppendLine("Speciality: " + this.Speciality);
            sb.AppendLine("Faculty: " + this.Faculty);
            sb.AppendLine("University: " + this.University);

            return sb.ToString().Trim();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ this.SSN;
        }

        public object Clone()
        {
            var copy = new Student(
                this.FirstName,
                this.MiddleName,
                this.LastName,
                this.SSN,
                this.Address,
                this.MobilePhone,
                this.Email,
                this.Course,
                this.Speciality,
                this.Faculty,
                this.University);

            return copy;
        }

        public override bool Equals(object obj)
        {
            var otherStudent = obj as Student;

            if (this.SSN == otherStudent.SSN 
                && this.FirstName == otherStudent.FirstName
                && this.MiddleName == otherStudent.MiddleName
                && this.LastName == otherStudent.LastName
                && this.Address == otherStudent.Address
                && this.MobilePhone == otherStudent.MobilePhone
                && this.Email == otherStudent.Email
                && this.Speciality == otherStudent.Speciality
                && this.Faculty == otherStudent.Faculty
                && this.Course == otherStudent.Course
                && this.University == otherStudent.University)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

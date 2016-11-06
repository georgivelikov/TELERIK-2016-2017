using System;
using System.Text;

namespace Methods
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private string placeOfBirth;
        private string otherInfo;

        public Student(string firstName, string lastName, DateTime dateOfBirth, string placeOfBirth)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.PlaceOfBirth = placeOfBirth;
        }

        public Student(string firstName, string lastName, DateTime dateOfBirth, string placeOfBirth, string otherInfo)
            : this(firstName, lastName, dateOfBirth, placeOfBirth)
        {
            this.OtherInfo = otherInfo;
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
                    throw new ArgumentNullException("First name can not be empty!");
                }

                this.firstName = value; 
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
                    throw new ArgumentNullException("Last name can not be empty!");
                }

                this.lastName = value;
            }
        }

        public DateTime DateOfBirth
        {
            get { return this.dateOfBirth; }
            set { this.dateOfBirth = value; }
        }

        public string PlaceOfBirth
        {
            get
            {
                return this.placeOfBirth;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Place of birth can not be empty!");
                }

                this.placeOfBirth = value;
            }
        }

        public string OtherInfo
        {
            get { return this.otherInfo; }
            set { this.otherInfo = value; }
        }

        public bool IsOlderThan(Student otherStudent)
        {
            return this.DateOfBirth > otherStudent.DateOfBirth;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("{0} {1}", this.FirstName, this.LastName));
            sb.AppendLine(string.Format("Date of birth: {0}", this.DateOfBirth.ToShortDateString()));
            sb.AppendLine(string.Format("Place of birth: {0}", this.PlaceOfBirth));
            if (this.OtherInfo != null)
            {
                sb.AppendLine(string.Format("Other info: {0}", this.OtherInfo));
            }
            else
            {
                sb.AppendLine("Other info: n/a");
            }

            return sb.ToString();
        }

        
    }
}

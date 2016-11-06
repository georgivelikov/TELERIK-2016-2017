namespace School
{
    using System;
    using System.Collections.Generic;

    public class School
    {
        // c# random is [minLimin, maxLimit) - uppper limit is exclusive;
        private const int MinStudentNumber = 10000;
        private const int MaxStudentNumber = 100000;

        private static Random numberGenerator = new Random();
        private HashSet<int> studentNumbers;
        private ICollection<Course> courses;
        private ICollection<string> coursesNames;

        public School()
        {
            this.courses = new HashSet<Course>();
            this.studentNumbers = new HashSet<int>();
            this.coursesNames = new HashSet<string>();
        }

        public ICollection<Course> Courses
        {
            get
            {
                return this.courses;
            }
        }

        public int GenerateStudentId()
        {
            // avoid duplicate
            int number = numberGenerator.Next(MinStudentNumber, MaxStudentNumber);
            while (true)
            {              
                if (!this.studentNumbers.Contains(number))
                {
                    break;
                }

                number = numberGenerator.Next(MinStudentNumber, MaxStudentNumber);
            }

            this.studentNumbers.Add(number);

            return number;
        }

        public void AddCourse(Course course)
        {
            if (this.courses.Contains(course))
            {
                throw new InvalidOperationException("The course is already added!");
            }

            if (this.coursesNames.Contains(course.CourseName))
            {
                throw new InvalidOperationException("The course with this name already exists!");
            }

            this.courses.Add(course);
            this.coursesNames.Add(course.CourseName);
        }
    }
}

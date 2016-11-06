﻿using System;
using System.Collections.Generic;
using System.Text;
using InheritanceAndPolymorphism.Courses;

namespace InheritanceAndPolymorphism
{
    public class OffsiteCourse : Course
    {
        public OffsiteCourse(string courseName, string teacherName, IList<string> students, string town)
            : base(courseName, teacherName, students)
        {
            this.Town = town;
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
            : this(courseName, teacherName, students, null)
        {
        }

        public OffsiteCourse(string courseName, string teacherName)
            : this(courseName, teacherName, new List<string>(), null)
        {
        }

        public OffsiteCourse(string courseName)
            : this(courseName, null, new List<string>(), null)
        {
        }

        public string Town { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("OffsiteCourse ");

            result.Append(base.ToString());

            if (this.Town != null)
            {
                result.Append("; Town = ");
                result.Append(this.Town);
            }

            result.Append(" }");

            return result.ToString();
        }
    }
}

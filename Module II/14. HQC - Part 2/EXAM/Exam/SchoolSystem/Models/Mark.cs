using System;
using SchoolSystem.Enums;
using SchoolSystem.Contracts;

namespace SchoolSystem.Models
{
    public class Mark : IMark
    {
        private const float MinMarkValue = 2;
        private const float MaxMarkValue = 6;
        private const string InvalidMarkMessage = "Invalid Mark! Mark must be between 2 and 6";

        private readonly SubjectEnum subject;
        private readonly float markValue;

        public Mark(SubjectEnum subject, float markValue)
        {
            this.ValidateMarkValue(markValue, MinMarkValue, MaxMarkValue);
            this.subject = subject;
            this.markValue = markValue;
        }

        public SubjectEnum Subject
        {
            get
            {
                return this.subject;
            }
        }

        public float MarkValue
        {
            get
            {
                return this.markValue;
            }
        }

        private void ValidateMarkValue(float mark, float min, float max)
        {
            if (mark < min || mark > max)
            {
                throw new ArgumentException(InvalidMarkMessage);
            }
        }
    }
}

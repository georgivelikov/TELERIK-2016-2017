using System;
using System.CodeDom;

public class ExamResult
{
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        this.MaxGrade = maxGrade;
        this.MinGrade = minGrade;
        this.Grade = grade;
        this.Comments = comments;
    }

    public int Grade
    {
        get
        {
            return this.grade;
        }

        private set
        {
            if (value < this.MinGrade || value > this.MaxGrade)
            {
                throw new ArgumentException("Grade can not be les than the minimal possible grade!");
            }

            if (value > this.MaxGrade)
            {
                throw new ArgumentException("Grade can not be bigger than the maximal possible grade!");
            }

            this.grade = value;
        }
    }

    public int MinGrade
    {
        get
        {
            return this.minGrade;
        }

        private set
        {
            if (value > this.maxGrade)
            {
                throw new ArgumentException("Min grade should be less than max grade!");
            }

            this.minGrade = value;
        }
    }

    public int MaxGrade
    {
        get
        {
            return this.maxGrade;
        }

        private set
        {
            if (value < this.minGrade)
            {
                throw new ArgumentException("Max grade should be bigger than min grade!");
            }

            this.maxGrade = value;
        }
    }

    public string Comments
    {
        get
        {
            return this.comments;
        }

        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Comments can not be null or empty!");
            }

            this.comments = value;
        }
    }
}

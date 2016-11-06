using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    private string firstName;
    private string lastName;
    private IList<Exam> exams;
    private IList<ExamResult> examResults;

    public Student(string firstName, string lastName, IList<Exam> exams)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.exams = new List<Exam>(exams);
        this.examResults = this.GenerateExamResultsList(this.exams);
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
                throw new ArgumentNullException(this.FirstName, "First name cannot be null or white space");
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
                throw new ArgumentNullException("Last name cannot be null or white space");
            }

            this.lastName = value;
        }
    }

    public IEnumerable<Exam> Exams
    {
        get
        {
            return this.exams;
        }
    }

    public IEnumerable<ExamResult> ExamResults
    {
        get
        {
            return this.examResults;
        }
    }

    public double CalcAverageExamResultInPercents()
    {
        double[] examScore = new double[this.exams.Count];

        for (int i = 0; i < this.examResults.Count; i++)
        {
            examScore[i] =
                (double)(this.examResults[i].Grade - this.examResults[i].MinGrade) /
                (this.examResults[i].MaxGrade - this.examResults[i].MinGrade);
        }

        return examScore.Average();
    }

    private IList<ExamResult> GenerateExamResultsList(IList<Exam> exams)
    {
        if (exams == null)
        {
            throw new ArgumentNullException("exams", "Exam list is not initialized!");
        }

        if (exams.Count == 0)
        {
            throw new ArgumentException("Student has no exams!");
        }

        var examResults = new List<ExamResult>();

        for (int i = 0; i < this.exams.Count; i++)
        {
            var result = this.exams[i].GenerateExamResult();
            examResults.Add(result);
        }

        return examResults;
    }
}

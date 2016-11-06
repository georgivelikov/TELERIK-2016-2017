using System;

public class SimpleMathExam : Exam
{
    private int problemSolved;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get
        {
            return this.problemSolved;
        }

        private set
        {
            if (value < 0 || value > 10)
            {
                throw new ArgumentException("Solved problems must be between 0 and 10");
            }


            this.problemSolved = value;
        }
    }

    public override ExamResult GenerateExamResult()
    {
        if (this.ProblemsSolved <= 1)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (this.ProblemsSolved <= 3 && this.ProblemsSolved > 1)
        {
            return new ExamResult(3, 2, 6, "Poor result: Almost nothing done.");
        }
        else if (this.ProblemsSolved <= 5 && this.ProblemsSolved > 3)
        {
            return new ExamResult(4, 2, 6, "Average result: Some things are done correctly.");
        }
        else if (this.ProblemsSolved <= 7 && this.ProblemsSolved > 5)
        {
            return new ExamResult(4, 2, 6, "Good result: Most of the things are done correctly.");
        }
        else if (this.ProblemsSolved <= 10 && this.ProblemsSolved > 7)
        {
            return new ExamResult(4, 2, 6, "Excellent result: Almost all of the things are done correctly.");
        }
        else
        {
            return null;
        }
    }
}

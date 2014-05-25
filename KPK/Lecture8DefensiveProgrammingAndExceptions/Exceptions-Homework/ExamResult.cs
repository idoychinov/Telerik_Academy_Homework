using System;

public class ExamResult
{
    private int grade;

    private int minGrade;

    private int maxGrade;

    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (maxGrade <= minGrade)
        {
            throw new ArithmeticException("Max Grade must be greater than Min Grade");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
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
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("The Grade must be positive number or zero.");
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
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("The Min Grade must be positive number or zero.");
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
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("The Max Grade must be positive number or zero.");
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
            if (value == null)
            {
                throw new ArgumentNullException("The comments cannot be null.");
            }
            else if (value == string.Empty)
            {
                throw new ArgumentOutOfRangeException("The comments cannot be empty.");
            }

            this.comments = value;
        }
    }
}

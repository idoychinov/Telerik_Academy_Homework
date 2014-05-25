using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    private string firstName;

    private string lastName;

    private IList<IExam> exams;

    public Student(string firstName, string lastName, IList<IExam> exams)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }

        set
        {
            if (value == null || value == string.Empty)
            {
                throw new ArgumentException("First name cannot be null or empty.");
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
            if (value == null || value == string.Empty)
            {
                throw new ArgumentException("Last name cannot be null or empty.");
            }

            this.lastName = value;
        }
    }

    public IList<IExam> Exams 
    {
        get
        {
            return this.exams;
        }

        set
        {
            if (value == null)
            {
                throw new ArgumentException("Exams list cannot be null. Consider passing an empty IList object.");
            }

            this.exams = value;
        }
    }

    public IList<ExamResult> CheckExams()
    {
        if (this.Exams.Count == 0)
        {
            throw new InvalidOperationException("Student has no exams to check.");
        }

        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        if (this.Exams == null)
        {
            // Cannot calculate average on missing exams
            throw new NullReferenceException("The Exams list is null.");
        }

        if (this.Exams.Count == 0)
        {
            // No exams 
            throw new InvalidOperationException("The Exams list is empty.");
        }

        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = this.CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] = 
                ((double)examResults[i].Grade - examResults[i].MinGrade) / 
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}

//-----------------------------------------------------------------------
// <copyright file="Student.cs" company="Test Company">
//      Style Cop is finaly happy... yey!
// </copyright>
//-----------------------------------------------------------------------
namespace Methods
{
    using System;

    /// <summary>
    /// A class describing student
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Gets or sets the first name of the student
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the student
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the birth date of the student
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the other information about student
        /// </summary>
        public string OtherInfo { get; set; }

        /// <summary>
        /// Compares this student's age with another.
        /// </summary>
        /// <param name="otherStudent">Student to compare the current student</param>
        /// <returns>True if this student is older than the one passed as parameter</returns>
        public bool IsOlderThan(Student otherStudent)
        {
            if (this.BirthDate == null)
            {
                throw new InvalidOperationException("Current student Birth date is unknown!");
            }
            else if (otherStudent.BirthDate == null)
            {
                throw new ArgumentNullException("Passed student argument Birth date is unknown!");
            }

            bool isOlder = this.BirthDate > otherStudent.BirthDate;
            return isOlder;
        }
    }
}

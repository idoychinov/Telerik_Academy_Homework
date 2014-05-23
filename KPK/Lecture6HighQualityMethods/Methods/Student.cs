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
        /// First name of the student
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the student
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Birth date of the student
        /// </summary>
        public DateTime BirthDate { get; set; }

        public string OtherInfo { get; set; }

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

using System;
using System.Collections.Generic;

namespace School
{
    public class Student : Person
    {
        // Using static hashset in order to prevent duplicate class numbers
        private static HashSet<int> uniqueClassNumbers;

        static Student()
        {
            uniqueClassNumbers = new HashSet<int>();
        }

        private int classNumber;

        public Student(string name, int classNumber)
        {
            this.Name = name;
            if (classNumber <= 0)
            {
                throw new ArgumentException("The Class number must be positive number.");
            }

            if (!uniqueClassNumbers.Add(classNumber))
            {
                throw new ArgumentException("Duplicate class ID");
            }

            this.classNumber = classNumber;
        }

        public int ClassNumber
        {
            get
            {
                return this.classNumber;
            }
        }

    }
}

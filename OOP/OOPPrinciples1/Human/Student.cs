using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human
{
    public class Student : Human
    {
        public byte Grade { get; set; }

        public Student(string firstName, string lastName)
            : base(firstName, lastName)
        {
        }

        public Student(string firstName, string lastName, int grade)
            : this(firstName, lastName)
        {
            this.Grade = (byte)grade;
        }
    }
}

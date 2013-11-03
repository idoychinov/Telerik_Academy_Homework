using System;
using System.Text;

namespace P01to03Student
{
    public class Student : ICloneable, IComparable<Student>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int SSN { get; set; }
        public string PermanentAddres { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string Course { get; set; }
        public Specialty Specialty { get; set; }
        public University University { get; set; }
        public Faculty Faculty { get; set; }        
        
        public override bool Equals(object param)
        {
            if (!(param is Student))
            {
                return false;
            }
            Student student = param as Student;

            bool namesAreEqual = object.Equals(this.FirstName, student.FirstName) && object.Equals(this.MiddleName, student.MiddleName) 
                && object.Equals(this.LastName, student.LastName);

            bool ssnIsEquals = object.Equals(this.SSN, student.SSN);

            bool otherParametersAreEqual = object.Equals(this.Faculty, student.Faculty)&&object.Equals(this.University, student.University)
                &&object.Equals(this.Specialty, student.Specialty);

            bool studentsAreEqual = namesAreEqual && ssnIsEquals && otherParametersAreEqual;

            return studentsAreEqual;
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ this.MiddleName.GetHashCode() ^ this.LastName.GetHashCode() ^ this.SSN.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder studentToString=new StringBuilder();
            studentToString.Append("Student: ");
            studentToString.Append(this.FirstName+" ");
            studentToString.Append(this.MiddleName+" ");
            studentToString.AppendLine(this.LastName);
            studentToString.AppendLine("SSN: " + this.SSN);
            studentToString.AppendLine("Address: " + this.PermanentAddres);
            studentToString.AppendLine("Mobile: " + this.MobilePhone);
            studentToString.AppendLine("Email: " + this.Email);
            studentToString.AppendLine("Course: " + this.Course);
            studentToString.AppendLine("University: " + this.University);
            studentToString.AppendLine("Faculty: " + this.Faculty);
            studentToString.AppendLine("Specialty: " + this.Specialty);

            return studentToString.ToString();
        }

        public static bool operator ==(Student studentA, Student studentB)
        {
            return studentA.Equals(studentB);
        }

        public static bool operator !=(Student studentA, Student studentB)
        {
            return !studentA.Equals(studentB);
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Student Clone()
        {
            Student student = new Student();

            student.FirstName = this.FirstName;
            student.MiddleName = this.MiddleName;
            student.LastName = this.LastName;
            student.SSN = this.SSN;
            student.PermanentAddres = this.PermanentAddres;
            student.MobilePhone = this.MobilePhone;
            student.Email = this.Email;
            student.Course = this.Course;
            student.Specialty = this.Specialty;
            student.University = this.University;
            student.Faculty = this.Faculty;

            return student;
        }

        public int CompareTo(Student student)
        {
            if (this.FirstName != student.FirstName)
            {
                return this.FirstName.CompareTo(student.FirstName);
            }

            if (this.MiddleName != student.MiddleName)
            {
                return this.MiddleName.CompareTo(student.MiddleName);
            }

            if (this.LastName != student.LastName)
            {
                return this.LastName.CompareTo(student.LastName);
            }

            if (this.SSN != student.SSN)
            {
                return this.SSN.CompareTo(student.SSN);
            }
            else
            {
                return 0;
            }
        }
    }
}

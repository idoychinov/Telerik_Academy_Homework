namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Course
    {
        private string name;

        private string teacherName;

        private IList<string> students;

        public Course(string name) :
            this(name, null, null)
        {
        }

        public Course(string name, string teacherName) :
            this(name, teacherName, null)
        {
        }

        public Course(string name, string teacherName, IList<string> students)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        public string Name 
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentException("Course name cannot be empty");
                }

                this.name = value;
            }
        }

        public string TeacherName 
        {
            get
            {
                return this.teacherName;
            }

            set
            {
                this.teacherName = value;
            }
        }

        public IList<string> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                if (value == null)
                {
                    this.students = new List<string>();
                }
                else
                {
                    this.students = value;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.GetType().Name);
            result.Append(" { Name = ");
            result.Append(this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());
            return result.ToString();
        }

        private string GetStudentsAsString()
        {
            if (this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}

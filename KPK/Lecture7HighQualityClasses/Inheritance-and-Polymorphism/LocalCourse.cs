namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LocalCourse : Course
    {
        private string lab;

        public LocalCourse(string name) :
            this(name, null, null, null)
        {
        }

        public LocalCourse(string name, string teacherName) :
            this(name, teacherName, null, null)
        {
        }

        public LocalCourse(string name, string teacherName, IList<string> students) :
            this(name, teacherName, students, null)
        {
        }

        public LocalCourse(string name, string teacherName, IList<string> students, string lab) :
            base(name, teacherName, students)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }

            set
            {
                this.lab = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            if (this.Lab != null)
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
            }

            result.Append(" }");
            return result.ToString();
        }
    }
}

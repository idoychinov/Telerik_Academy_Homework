namespace School
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private const int MaximumStudentsInCourse = 30;
        private string name;
        private IList<Student> students;

        public Course(string name)
        {
            this.Name = name;
            this.Students = new List<Student>(30);
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Name cannnot be null!");
                }

                if (value == string.Empty)
                {
                    throw new ArgumentOutOfRangeException("Name cannnot be empty!");
                }

                this.name = value;
            }
        }

        public IList<Student> Students
        {
            get
            {
                return new List<Student>(this.students);
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The list of students cannot be null.");
                }

                this.students = value;
            }
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("The student argument cannot be null.");
            }

            if (this.students.Count >= MaximumStudentsInCourse)
            {
                throw new InvalidOperationException("The student argument cannot be null.");
            }

            this.students.Add(student);
        }

        public void RemoveStudent(int id)
        {
            bool missingID = true;
            foreach (var student in this.students)
            {
                if (student.Id == id)
                {
                    this.students.Remove(student);
                    missingID = false;
                    break;
                }
            }

            if (missingID)
            {
                throw new ArgumentException(string.Format("No student with id={0} found in the course", id));
            }
        }
    }
}

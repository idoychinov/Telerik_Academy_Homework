namespace School
{
    using System;

    public class Student
    {
        private const int MaxIdCounter = 99999;
        private const int MinIdCounter = 9999;

        private static int idCounter;
        private string name;
        private int id;

        static Student()
        {
            idCounter = MinIdCounter;
        }

        public Student(string name)
        {
            this.Name = name;
            this.Id = Student.idCounter + 1;
            Student.idCounter++;
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

        public int Id
        {
            get
            {
                return this.id;
            }

            private set
            {
                if (value > Student.MaxIdCounter)
                {
                    throw new ArgumentOutOfRangeException("Maximum number of student IDs reached.");
                }

                this.id = value;
            }
        }
    }
}

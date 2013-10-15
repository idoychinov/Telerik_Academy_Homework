using System;
using System.Collections.Generic;

namespace School
{
    public class Class : AbstractSchoolObject
    {
         // Using static hashset in order to prevent duplicate class numbers
        private static HashSet<string> uniqueIDs;

        public List<Student> Students { get; private set; }
        public List<Teacher> Teachers { get; private set; }
        public string Id { get; private set; }   

        static Class()
        {
            uniqueIDs = new HashSet<string>();
        }

        public Class(string id,List<Student> students, List<Teacher> teachers)
        {
            if (!uniqueIDs.Add(id))
            {
                throw new ArgumentException("Duplicate class ID");
            }
            this.Id = id;
            this.Students = students;
            this.Teachers = teachers;
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public void RemoveStudent(int index)
        {
            Students.RemoveAt(index);
        }

        public void AddTeacher(Teacher teacher)
        {
            Teachers.Add(teacher);
        }

        public void RemoveTeacher(int index)
        {
            Teachers.RemoveAt(index);
        }

    }
}

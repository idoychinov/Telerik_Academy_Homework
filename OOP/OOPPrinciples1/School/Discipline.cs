using System;

namespace School
{
    public class Discipline : AbstractSchoolObject
    {
        public string Name { get; private set; }
        public int NumberOfLectures { get; private set; }
        public string NumberOfExercises { get; private set; }
    }
}

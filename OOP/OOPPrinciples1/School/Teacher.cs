using System;
using System.Collections.Generic;


namespace School
{
    public class Teacher: Person
    {
        public List<Discipline> Disciplines { get; private set; }

        public Teacher(string name,List<Discipline> disciplinesList)
        {
            this.Name = name;
            this.Disciplines = disciplinesList;
        }

        public void AddDiscipline(Discipline discipline)
        {
            Disciplines.Add(discipline);
        }

        public void RemoveDiscipline(int index)
        {
            Disciplines.RemoveAt(index);
        }
    }
}

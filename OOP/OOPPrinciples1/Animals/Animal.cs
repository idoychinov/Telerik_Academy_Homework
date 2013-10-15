using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public enum AnimalSex { Male, Female } // http://www.youtube.com/watch?v=xat1GVnl8-k#t=1m03s  pun intended :)

    public abstract class Animal : ISound
    {
        public int Age { get; private set; }
        public string Name { get; private set; }
        public AnimalSex Sex { get; private set; }

        public Animal(int age, string name, AnimalSex sex)
        {
            this.Age = age;
            this.Name = name;
            this.Sex = sex;
        }

        public abstract void ProduceSound();

        public static IEnumerable<AnimalGroup> CalculateAverageAge( IEnumerable<Animal> animallist)
        {
            var groups = 
            (from animal in animallist
             group animal by animal.GetType().Name into animalTypes
             select new AnimalGroup(animalTypes.Key, 
                 (from anim in animalTypes
                  select anim.Age).Average())
             );

            return groups;
        }
    }
}

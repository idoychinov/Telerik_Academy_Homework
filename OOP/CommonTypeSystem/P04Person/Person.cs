using System;
using System.Text;

namespace Person
{
    // Problem 4. Create a class Person with two fields – name and age. Age can be left unspecified (may contain null value. 
    // Override ToString() to display the information of a person and if age is not specified – to say so. Write a program to test this functionality.

    public class Person
    {
        public string Name { get;private set; }
        public int? Age { get;private set; }

        public Person(string name, int age )
            :this(name)
        {
            this.Age = age;
        }

        public Person(string name)
        {
            this.Name = name;
            this.Age = null;
        }

        public override string ToString()
        {
            StringBuilder personInformation = new StringBuilder();
            personInformation.AppendLine("Name: " + this.Name);
            string age="Age: ";
            if (this.Age == null)
            {
                age += "Unspecified";
            }
            else
            {
                age += this.Age;
            }
            personInformation.AppendLine(age);
            return personInformation.ToString();
        }
    }
}

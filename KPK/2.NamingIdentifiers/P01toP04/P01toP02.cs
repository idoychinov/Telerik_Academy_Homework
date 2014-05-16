using System;
using System.Linq;

namespace P01toP04
{
    //Problem 1

    public class MyClass
    {
        private const int MAX_COUNT = 6;
        internal class MyNestedClass
        {
            internal void DisplayState(bool state)
            {
                string stateAsString = state.ToString();
                Console.WriteLine(stateAsString);
            }
        }
        public static void InputMethod()
        {
            MyClass.MyNestedClass instance =
                new MyClass.MyNestedClass();
            instance.DisplayState(true);
        }
    }


    //Problem 2 

    class Hauptklasse  // това нещо не мога да го разбера какво трябва да е :)
    {
        enum Gender { Male, Female };

        class Human
        {
            public Gender Gender { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
        public void MakeHuman(int age)
        {
            Human newHuman = new Human();
            newHuman.Age = age;
            if (age % 2 == 0)
            {
                newHuman.Name = "Батката";
                newHuman.Gender = Gender.Male;
            }
            else
            {
                newHuman.Name = "Мацето";
                newHuman.Gender = Gender.Female;
            }
        }
    }

    //Problem 3 is in the solution directory since it's java script file
}

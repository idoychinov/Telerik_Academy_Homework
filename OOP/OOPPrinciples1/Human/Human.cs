using System;

namespace Human
{
    public abstract class Human
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}

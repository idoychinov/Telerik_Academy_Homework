using System;

namespace School
{
    public abstract class Person : AbstractSchoolObject
    {
        private string name;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                string givenName = value;
                if(string.IsNullOrWhiteSpace(givenName))
                {
                    throw new ArgumentNullException("Name cannot be empty");
                }

                if (!SchoolHelper.IsValidName(givenName))
                {
                    throw new ArgumentException("Invalid name");
                }
                this.name = givenName;
            }
        }
    }
}

using System;
using Homework;

namespace TestApplication
{
    //Problem 11. Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations and methods and holds a version in the format major.minor (e.g. 2.11). 
    //Apply the version attribute to a sample class and display its version at runtime.

    [VersionAttribute("2", "11")]
    class VersionTest
    {
        static void Main(string[] args)
        {
            Type type = typeof(VersionTest);
            object[] allCustomAttributes = type.GetCustomAttributes(false);
            foreach (VersionAttribute attribute in allCustomAttributes)
            {
                Console.WriteLine("Current version is: {0}",attribute.FullVersion);
            }
        }
    }
}

using System;

namespace Homework
{
    // Problem 11. Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations and methods and holds a version in the format major.minor (e.g. 2.11).
    // Apply the version attribute to a sample class and display its version at runtime.

    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Method)]
    public class VersionAttribute : System.Attribute
    {
        public string MajorVersion { get; private set; }
        public string MinorVersion { get; private set; }
        public string FullVersion
        {
            get
            {
                return MajorVersion + "." + MinorVersion;
            }
        }

        public VersionAttribute(string majorVersion, string minorVersion)
        {
            this.MajorVersion = majorVersion;
            this.MinorVersion = minorVersion;
        }
    }
}

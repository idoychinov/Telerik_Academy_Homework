using System;
namespace School
{
    internal static class SchoolHelper
    {
        internal static bool IsValidName(string name)
        {
            foreach (char letter in name)
            {
                if (!(char.IsLetter(letter) || char.IsWhiteSpace(letter)))
                {
                    return false;
                }
            }
            return true;
        }
    }
}

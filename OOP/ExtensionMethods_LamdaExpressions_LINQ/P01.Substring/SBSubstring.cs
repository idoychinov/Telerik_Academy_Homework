using System;
using System.Text;

// Problem 1. Implement an extension method Substring(int index, int length) for the class StringBuilder
// that returns new StringBuilder and has the same functionality as Substring in the class String.

namespace P01.Substring
{
    public static class SBSubstring
    {
        public static StringBuilder Substring(this StringBuilder sb, int index, int length)
        {
            StringBuilder result = new StringBuilder(length);
            if (sb == null)
            {
                throw new NullReferenceException("Null StringBuilder");
            }

            if (sb == null)
            {
                throw new ArgumentException ("Empty StringBuilder");
            }

            if (index <0 || index >= sb.Length)
            {
                throw new ArgumentOutOfRangeException("Index outside the bounds of the StringBuilder");
            }

            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("Lenght less then zero");
            }

            if (index + length >= sb.Length)
            {
                throw new ArgumentOutOfRangeException("Lenght is outside the StringBuilder size");
            }

            for (int i = index; i < index+length; i++)
            {
                result.Append(sb[i]);
            }

            return result;
        }
        static void Main()
        {
            StringBuilder testSB = new StringBuilder("This is test extension method which should return substring of this StringBuilder");
            Console.WriteLine(testSB.Substring(50,9));  // this shuild return "substring"
            Console.WriteLine("This is test extension method which should return substring of this StringBuilder".Substring(50, 9));
        }
    }
}

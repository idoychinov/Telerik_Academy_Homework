/* Problem 10. Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings. Sample input:
 * Hi!
 * Expected output:
 * \u0048\u0069\u0021
 */

using System;
using System.Text;

class ConvertStringToUCLiterals
{
    static void Main()
    {
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();
        StringBuilder escapedOutput = new StringBuilder(6 * text.Length);
        foreach (char item in text)
        {
            escapedOutput.Append(ConvertToUCLiteral(item));
            
        }
        Console.WriteLine("The escaped output is:\n{0}", escapedOutput.ToString());
    }

    private static string ConvertToUCLiteral(char c)
    {
        return string.Format("\\u{0:X4}", (int)c);
        //return string.Concat("\\u",((int)c).ToString().PadLeft(4,'0'));
    }
}


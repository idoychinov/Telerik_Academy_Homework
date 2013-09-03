/* Problem 2. Write a program that reads a string, reverses it and prints the result at the console. Example: "sample"  "elpmas".
 */

using System;


class ReverseString
{
    static void Main()
    {
        Console.WriteLine("Enter string:");
        string text = Console.ReadLine();
        char[] arr = text.ToCharArray();
        Array.Reverse(arr);
        text = new string(arr);
        Console.WriteLine("The reversed string is:\n{0}",text);
    }
}


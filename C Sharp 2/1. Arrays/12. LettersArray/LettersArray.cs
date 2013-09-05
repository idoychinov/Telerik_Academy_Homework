/* 12. Write a program that creates an array containing all letters from the alphabet (A-Z). Read a word from the console and print the index of each of its letters in the array.
 */

using System;

class LettersArray
{
    static void Main()
    {
        char[] letters = new char[26];
        string word;
        int index;

        for (int i = 0; i < 26; i++)
        {
            letters[i] = (char)(65 + i);
        }     
        Console.Write("Enter word:");
        word=Console.ReadLine();
        word=word.ToUpper();
        foreach (char item in word)
        {
            Console.Write("{0,3}",item);
        }
        Console.WriteLine();
        foreach (char item in word)
        {
            index=Array.BinarySearch<char>(letters, item);
            Console.Write("{0,3}", index);
        }
        Console.WriteLine();
    }
}

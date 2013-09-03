/* Problem 13. Write a program that reverses the words in given sentence.
 *	Example: "C# is not C++, not PHP and not Delphi!"  "Delphi not and PHP, not C++ not is C#!".
 */

using System;
using System.Text;

class ReverseWords
{
    static void Main()
    {
        Console.WriteLine("Enter sentance:");
        string sentance = Console.ReadLine();
        int len = sentance.Length;
        string sentenceEnd="";
        if ((sentance[len - 1] == '.') || (sentance[len - 1] == '!') || (sentance[len - 1] == '?'))
        {
            sentenceEnd = sentance[len - 1].ToString();
            len--;
            sentance = sentance.Substring(0, len);
        }
        else
        {
        }
        string[] words = sentance.Split(' ');
        string[] punctuation = new string[words.Length];
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];
            if (word[word.Length - 1] == ',')
            {
                punctuation[i] = ",";
                words[i] = words[i].Substring(0, word.Length - 1);
            }
            else
            {
                punctuation[i] = "";
            }
        }
        StringBuilder reversed = new StringBuilder();
        for (int i = words.Length-1; i > 0; i--)
        {
            reversed.Append(string.Concat(words[i],punctuation[words.Length-1-i]," "));
        }
        reversed.Append(words[0]);
        Console.WriteLine("The reverced sentance is:\n{0}", string.Concat(reversed.ToString(), sentenceEnd));
    }

}


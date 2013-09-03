/* Problem 21. Write a program that reads a string from the console and prints all different letters in the string along with information how many times each letter is found. 
 */

using System;

class LetterCount
{
    static void Main()
    {
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();
        Console.WriteLine("Occurence of characters in string:");
        while (text != "")
        {
            int index=-1;
            int count=0;
            while (((index = text.IndexOf(text[0], index+1)) != -1)&&(index<text.Length))
            {
                count++;
            }
            Console.WriteLine("{0}: {1}",text[0],count);
            text=text.Replace(text[0].ToString(),"");
        }
        
    }
    
}


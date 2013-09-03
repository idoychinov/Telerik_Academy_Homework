/* Problem 4. Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).
 */

using System;


class SubstringCount
{
    static void Main()
    {
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();
        Console.WriteLine("Enter searched substring:");
        string search = Console.ReadLine();
        
        int index=-1;
        int count = 0;
        while((index=text.IndexOf(search,index+1,StringComparison.OrdinalIgnoreCase)) != -1)
        {
            count++;
        }
        Console.WriteLine("The substring \"{0}\" is found {1} times in the string", search,count);
    }

}


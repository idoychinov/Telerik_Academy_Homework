/* Problem 3. Write a program to check if in a given expression the brackets are put correctly. Example of correct expression: ((a+b)/5-d). Example of incorrect expression: )(a+b)).
 */

using System;


class Brackets
{
    static void Main()
    {
        Console.WriteLine("Enter expresion:");
        string exp = Console.ReadLine();
        if (CheckAllBrackets(exp))
        {
            Console.WriteLine("Brackets are correct");
        }
        else
        {
            Console.WriteLine("Brackets are incorect");
        }
    }

    private static bool CheckAllBrackets(string exp)
    {
        if (CheckSpecificBrackets(exp, '(', ')') && CheckSpecificBrackets(exp, '[', ']') && CheckSpecificBrackets(exp, '{', '}'))
        {
            return true;
        }
        return false;
    }

    private static bool CheckSpecificBrackets(string text,char openBracket,char closeBracket)
    {
        int open = 0, closed = 0;
        foreach (char item in text)
        {
            if (item == openBracket)
            {
                open++;
            }
            else if (item == closeBracket)
            {
                closed++;
            }

            if (closed > open)
            {
                return false;
            }
        }
        if (closed != open)
        {
            return false;
        }
        return true;
    }
}


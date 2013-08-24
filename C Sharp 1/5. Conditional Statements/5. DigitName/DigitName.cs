/* Problem 5. Write program that asks for a digit and depending on the input shows the name of that digit (in English) using a switch statement.
 */
using System;
using MyIO;

class DigitName
{
    static void Main()
    {
        byte digit;
        bool tryAgain=true;

        while (tryAgain)
        {
            MyIOClass.Input(out digit, "Please enter a digit: ", "This is not a digit! Please try again:");
            tryAgain = false;
            switch (digit)
            {
                case 0: Console.WriteLine("Zero"); break;
                case 1: Console.WriteLine("One"); break;
                case 2: Console.WriteLine("Two"); break;
                case 3: Console.WriteLine("Three"); break;
                case 4: Console.WriteLine("Four"); break;
                case 5: Console.WriteLine("Five"); break;
                case 6: Console.WriteLine("Six"); break;
                case 7: Console.WriteLine("Seven"); break;
                case 8: Console.WriteLine("Eight"); break;
                case 9: Console.WriteLine("Nine"); break;
                default: Console.WriteLine("This is not a digit!\n"); tryAgain = true; break;
            }
        }
    }
}


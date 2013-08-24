/* Problem 10. Write a program that applies bonus scores to given scores in the range [1..9]. The program reads a digit as an input. 
 * If the digit is between 1 and 3, the program multiplies it by 10; if it is between 4 and 6, multiplies it by 100; if it is between 7 and 9, multiplies it by 1000. 
 * If it is zero or if the value is not a digit, the program must report an error. Use a switch statement and at the end print the calculated new value in the console.
 */
using System;

class BonusScore
{
    static void Main()
    {
        ConsoleKeyInfo key;
        int result;
        Console.Write("Please enter score in the range [1..9]: ");
        key = Console.ReadKey();
        Console.WriteLine();
        switch (key.KeyChar)
        {
            case '1':
            case '2':
            case '3':
                result = ((int)key.KeyChar-48)*10;
                Console.WriteLine("The score is: {0}", result);
                break;
            case '4':
            case '5':
            case '6':
                result = ((int)key.KeyChar - 48)*100;
                Console.WriteLine("The score is: {0}", result);
                break;
            case '7':
            case '8':
            case '9':
                result = ((int)key.KeyChar - 48)*1000;
                Console.WriteLine("The score is: {0}", result);
                break;
            default: Console.WriteLine("THe entered score is not correct!"); break;
        }   

    }
}


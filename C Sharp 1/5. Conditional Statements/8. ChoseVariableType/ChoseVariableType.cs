/* Problem 8. Write a program that, depending on the user's choice inputs int, double or string variable. If the variable is integer or double, increases it with 1. 
 * If the variable is string, appends "*" at its end. The program must show the value of that variable as a console output. Use switch statement.
 */

using System;
using MyIO;


class ChoseVariableType
{
    static void Main()
    {

        int intVariable;
        double doubleVariable;
        string stringVariable;
        bool tryAgain;
        ConsoleKeyInfo key;

        do
        {
            tryAgain = false;
            Console.Write("Please chose what variable you will input [ i for integer, d for double, s for string ]: ");
            key=Console.ReadKey();
            Console.WriteLine();
            switch (key.KeyChar)
            {
                case 'i':
                    MyIOClass.Input(out intVariable); 
                    Console.WriteLine("Integer variable + 1: {0}", intVariable + 1); 
                    break;
                case 'd':
                    MyIOClass.Input(out doubleVariable); 
                    Console.WriteLine("Double variable + 1: {0}", doubleVariable + 1); 
                    break;
                case 's':
                    Console.Write("Please enter a string: ");
                    stringVariable = Console.ReadLine();
                    Console.WriteLine("String variable + *: {0}", stringVariable + "*"); 
                    break;
                default: tryAgain = true; Console.WriteLine("Incorect choise!\n"); break;
            }
        } while (tryAgain);

        
    }

}
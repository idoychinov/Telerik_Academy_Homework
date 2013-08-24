/*Problem 5. Write a program that gets two numbers from the console and prints the greater of them. Don’t use if statements.
 */

using System;
using MyIO;

class GreaterNumber
{
    static void Main()
    {
        int value1, value2;
        MyIOClass.Input(out value1, "Please enter the first number: ");
        MyIOClass.Input(out value2, "Please enter the second number: ");
        Console.WriteLine("The maximum value of the two numbers is: {0}",Math.Max(value1,value2));
    }
}


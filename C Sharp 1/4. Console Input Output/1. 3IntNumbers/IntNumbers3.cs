/* Problem 1. Write a program that reads 3 integer numbers from the console and prints their sum.
 */
using System;
using MyIO;//using methods defined in another project within the solution.

class IntNumbers3
{
    static void Main()
    {
        int intValue1, intValue2, intValue3;

        MyIOClass.Input(out intValue1, "Please enter the first integer: ");
        MyIOClass.Input(out intValue2, "Please enter the second integer: ");
        MyIOClass.Input(out intValue3, "Please enter the third integer: ");
        Console.WriteLine("The sum of the inputed integers {0}",intValue1+intValue2+intValue3);
        
    }
}


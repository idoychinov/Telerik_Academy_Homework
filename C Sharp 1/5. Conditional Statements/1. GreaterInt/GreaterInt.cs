/* Problem 1. Write an if statement that examines two integer variables and exchanges their values if the first one is greater than the second one.
 */
using System;
using MyIO; //using methods defined in another project within the solution.

class GreaterInt
{
    static void Main()
    {
        int intValue1, intValue2, temp;

        MyIOClass.Input(out intValue1, "Please enter the first integer: ");
        MyIOClass.Input(out intValue2, "Please enter the second integer: ");
        if (intValue1 > intValue2)
        {
            temp = intValue1;
            intValue1 = intValue2;
            intValue2 = temp;
        }
        Console.WriteLine("First variable: {0}\nSecond variable: {1}", intValue1, intValue2);

    }
}


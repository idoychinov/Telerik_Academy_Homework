/* Problem 7. Write a program that finds the greatest of given 5 variables.
 */

using System;
using MyIO;

class GreatestOfFive
{
    static int MaxNum(int a, int b)
    {
        if (a > b)
        {
            return a;
        }
        else
        {
            return b;
        }
    }
    static void Main()
    {

        int first, second, third, fourth,fifth;
        MyIOClass.Input(out first, "Please enter the first variable: ");
        MyIOClass.Input(out second, "Please enter the second variable: ");
        MyIOClass.Input(out third, "Please enter the third variable: ");
        MyIOClass.Input(out fourth, "Please enter the fourth variable: ");
        MyIOClass.Input(out fifth, "Please enter the fifth variable: ");



        Console.WriteLine("The greatest number among the five is {0}",MaxNum(fifth, MaxNum(fourth, MaxNum(third, MaxNum(first, second)))));
    }
    
}
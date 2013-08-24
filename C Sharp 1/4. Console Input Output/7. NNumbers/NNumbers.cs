/*Problem 7. Write a program that gets a number n and after that gets more n numbers and calculates and prints their sum. 
 */

using System;
using MyIO;

class NNumbers
{
    static void Main()
    {
        int number,sum=0;
        byte n;
        MyIOClass.Input(out n, "How much numbers do you want to enter(0-255): ");
        for (int i = 0; i < n; i++)
        {
            MyIOClass.Input(out number);
            sum += number;
        }
        Console.WriteLine("The sum of the numbers is: {0}",sum);
    }
}
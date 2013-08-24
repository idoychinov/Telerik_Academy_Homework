/*Problem 9. Write a program to print the first 100 members of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
 */
using System;

class Fibonacci
{
    static void Main()
    {
        decimal fibMember1 = 0, fibMember2 = 1, temp; // the integer types (even long) are not sufficient to hold the such big numbers so we use decimal
        Console.WriteLine("0\n1");
        for (int i = 2; i <= 100; i++)
        {
            temp = fibMember1 + fibMember2;
            Console.WriteLine(temp);
            fibMember1 = fibMember2;
            fibMember2 = temp;
        }
        Console.WriteLine();
    }
}


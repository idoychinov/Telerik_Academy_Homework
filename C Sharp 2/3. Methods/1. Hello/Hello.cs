/* Problem 1. Write a method that asks the user for his name and prints “Hello, <name>” (for example, “Hello, Peter!”). Write a program to test this method.
*/

using System;

class Hello
{
    static void WhatsYourName()
    {
        Console.Write("What is your name:");
        string name = Console.ReadLine();
        Console.WriteLine("\nHello {0}!\n", name);
    }

    static void Main()
    {
        WhatsYourName();
    }
}

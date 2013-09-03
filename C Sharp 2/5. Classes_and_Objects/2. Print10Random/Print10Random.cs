/* Problem 2. Write a program that generates and prints to the console 10 random values in the range [100, 200].
 */
using System;
using System.Linq;


class Print10Random
{
    static void Main()
    {
        Random rand = new Random();
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Random numbe {0}={1}",i+1,rand.Next(100,200));
        }
    }
}


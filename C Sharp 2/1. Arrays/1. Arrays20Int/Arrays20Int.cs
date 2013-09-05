/* Problem 1. Write a program that allocates array of 20 integers and initializes each element by its index multiplied by 5. Print the obtained array on the console.
 */

using System;

class Arrays20Int
{
    static void Main()
    {
        int[] myArray;
        myArray = new int[20];

        for (int i = 0; i < myArray.Length; i++)
        {
            myArray[i] = i * 5;
        }

        for (int i = 0; i < myArray.Length; i++)
        {
            Console.WriteLine("myArray[{0}]={1}",i,myArray[i]);
        }
        
    }
}
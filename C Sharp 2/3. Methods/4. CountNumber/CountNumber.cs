/* Problem 4. Write a method that counts how many times given number appears in given array. Write a test program to check if the method is working correctly.
*/

using System;

class CountNumber
{
    static int Count(int[] arr, int number)
    {
        int count=0;
        foreach (int element in arr)
        {
            if (element == number)
            {
                count++;
            }
        }
        return count;
    }

    static void Main()
    {
        int[] array= {3,7,-1,4,86,42,12,56,42,6,3,89,5,23,2,1,0,50,6,11}; // add more elements if you like
        Console.Write("Enter the number in question:");
        int num = int.Parse(Console.ReadLine());
        Console.WriteLine("The number {0} apears {1} times in the array",num, Count(array,num));
    }
}


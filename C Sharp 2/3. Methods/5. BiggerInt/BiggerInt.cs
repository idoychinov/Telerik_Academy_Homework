/* Problem 5. Write a method that checks if the element at given position in given array of integers is bigger than its two neighbors (when such exist).
*/
using System;

public class BiggerInt
{
    public bool BiggerThanNeighbors(int[] array, int index)
    {
        bool left=false,right=false;
        if(index==0)
        {
            left=false; // set to "true" if you want the metod to return true if the first element is bigger than the second
        }
        else
        {
            if(array[index]>array[index-1])
            {
                left=true;
            }

        }
        
        if (index == array.Length-1)
        {
            right = false; // set "true" if you want the metod to return true if the last element is bigger than the previous element
        }
        else
        {
            if (array[index] > array[index + 1])
            {
                right = true;
            }

        }

        return left && right;
    }

    static void Main()
    {
        int[] arr = {7,6,2,5,7,4,1,-4,6,7,4,2,1,6,4,2,9,10,6,5,1};
        int ind;

        do
        {
            Console.Write("Please chose index:");
            ind = int.Parse(Console.ReadLine());
        }
        while ((ind < 0) || (ind > arr.Length - 1));

        BiggerInt compare = new BiggerInt();
        if (compare.BiggerThanNeighbors(arr, ind))
        {
            Console.WriteLine("The number at index {0}: {1} is bigger than it's neigbours ", ind, arr[ind]);
        }
        else
        {
            Console.WriteLine("The number at index {0}: {1} is NOT bigger than it's neigbours ", ind, arr[ind]);
        }
    }
}
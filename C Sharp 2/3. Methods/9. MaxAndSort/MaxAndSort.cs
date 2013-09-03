/* Problem 9.Write a method that return the maximal element in a portion of array of integers starting at given index. Using it write another method that sorts an array in ascending / descending order.
*/
using System;

class MaxAndSort
{
    static int[] FindMax(int[] array,int index)
    {
        int maxElement=int.MinValue,length = array.Length,indexOfMax=0;
        for (int i = index; i < length; i++)
        {
            if(array[i]>maxElement)
            {
                maxElement = array[i];
                indexOfMax = i;
            }
        }
        int[] result = { maxElement, indexOfMax };
        return result;
    }

    static int[] Descending(int[] array)
    {
        int length = array.Length, temp;
        int[] result = new int[2];
        int[] arr = new int[length];
        Array.Copy(array, arr, length);
        for (int i = 0; i < length; i++)
        {
            result = FindMax(arr, i);
            temp = arr[i];
            arr[i] = result[0];
            arr[result[1]] = temp;
        }

        return arr;
    }

    static int[] Ascending(int[] array)
    {
        int length = array.Length,temp;
        int[] arr = new int[length];
        Array.Copy(array, arr, length);
        arr = Descending(arr);
        for (int i = 0; i < length/2; i++)
        {
            temp = arr[i];
            arr[i] = arr[length - i - 1];
            arr[length - i - 1] = temp;
        }
        return arr;
    }

    

    static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("{0,3} ", array[i]);
        }
        Console.WriteLine();
        Console.WriteLine();
    }

    static void Main()
    {
        int[] arr = { 4,7,1,854,31,-56,32,5,7,21,5,8,93,0,-5,1,13,33};
        Console.WriteLine("The original array:");
        PrintArray(arr);
        Console.WriteLine("Ascending order:");
        PrintArray(Ascending(arr));
        Console.WriteLine("Descending order:");
        PrintArray(Descending(arr));
    }
}

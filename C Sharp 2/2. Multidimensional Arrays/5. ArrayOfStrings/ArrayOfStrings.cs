/* Problem 5. You are given an array of strings. Write a method that sorts the array by the length of its elements (the number of characters composing them).
*/
using System;
using System.Collections;

class ArrayOfStrings
{
    // creating interface implementation for the 2 dimensional array
    class RectangularComparer : IComparer
    {
        // maintain a reference to the 2-dimensional array being sorted
        private int[,] sortArray;

        // constructor initializes the sortArray reference
        public RectangularComparer(int[,] theArray)
        {
            sortArray = theArray;
        }

        public int Compare(object x, object y)
        {
            // x and y are integer row numbers into the sortArray
            int i1 = (int)x;
            int i2 = (int)y;

            // compare the items in the sortArray
            return sortArray[1, i1].CompareTo(sortArray[1, i2]);
        }
    }

    static void Main()
    {
        string[] arr = { "abla", "db", "", "gg", "trrebe", "a", "zzzeg", "56fabeqvgg", "berde", "aabetd", "adb", "f" };
        int N= arr.Length;
        int[,] sortArr = new int[2,N];
        int[] tagArr = new int[N];

        for (int i = 0; i < N; i++)
        {
            sortArr[0, i] = i;
            sortArr[1, i] = arr[i].Length;
            tagArr[i] = i;
        }

        Console.WriteLine("The input array is:");
        for (int i = 0; i < N; i++)
        {
            Console.Write(arr[i]+"  ");
        }
        Console.WriteLine("\n");

        RectangularComparer myComparer = new RectangularComparer(sortArr);
        Array.Sort(tagArr, myComparer);

        string[] sortedArray = new string[N];
        for (int i = 0; i < N; i++)
        {
            sortedArray[i] = arr[tagArr[i]];
        }
        Console.WriteLine("The sorted array is:");
        for (int i = 0; i < N; i++)
        {
            Console.Write(sortedArray[i]+"  ");
        }
        Console.WriteLine();
    }
}


using System;
using System.Diagnostics;
using System.Linq;

public class AssertionsHomework
{
    public static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        // SelectionSort(new int[0]); // Test sorting empty array
        // SelectionSort(new int[1]); // Test sorting single element array
        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }

    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "The input array must not be null");
        Debug.Assert(arr.Length > 1, "The input array must greater than 1");
        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        Debug.Assert(x != null, "X must not be null");
        Debug.Assert(y != null, "Y must not be null");
        T oldX = x;
        x = y;
        y = oldX;
        Debug.Assert(y.Equals(oldX), "Objects are not swaped");
    }

    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(arr != null, "The input array must not be null");
        Debug.Assert(startIndex >= 0 && startIndex < arr.Length, "The start index must within the bounds of the array.");
        Debug.Assert(endIndex >= 0 && endIndex < arr.Length, "The end index must within the bounds of the array.");
        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        Debug.Assert(minElementIndex >= 0 && minElementIndex < arr.Length, "The minElementIndex index must within the bounds of the array.");
        return minElementIndex;
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(arr != null, "The input array must not be null");
        Debug.Assert(value != null, "The searched value not be null");
        Debug.Assert(startIndex >= 0 && startIndex < arr.Length, "The start index must within the bounds of the array.");
        Debug.Assert(endIndex >= 0 && endIndex < arr.Length, "The end index must within the bounds of the array.");
        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            Debug.Assert((startIndex + ((endIndex - startIndex) / 2)) == midIndex, "Incorect mid index calculation");
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }

            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }
}

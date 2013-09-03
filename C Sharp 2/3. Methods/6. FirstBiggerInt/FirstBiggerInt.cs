/* Problem 6. Write a method that returns the index of the first element in array that is bigger than its neighbors, or -1, if there’s no such element.
*/
using System;


class FirstBiggerInt
{
    static int FirstBiggerElement(int[] array)
    {
        BiggerInt compare = new BiggerInt();  // in order to use the class and the method defined in the previous program we add a refference in the properties of this program and then declare and assign object from this class
        for (int i = 0; i < array.Length; i++)
        {
            if (compare.BiggerThanNeighbors(array, i))
            {
                return i;
            }
        }
        return -1;
    }

    static void Main()
    {
        int[] arr = { 3, 1, 2, 5, 7, 4, 1, -4, 6, 7, 4, 2, 1, 6, 4, 2, 9, 10, 6, 5, 1 };
        Console.WriteLine("The first element bigger than it's neighbours is at index: {0} (-1 if no such element exists)", FirstBiggerElement(arr));

    }
}

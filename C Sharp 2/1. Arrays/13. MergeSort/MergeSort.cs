/* Problem 13. * Write a program that sorts an array of integers using the merge sort algorithm (find it in Wikipedia).
 */

using System;
using MyIO;
using System.Collections.Generic; //using methods defined in another project within the solution.

class MergeSort
{
    static void Main()
    {
        int N;

        MyIOClass.Input(out N, "Enter N:");

        int[] arr = new int[N];
        for (int i = 0; i < N; i++)
        {
            Console.Write("Array[{0}]=", i);
            arr[i] = int.Parse(Console.ReadLine());
        }

        int[] sortArr = MergeSortImplementation(arr);

        foreach (var item in sortArr)
        {
            Console.Write(item+" ");
        }
    }

    static int[] MergeSortImplementation(int[] array)
    {
        if (array.Length <= 1) return array;
        int middle = array.Length / 2;
        int[] left = new int[middle];
        int[] right = new int[array.Length - middle];
        for (int i = 0; i < middle; ++i)
        {
            left[i] = array[i];
        }
        for (int i = middle, j = 0; i <= array.Length - 1; ++i, ++j)
        {
            right[j] = array[i];
        }
        left = MergeSortImplementation(left);
        right = MergeSortImplementation(right);
        return merge(left, right);
    }
    static int[] merge(int[] left, int[] right)
    {
        List<int> leftList = new List<int>(left);
        List<int> rightList = new List<int>(right);
        List<int> result = new List<int>();

        while (leftList.Count > 0 || rightList.Count > 0)
        {
            if (leftList.Count > 0 && rightList.Count > 0)
            {
                if (leftList[0] <= rightList[0])
                {
                    result.Add(leftList[0]);
                    leftList.RemoveAt(0);
                }
                else
                {
                    result.Add(rightList[0]);
                    rightList.RemoveAt(0);
                }
            }
            else if (leftList.Count > 0)
            {
                result.Add(leftList[0]);
                leftList.RemoveAt(0);
            }
            else if (rightList.Count > 0)
            {
                result.Add(rightList[0]);
                rightList.RemoveAt(0);
            }
        }

        return result.ToArray();
    }
}


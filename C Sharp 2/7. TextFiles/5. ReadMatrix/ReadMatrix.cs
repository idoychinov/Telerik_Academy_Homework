/* Problem 5. Write a program that reads a text file containing a square matrix of numbers and finds in the matrix an area of size 2 x 2 with a maximal sum of its elements. The first line in the input    * file contains the size of matrix N. Each of the next N lines contain N numbers separated by space. The output should be a single number in a separate text file. Example:
 * 4
 * 2 3 3 4
 * 0 2 3 4			17
 * 3 7 1 2
 * 4 3 3 2
 */
using System;
using System.IO;


class ReadMatrix
{
    static void Main()
    {
        StreamReader reader = null;
        try
        {
            reader = new StreamReader(@"..\..\file1.txt"); // file in the project folder
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: {0}", e.Message);
            return;
        }
        string line;
        int N;
        int[,] arr;
        using (reader)
        {
            N = int.Parse(reader.ReadLine());
            arr = new int[N,N];
            int[] temp = new int[N];
            for (int i = 0; i < N; i++)
			{
			    line = reader.ReadLine();
                temp = SeparateNumbers(line,N);
                for (int j = 0; j < N; j++)
                {
                    arr[i, j] = temp[j];
                }
			}
        }

        int sum = FindArea(arr,N);

        Console.WriteLine("The maximum sum of 2x2 area in the matrix is:  {0}", sum);
        Console.WriteLine("Writing to file...");
        try
        {
            StreamWriter writer = new StreamWriter(@"..\..\file2.txt");
            using (writer)
            {
                writer.WriteLine(sum);
                Console.WriteLine("Writing to file successful!");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: {0}", e.Message);
            return;
        }

    }

    static int[] SeparateNumbers(string s, int n)
    {
        int[] numbers = new int[n];
        string[] substrings = s.Split(' ');
        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(substrings[i]);
        }
        return numbers;
    }

    static int FindArea(int[,] array, int n)
    {
        int sum = int.MinValue;
        int maxSum = int.MinValue;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - 1; j++)
            {
                sum = array[i, j] + array[i, j + 1] + array[i + 1, j] + array[i + 1, j + 1];

                if (sum > maxSum)
                {
                    maxSum = sum;
                }
            }
        }
        return maxSum;
    }
}

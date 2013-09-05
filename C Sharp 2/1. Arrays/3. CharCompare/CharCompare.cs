/* Problem 3. Write a program that compares two char arrays lexicographically (letter by letter).
 */

using System;
using MyIO; //using methods defined in another project within the solution.

class CharCompare
{
    static bool ArrCompare(char[] arr1, char[] arr2)
    {
        if (arr1.Length != arr2.Length)
        {
            return false;
        }
        else
        {
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
    static void Main()
    {
        byte N, M;
        char[] cArray1,cArray2;
        MyIOClass.Input(out N, "Enter Array 1 lenght=");
        MyIOClass.Input(out M, "Enter Array 2 lenght=");
      
        cArray1 = new char[N];
        cArray2 = new char[M];

        for (int i = 0; i < N; i++)
        {
            Console.Write("Array1[{0}]=",i);
            cArray1[i] = char.Parse(Console.ReadLine());
        }

        for (int i = 0; i < M; i++)
        {
            Console.Write("Array2[{0}]=", i);
            cArray2[i] = char.Parse(Console.ReadLine()); ;
        }

        if (ArrCompare(cArray1, cArray2))
        {
            Console.WriteLine("The arrays are lexicographically equal.");
        }
        else
        {
            Console.WriteLine("The arrays are not lexicographically equal.");
        }
    }
}


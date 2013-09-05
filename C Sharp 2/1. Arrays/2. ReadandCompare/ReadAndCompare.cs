/* Problem 2. Write a program that reads two arrays from the console and compares them element by element.
 */
using System;
using MyIO; //using methods defined in another project within the solution.

    class ReadAndCompare
    {
        static void Main()
        {
            byte N,temp;
            MyIOClass.Input(out N, "Enter the lenght of the arrays:");
            string[] compare = {"not equal","equal"};
            int[] arr1 = new int[N],arr2 = new int[N];

            for (int i = 0; i < N; i++)
            {
                MyIOClass.Input(out arr1[i], "arr1[" + i + "]=");
                MyIOClass.Input(out arr2[i], "arr2[" + i + "]=");

                if(arr1[i]==arr2[i])
                {
                    temp=1;
                }
                else
                {
                    temp=0;
                }
                Console.WriteLine("The elements {0} of the two arrays are {1}",i,compare[temp]);
                Console.WriteLine();
            }


        }
    }


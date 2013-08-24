/* Problem 9. We are given 5 integer numbers. Write a program that checks if the sum of some subset of them is 0. Example: 3, -2, 1, 1, 8  1+1-2=0.
 */

using System;
using MyIO;


class SumOfSubset
{
    static void Main()
    {
        int first, second, third, fourth, fifth,sum=0;
        string subsetMask="01101"; // defines the subset to be ceched in the form of a mask. Starting from left to right (the left most symbol beeing the first number and the rightmost the last)
                                   // 0 indicates the number is not the subset and 1 that the number is in the subset. For example "10011" means the first, fourth and fifth numbers are in the subset.
        MyIOClass.Input(out first, "Please enter the first variable: ");
        MyIOClass.Input(out second, "Please enter the second variable: ");
        MyIOClass.Input(out third, "Please enter the third variable: ");
        MyIOClass.Input(out fourth, "Please enter the fourth variable: ");
        MyIOClass.Input(out fifth, "Please enter the fifth variable: ");

        if(subsetMask[0]=='1')
        {
            sum+=first;
        }
        if (subsetMask[1] == '1')
        {
            sum += second;
        }
        if (subsetMask[2] == '1')
        {
            sum += third;
        }
        if (subsetMask[3] == '1')
        {
            sum += fourth;
        }
        if (subsetMask[4] == '1')
        {
            sum += fifth;
        }

        if (sum == 0)
        {
            Console.WriteLine("The sum of the numbers in this subset {0} is 0!", subsetMask);
        }
        else
        {
            Console.WriteLine("The sum of the numbers in this subset {0} is NOT 0!", subsetMask);
        }
    }

}
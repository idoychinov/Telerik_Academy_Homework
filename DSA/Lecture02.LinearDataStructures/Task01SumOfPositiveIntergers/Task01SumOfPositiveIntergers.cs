namespace Task01.SumOfPositiveIntergers
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Write a program that reads from the console a sequence of positive integer numbers. The sequence ends when empty line is entered. 
    /// Calculate and print the sum and average of the elements of the sequence. Keep the sequence in List<int>.
    /// </summary>
    public class Task01SumOfPositiveIntergers
    {
        public static void Main()
        {
            List<int> sequence = new List<int>();
            string line;
            int current,
                sum;

            Console.WriteLine("Enter sequence of integers each on new line. End the sequence with empty line");

            line = Console.ReadLine();
            sum = 0;
            while (line != string.Empty)
            {
                current = int.Parse(line);
                sum += current;
                sequence.Add(current);
                line = Console.ReadLine();
            }

            Console.WriteLine("The sequence sum is {0} and the sequence average is {1}", sum, sum / sequence.Count);
        }
    }
}

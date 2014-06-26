namespace Task01.SumOfPositiveIntergers
{
    using System;
    using System.Collections.Generic;

    class Task01SumOfPositiveIntergers
    {
        static void Main()
        {
            List<int> sequence = new List<int>();
            string line;
            int current,
                sum;

            Console.WriteLine("Enter sequence of integers each on new line. End the sequence with empty line");

            line = Console.ReadLine();
            sum = 0;
            while (line != String.Empty)
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

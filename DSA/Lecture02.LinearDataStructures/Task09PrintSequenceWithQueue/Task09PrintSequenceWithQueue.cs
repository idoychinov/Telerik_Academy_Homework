namespace Task09PrintSequenceWithQueue
{
    using System;
    using System.Collections.Generic;
    using Utilities;

    /// <summary>
    /// We are given the following sequence:
    /// S1 = N;
    /// S2 = S1 + 1;
    /// S3 = 2*S1 + 1;
    /// S4 = S1 + 2;
    /// S5 = S2 + 1;
    /// S6 = 2*S2 + 1;
    /// S7 = S2 + 2;
    /// ...
    /// Using the Queue<T> class write a program to print its first 50 members for given N.
    /// Example: N=2  2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...
    /// </summary>
    public class Task09PrintSequenceWithQueue
    {
        public static void Main()
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());

            Queue<long> queue = new Queue<long>();
            List<long> output = new List<long>();
            output.Add(n);

            long current = n;

            while (output.Count < 50)
            {
                queue.Enqueue(current + 1);
                queue.Enqueue((2 * current) + 1);
                queue.Enqueue(current + 2);
                current = queue.Peek();
                output.Add(queue.Dequeue());
            }

            Console.WriteLine(Utilities.ListToString(output));
        }
    }
}

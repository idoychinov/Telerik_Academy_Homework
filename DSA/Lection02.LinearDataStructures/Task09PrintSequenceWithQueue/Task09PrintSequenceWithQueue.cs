namespace Task09PrintSequenceWithQueue
{
    using System;
    using System.Collections.Generic;
    using Utilities;

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

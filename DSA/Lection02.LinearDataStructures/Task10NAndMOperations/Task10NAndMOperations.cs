namespace Task10NAndMOperations
{
    using System;
    using System.Collections.Generic;

    // Unfinished
    class Task10NAndMOperations
    {
        static void Main()
        {
            int N;
            int M;

            Console.WriteLine("Enter N and M such as N<M");
            do
            {
                Console.Write("Enter N: ");
                N = int.Parse(Console.ReadLine());
                Console.Write("Enter M: ");
                M = int.Parse(Console.ReadLine());
            } while (N >= M);

            Queue<long> queue = new Queue<long>();
            long current;
            queue.Enqueue(N);

            do
            {
                current = queue.Dequeue();
                Console.WriteLine(current);
                if (current * 2 <= M)
                {
                    queue.Enqueue(2 * current);
                }
                if (current + 2 <= M)
                {
                    queue.Enqueue(current + 2);
                }
                if (current + 1 <= M)
                {
                    queue.Enqueue(current + 1);
                }
            } while (current != M);

            

        }
    }
}

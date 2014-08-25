namespace Task13Queue
{
    using System;

    /// <summary>
    /// Implement the ADT queue as dynamic linked list. Use generics (LinkedQueue<T>) to allow storing different data types in the queue.
    /// </summary>
    public class Task13Queue
    {
        public static void Main()
        {
            const int Iterations = 5;
            LinkedQueue<int> queue = new LinkedQueue<int>();

            Console.WriteLine("Put in Queue\n");
            for (int i = 0; i < Iterations; i++)
            {
                Console.WriteLine("Enqueue {0}", i);
                queue.Enqueue(i);
            }

            Console.WriteLine("\n\nGet from Queue\n");
            for (int i = 0; i < Iterations; i++)
            {
                Console.Write("Peek {0}  ", queue.Peek());
                Console.WriteLine("Dequeue {0}", queue.Dequeue());
            }
        }
    }
}

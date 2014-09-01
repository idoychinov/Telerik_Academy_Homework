namespace Task1PriorityQueue
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Task 1. Implement a class PriorityQueue<T> based on the data structure "binary heap".
    /// </summary>
    public class Task1PriorityQueue
    {
        private const int InputDataSize = 100;
        private const int MinNumber = 1;
        private const int MaxNumber = 100;
        private static Random randomGenerator = new Random();
        
        public static void Main()
        {
            PriorityQueue<int> minQueue = new PriorityQueue<int>(new ComparerAsc());
            Console.WriteLine("Min priority queue");
            TestQueue(minQueue);

            PriorityQueue<int> maxQueue = new PriorityQueue<int>();
            Console.WriteLine("\n\nMax priority queue");
            TestQueue(maxQueue);
        }

        private static void TestQueue(PriorityQueue<int> queue)
        {
            Console.WriteLine("The elements in the order they were generated and added to the queue");
            for (int i = 0; i < InputDataSize; i++)
            {
                var current = randomGenerator.Next(MinNumber, MaxNumber + 1);
                Console.Write("{0}, ", current);
                queue.Enqueue(current);
            }

            Console.WriteLine("\n\nThe elements in the order they were dequeued");
            while (queue.Count > 0)
            {
                Console.Write("{0}, ", queue.Dequeue());
            }
        }
        
        public class ComparerAsc : Comparer<int>
        {
            public override int Compare(int x, int y)
            {
                return y.CompareTo(x);
            }
        }
    }
}

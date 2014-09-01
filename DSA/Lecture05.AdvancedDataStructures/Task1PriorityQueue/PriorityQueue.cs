namespace Task1PriorityQueue
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private BinaryHeap<T> queue;

        public PriorityQueue()
            : this(null)
        {
        }

        public PriorityQueue(Comparer<T> comparer)
        {
            this.queue = new BinaryHeap<T>(comparer);
        }
        
        public int Count
        {
            get
            {
                return this.queue.Count;
            }
        }

        public void Enqueue(T item)
        {
            this.queue.Add(item);
        }

        public T Peek()
        {
            return this.queue.Peek();
        }

        public T Dequeue()
        {
            return this.queue.RemoveTop();
        }

        public void Clear()
        {
            this.queue.Clear();
        }
    }
}

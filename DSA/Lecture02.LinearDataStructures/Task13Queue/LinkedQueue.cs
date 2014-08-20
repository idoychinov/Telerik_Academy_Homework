namespace Task13Queue
{
    using System;

    public class LinkedQueue<T>
    {
        private QueueItem<T> head;
        private QueueItem<T> tail;
        private int count;

        public LinkedQueue()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Enqueue(T value)
        {
            if (this.tail == null && this.tail == null)
            {
                this.head = new QueueItem<T>(value);
                this.tail = this.head;
            }
            else
            {
                this.tail.NextItem = new QueueItem<T>(value);
                this.tail = this.tail.NextItem;
            }

            this.count++;
        }

        public T Dequeue()
        {
            this.CheckIfQueueEmpty();
            T item;
            item = this.head.Value;
            this.head = this.head.NextItem;
            if (this.head == null)
            {
                this.tail = null;
            }

            this.count--;

            return item;
        }

        public T Peek()
        {
            this.CheckIfQueueEmpty();
            return this.head.Value;
        }

        private void CheckIfQueueEmpty()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }
        }

        private class QueueItem<T1>
        {
            internal QueueItem(T1 value)
            {
                this.Value = value;
                this.NextItem = null;
            }

            internal T1 Value { get; set; }

            internal QueueItem<T> NextItem { get; set; }
        }
    }
}

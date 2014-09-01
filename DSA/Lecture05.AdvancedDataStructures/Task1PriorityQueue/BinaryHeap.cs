namespace Task1PriorityQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BinaryHeap<T> : ICollection<T> where T : IComparable<T>
    {
        private const int InitialCapacity = 16;
        private readonly Comparer<T> compararer;
        private T[] data;
        private int currentIndex;
        private bool sorted;

        public BinaryHeap()
            : this(null)
        {
        }

        public BinaryHeap(Comparer<T> compararer)
        {
            this.data = new T[InitialCapacity];
            this.currentIndex = 0;
            this.sorted = false;

            if (compararer == null)
            {
                this.compararer = Comparer<T>.Default;
            }
            else
            {
                this.compararer = compararer;
            }
        }

        public int Count
        {
            get
            {
                return this.currentIndex;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public T Peek()
        {
            return this.data[0];
        }

        public void Add(T item)
        {
            if (this.currentIndex == this.data.Length)
            {
                this.Resize();
            }

            this.data[this.currentIndex] = item;
            this.HeapUp();
            this.currentIndex++;
        }

        public void Clear()
        {
            this.currentIndex = 0;
            this.data = new T[InitialCapacity];
        }

        public bool Contains(T item)
        {
            this.EnsureSort();
            return Array.BinarySearch<T>(this.data, 0, this.currentIndex, item) >= 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.EnsureSort();
            Array.Copy(this.data, arrayIndex, array, 0, this.currentIndex);
        }

        public T RemoveTop()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException("Cannot remove from empty heap");
            }

            T topElement = this.data[0];
            this.currentIndex--;
            this.data[0] = this.data[this.currentIndex];
            this.data[this.currentIndex] = default(T);
            this.HeapDown();
            return topElement;
        }

        public bool Remove(T item)
        {
            this.EnsureSort();
            int i = Array.BinarySearch<T>(this.data, 0, this.currentIndex, item);
            if (i < 0) 
            {
                return false;
            }

            Array.Copy(this.data, i + 1, this.data, i, this.currentIndex - i);
            this.data[this.currentIndex] = default(T);
            this.currentIndex--;
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            this.EnsureSort();
            for (int i = 0; i < this.currentIndex; i++)
            {
                yield return this.data[i];
            }
        }

        private void EnsureSort()
        {
            if (this.sorted) 
            {
                return; 
            }

            Array.Sort(this.data, 0, this.currentIndex);
            this.sorted = true;
        }

        private void HeapUp()
        {
            var currentIndex = this.currentIndex;
            int parentIndex = this.ParentIndex(currentIndex);
            this.sorted = false;

            while (parentIndex >= 0 && this.compararer.Compare(this.data[parentIndex], this.data[currentIndex]) < 0)
            {
                T parent = this.data[parentIndex];
                this.data[parentIndex] = this.data[currentIndex];
                this.data[currentIndex] = parent;

                currentIndex = parentIndex;
                parentIndex = this.ParentIndex(currentIndex);
            }
        }

        private void HeapDown()
        {
            int parentIndex = 0;
            int currentChildIndex = 0;
            this.sorted = false;

            while (true)
            {
                int leftChildIndex = this.GetLeftChild(parentIndex);
                int rightChildIndex = this.GetRightChild(parentIndex);

                if (leftChildIndex >= this.currentIndex)
                {
                    break;
                }

                if (rightChildIndex >= this.currentIndex)
                {
                    currentChildIndex = leftChildIndex;
                }
                else
                {
                    currentChildIndex = this.compararer.Compare(this.data[leftChildIndex], this.data[rightChildIndex]) < 0 ? rightChildIndex : leftChildIndex;
                }

                if (this.compararer.Compare(this.data[parentIndex], this.data[currentChildIndex]) < 0)
                {
                    T parent = this.data[parentIndex];
                    this.data[parentIndex] = this.data[currentChildIndex];
                    this.data[currentChildIndex] = parent;

                    parentIndex = currentChildIndex;
                }
                else
                {
                    break;
                }
            }
        }

        private int ParentIndex(int index)
        {
            return (index - 1) >> 1;
        }

        private int GetLeftChild(int index)
        {
            return (index << 1) + 1;
        }

        private int GetRightChild(int index)
        {
            return (index << 1) + 2;
        }

        private void Resize()
        {
            var newData = new T[this.data.Length * 2];
            Array.Copy(this.data, newData, this.data.Length);
            this.data = newData;
        }
    }
}

using System;
using System.Collections.Generic;

namespace Homework
{
    // Problem 5. Write a generic class GenericList<T> that keeps a list of elements of some parametric type T.
    // Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor. 
    // Implement methods for adding element, accessing element by index, removing element by index, inserting element at given position, 
    // clearing the list, finding element by its value and ToString(). Check all input parameters to avoid accessing elements at invalid positions.


    class GenericList<T>
        where T: IComparable
    {
        private T[] list;
        private int count;
        private int capacity;

        public GenericList(int initialElementsCount)
        {
            if(initialElementsCount<0)
            {
                throw new ArgumentException("Elements in the list must be 0 or more.");
            }
            list = new T[initialElementsCount];
            count = 0;
            capacity = initialElementsCount;
        }

        public GenericList()
            : this(0)
        {
        }

        public void Add(T element)
        {
            if (CheckIfListIsFull())
            {
                AutoGrow();
            }

            this.list[count] = element;
            this.count++;
            List<int> a =new List<int>();
        }

        public T this[int key]
        {
            get
            {
                if(key<0||key>=this.count)
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }
                return this.list[key];
            }
            set
            {
                if (key < 0 || key >= count)
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }
                this.list[key] = value;
            }
        }

        public void RemoveElementByIndex(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            for (int i = index; i < count-1; i++)
            {
                this.list[i] = this.list[i + 1];
            }        
            this.count--;
        }

        public void InsertElementAtPosition(int position, T element)
        {
            if (position < 0 || position >= this.count)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            if (CheckIfListIsFull())
            {
                AutoGrow();
            }

            for (int i = count; i > position; i--)
            {
                this.list[i] = this.list[i - 1];
            }

            this.list[position] = element;
            this.count++;
        }

        public void ClearList()
        {
            this();
        }

        //TODO: Find element by value
        //TODO: ToString()


        // Problem 6. Implement auto-grow functionality: when the internal array is full, create a new array of double size and move all elements to it.

        private void AutoGrow()
        {
            if (this.capacity != 0)
            {
                long newCapacity = 2 * this.capacity;
                if (newCapacity > (long)int.MaxValue)
                {
                    throw new OutOfMemoryException("Max capacity reached");
                }
                this.capacity = (int)newCapacity;
                T[] copylist = new T[count];
                for (int i = 0; i < count; i++)
                {
                    copylist[i] = this.list[i];
                }

                this.list = new T[this.capacity];

                for (int i = 0; i < count; i++)
                {
                    this.list[i] = copylist[i];
                }
            }
            else
            {
                this.capacity = 1;
            }
        }

        private bool CheckIfListIsFull()
        {
            if (this.count == this.capacity)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Problem 7. Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element in the  GenericList<T>. 
        // You may need to add a generic constraints for the type T.

        public T Min<T>()
        {
            //TODO validations
            T min = (T)this.list[0];

            for (int i = 1; i < count; i++)
            {
                if (this.list[i].CompareTo(min) < 0)
                {
                    min = (T)this.list[i];
                }
            }

            return min;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    // Problem 5. Write a generic class GenericList<T> that keeps a list of elements of some parametric type T.
    // Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor. 
    // Implement methods for adding element, accessing element by index, removing element by index, inserting element at given position, 
    // clearing the list, finding element by its value and ToString(). Check all input parameters to avoid accessing elements at invalid positions.


    public class GenericList<T>
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

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
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
        }

        public T this[int key]
        {
            get
            {
                if(key<0 || key>=this.count)
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
            this.list= new T[0];
            this.count = 0;
            this.capacity = 0;
        }
        
        public int FindElementByValue(T value)
        {
            int foundIndex = -1;
            int currentIndex=0;
            foreach (var element in this.list)
            {
                if (value.CompareTo(element)==0)
                {
                    foundIndex = currentIndex;
                    break;
                }
                currentIndex++;
            }

            return foundIndex;
        }
        
        public override string ToString()
        {
            if (this.list == null)
            {
                throw new NullReferenceException("Object is not initialized");
            }
            if (this.list.Length == 0)
            {
                return string.Empty;
            }

            StringBuilder stringRepresentation = new StringBuilder();
            stringRepresentation.Append("{ ");
            foreach (var element in this.list)
            {
                stringRepresentation.Append(element);
                stringRepresentation.Append(" ");
            }
            stringRepresentation.Append("}");
            return stringRepresentation.ToString();
        }

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
                this.list = new T[this.capacity];
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

        public T Min()
        {
            if (this.list == null)
            {
                throw new NullReferenceException("Object is not initialized");
            }
            if (this.list.Length == 0)
            {
                throw new InvalidOperationException("Empty list");
            }

            var min = this.list[0];

            for (int i = 1; i < count; i++)
            {
                if (this.list[i].CompareTo(min) < 0)
                {
                    min = this.list[i];
                }
            }

            return (T) Convert.ChangeType(min,typeof(T));
        }


        public T Max()
        {
            if (this.list == null)
            {
                throw new NullReferenceException("Object is not initialized");
            }
            if (this.list.Length == 0)
            {
                throw new InvalidOperationException("Empty list");
            }

            var max = this.list[0];

            for (int i = 1; i < count; i++)
            {
                if (this.list[i].CompareTo(max) > 0)
                {
                    max = this.list[i];
                }
            }

            return (T)Convert.ChangeType(max, typeof(T));
        }

    }
}

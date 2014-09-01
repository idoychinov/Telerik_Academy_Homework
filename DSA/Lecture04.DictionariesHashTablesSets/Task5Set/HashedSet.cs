namespace Task5Set
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using Task4HashTable;

    public class HashedSet<T> : IEnumerable<T>
    {
        private HashTable<T, T> hashTable;

        public HashedSet()
        {
            this.hashTable = new HashTable<T, T>();
        }

        public int Count
        {
            get { return this.hashTable.Count; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.hashTable)
            {
                yield return item.Key;
            }
        }

        public void Add(T value)
        {
            this.hashTable.Add(value, value);
        }

        public bool Find(T value)
        {
            try
            {
                this.hashTable.Find(value);
                return true;
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }

        public bool Remove(T value)
        {
            try
            {
                this.hashTable.Remove(value);
                return true;
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }

        public void Clear()
        {
            this.hashTable.Clear();
        }

        public void Intersect(IEnumerable<T> set)
        {
            var newHashTable = new HashTable<T, T>();
            foreach (var item in set)
            {
                if (this.Find(item))
                {
                    newHashTable.Add(item, item);
                }
            }

            this.hashTable = newHashTable;
        }

        public void Union(IEnumerable<T> set)
        {
            foreach (var item in set)
            {
                this.Add(item);
            }
        }

        public override string ToString()
        {
            StringBuilder outputString = new StringBuilder();
            outputString.Append("{ ");
            foreach (var item in this.hashTable)
            {
                outputString.Append(item.Key);
                outputString.Append(", ");
            }

            if (this.hashTable.Count > 0)
            {
                outputString.Remove(outputString.Length - 2, 2);
                outputString.Append(" }");
            }
            else
            {
                outputString.Append("}");
            }

            return outputString.ToString();
        }
    }
}

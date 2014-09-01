namespace Task4HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<K, T> : IEnumerable<KeyValuePair<K, T>>
    {
        private const int InitialSize = 16;
        private LinkedList<KeyValuePair<K, T>>[] hashTable;
        private int count;

        public HashTable()
        {
            this.hashTable = new LinkedList<KeyValuePair<K, T>>[InitialSize];
            this.count = 0;
        }
        
        public int Count
        {
            get { return this.count; }
        }

        public T this[K key]
        {
            get
            {
                return this.Find(key);
            }

            set
            {
                this.Add(key, value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)this.GetEnumerator();
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            for (int i = 0; i < this.hashTable.Length; i++)
            {
                if (this.hashTable[i] != null)
                {
                    foreach (var item in this.hashTable[i])
                    {
                        yield return item;
                    }
                }
            }
        }

        public IEnumerable<K> Keys()
        {
            return this.Select(x => x.Key);
        }

        public T Find(K key)
        {
            var hash = this.GetHash(key, this.hashTable.Length);
            if (this.hashTable[hash] == null)
            {
                throw new KeyNotFoundException("Specified key not found");
            }

            foreach (var item in this.hashTable[hash])
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }

            throw new KeyNotFoundException("Specified key not found");
        }

        public T Remove(K key)
        {
            var hash = this.GetHash(key, this.hashTable.Length);
            if (this.hashTable[hash] == null)
            {
                throw new KeyNotFoundException("Specified key not found");
            }

            foreach (var item in this.hashTable[hash])
            {
                if (item.Key.Equals(key))
                {
                    var value = item.Value;
                    this.hashTable[hash].Remove(item);
                    this.count--;
                    if (this.hashTable[hash].Count == 0)
                    {
                        this.hashTable[hash] = null;
                    }

                    return value;
                }
            }

            throw new KeyNotFoundException("Specified key not found");
        }

        public void Add(K key, T value)
        {
            var pair = new KeyValuePair<K, T>(key, value);
            this.AddToTable(pair, this.hashTable);
            this.count++;
            this.CheckIfFillOver75Percent();
        }

        public void Clear()
        {
            this.hashTable = new LinkedList<KeyValuePair<K, T>>[InitialSize];
            this.count = 0;
        }
        
        private bool ElementIsInList(K key, LinkedList<KeyValuePair<K, T>> list)
        {
            if (list == null)
            {
                throw new InvalidOperationException("List of values with equal hash codes is not initialized.");
            }

            foreach (var item in list)
            {
                if (item.Key.Equals(key))
                {
                    return true;
                }
            }

            return false;
        }

        private void Resize()
        {
            var currentSize = this.hashTable.Length;
            var newHashTable = new LinkedList<KeyValuePair<K, T>>[currentSize * 2];
            foreach (var item in this)
            {
                this.AddToTable(item, newHashTable);
            }

            this.hashTable = newHashTable;
        }

        private void CheckIfFillOver75Percent()
        {
            if ((decimal)this.count > ((decimal)this.hashTable.Length * 0.75m))
            {
                this.Resize();
            }
        }

        private void AddToTable(KeyValuePair<K, T> pair, LinkedList<KeyValuePair<K, T>>[] table)
        {
            var hash = this.GetHash(pair.Key, table.Length);
            if (table[hash] == null)
            {
                table[hash] = new LinkedList<KeyValuePair<K, T>>();
                table[hash].AddFirst(pair);
            }
            else
            {
                if (!this.ElementIsInList(pair.Key, table[hash]))
                {
                    table[hash].AddLast(pair);
                }
            }
        }

        private int GetHash(K key, int totalLenght)
        {
            var baseHashCode = Math.Abs(key.GetHashCode());
            var calculatedHahsCode = baseHashCode % totalLenght;
            return calculatedHahsCode;
        }
    }
}

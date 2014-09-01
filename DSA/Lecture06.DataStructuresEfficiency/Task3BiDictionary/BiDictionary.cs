namespace Task3BigDictionary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class BiDictionary<K1, K2, T>
    {
        private MultiDictionary<K1, T> firstKey;

        private MultiDictionary<K2, T> secondKey;

        public BiDictionary()
        {
            this.firstKey = new MultiDictionary<K1, T>(true);
            this.secondKey = new MultiDictionary<K2, T>(true);
        }

        public void Add(K1 key1, K2 key2, T value)
        {
            this.firstKey.Add(key1, value);
            this.secondKey.Add(key2, value);
        }

        public ICollection<T> Search(K1 key1)
        {
            return this.firstKey[key1];
        }

        public ICollection<T> Search(K2 key2)
        {
            return this.secondKey[key2];
        }

        public IEnumerable<T> Search(K1 key1, K2 key2)
        {
            var col1 = this.firstKey[key1];
            var col2 = this.secondKey[key2];
            return col1.Intersect<T>(col2);
        }
    }
}

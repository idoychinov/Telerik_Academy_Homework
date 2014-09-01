namespace Task4HashTable
{
    using System;

    public class Task4HashTable
    {
        /// <summary>
        /// Task 4. Implement the data structure "hash table" in a class HashTable<K,T>. Keep the data in array of lists of key-value pairs (LinkedList<KeyValuePair<K,T>>[]) 
        /// with initial capacity of 16. When the hash table load runs over 75%, perform resizing to 2 times larger capacity. Implement the following methods and properties: 
        /// Add(key, value), Find(key)value, Remove( key), Count, Clear(), this[], Keys. Try to make the hash table to support iterating over its elements with foreach.
        /// </summary>
        public static void Main()
        {
            var hashtable = new HashTable<int, string>();
            hashtable.Add(5, "five");
            hashtable.Add(3, "tree");
            hashtable.Add(-6, "minus six");
            Console.WriteLine(hashtable.Find(-6));
            Console.WriteLine("All elements");
            foreach (var item in hashtable)
            {
                Console.WriteLine("Key: {0} => Value: {1}", item.Key, item.Value);
            }

            hashtable.Remove(3);
            Console.WriteLine("3 removed from table");
            try
            {
                Console.WriteLine("Searching for 3 in table");
                hashtable.Find(3);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Hash table has {0} elements", hashtable.Count);
        }
    }
}

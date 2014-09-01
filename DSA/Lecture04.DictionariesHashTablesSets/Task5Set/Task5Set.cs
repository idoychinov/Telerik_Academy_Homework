namespace Task5Set
{
    using System;

    public class Task5Set
    {
        /// <summary>
        /// Task 5. Implement the data structure "set" in a class HashedSet<T> using your class HashTable<K,T> to hold the elements.
        /// Implement all standard set operations like Add(T), Find(T), Remove(T), Count, Clear(), union and intersect.
        /// </summary>
        public static void Main()
        {
            var set = new HashedSet<int>();

            set.Add(5);
            set.Add(3);
            set.Add(-4);
            set.Add(12);
            set.Add(0);
            set.Add(-50);
            set.Add(10);
            Console.WriteLine("Set contains 12 -> {0}", set.Find(12));
            Console.WriteLine("Set contains 13 -> {0}", set.Find(13));
            set.Remove(10);
            Console.WriteLine("Removed 10\nSet contains 10 -> {0}", set.Find(10));
            Console.WriteLine("Set contains {0} items", set.Count);
            Console.WriteLine("Set 1: {0}", set);

            var anotherSet = new HashedSet<int>();
            anotherSet.Add(-4);
            anotherSet.Add(15);
            anotherSet.Add(0);
            anotherSet.Add(-122);
            anotherSet.Add(35);
            Console.WriteLine("Set 2: {0}", anotherSet);

            set.Union(anotherSet);
            Console.WriteLine("Set after union: {0}", set);

            set.Intersect(anotherSet);
            Console.WriteLine("Set after intersect: {0}", set);

            set.Clear();
            Console.WriteLine("Set contains {0} items after clear", set.Count);
        }
    }
}

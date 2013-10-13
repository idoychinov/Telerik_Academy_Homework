using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

// Problem  2. Implement a set of extension methods for IEnumerable<T> that implement the following group functions: sum, product, min, max, average.

namespace P02.IEnumerableExtensions
{
    public static class IEnumerableExtensions
    {
        private static void CheckColectionPreconditions<T>(IEnumerable<T> collection) 
        {
            if (collection == null)
            {
                throw new NullReferenceException("Collection is null");
            }
            if (collection.Count<T>() == 0)
            {
                throw new NullReferenceException("Collection is empty");
            }
        }

        public static decimal Sum<T>(this IEnumerable<T> collection) where T: IConvertible
        {
            CheckColectionPreconditions(collection);
            decimal sum =0M;
            foreach (var item in collection)
            {
                sum += item.ToDecimal(new NumberFormatInfo());
            }
            
            return sum;
        }

        public static decimal Product<T>(this IEnumerable<T> collection) where T : IConvertible
        {
            CheckColectionPreconditions(collection);
            decimal product = 1M;
            foreach (var item in collection)
            {
                product *= item.ToDecimal(new NumberFormatInfo());
            }

            return product;
        }

        public static T Min<T>(this IEnumerable<T> collection) where T : IComparable
        {
            CheckColectionPreconditions(collection);
            T min = collection.First<T>();
            foreach (var item in collection)
            {
                if (item.CompareTo(min) < 0)
                {
                    min = item;
                }
            }

            return min;
        }

        public static T Max<T>(this IEnumerable<T> collection) where T : IComparable
        {
            CheckColectionPreconditions(collection);
            T max = collection.First<T>();
            foreach (var item in collection)
            {
                if (item.CompareTo(max) > 0)
                {
                    max = item;
                }
            }

            return max;
        }

        public static decimal Average<T>(this IEnumerable<T> collection) where T : IConvertible
        {
            CheckColectionPreconditions(collection);
            decimal sum = 0M;
            int count = 0;
            foreach (var item in collection)
            {
                sum = sum + item.ToDecimal(new NumberFormatInfo());
                count++;
            }
            
            return sum/(decimal)count;
        }

        static void Main()
        {
            List<int> l = new List<int>();
            l.Add(4);
            l.Add(56);
            l.Add(-45);
            l.Add(34);

            Console.WriteLine("Sum = {0}",l.Sum<int>());
            Console.WriteLine("Product = {0}",l.Product<int>());
            Console.WriteLine("Min = {0}",l.Min<int>());
            Console.WriteLine("Max = {0}",l.Max<int>());
            Console.WriteLine("Avarage = {0}",l.Average<int>());
        }                     
    }
}

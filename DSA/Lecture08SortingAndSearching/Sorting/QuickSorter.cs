namespace Sorting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class QuickSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            var arr = collection.ToArray();
            QuickSort(arr, 0, collection.Count - 1);
            for (int i = 0; i < collection.Count; i++)
                collection[i] = arr[i];
        }

        private void QuickSort(T[] numbers, int start, int end)
        {
            if (start < end)
            {
                T pivot = numbers[end];
                int pIndex = start;
                for (int i = start; i < end; i++)
                {
                    if (numbers[i].CompareTo(pivot) <= 0)
                    {
                        T temp = numbers[i];
                        numbers[i] = numbers[pIndex];
                        numbers[pIndex] = temp;

                        pIndex++;
                    }
                }

                numbers[end] = numbers[pIndex];
                numbers[pIndex] = pivot;

                QuickSort(numbers, start, pIndex - 1);
                QuickSort(numbers, pIndex + 1, end);
            }
        }
    }
}

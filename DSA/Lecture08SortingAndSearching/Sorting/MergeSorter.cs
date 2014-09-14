namespace Sorting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Collection cannot be null!");
            }

            var arr = collection.ToArray();
            MergeSort(arr, new T[collection.Count], 0, collection.Count - 1);
            for (int i = 0; i < collection.Count; i++)
                collection[i] = arr[i];
        }

        private void MergeSort(T[] arr, T[] temp, int left, int right)
        {
            if (right <= left) return;

            int mid = (right + left) / 2;
            MergeSort(arr, temp, left, mid);
            MergeSort(arr, temp, mid + 1, right);

            int i, j;
            for (i = mid + 1; i > left; i--)
                temp[i - 1] = arr[i - 1];
            for (j = mid; j < right; j++)
                temp[right + mid - j] = arr[j + 1];
            for (int k = left; k <= right; k++)
                arr[k] = (temp[i].CompareTo(temp[j]) < 0) ? temp[i++] : temp[j--];
        }
    }
}

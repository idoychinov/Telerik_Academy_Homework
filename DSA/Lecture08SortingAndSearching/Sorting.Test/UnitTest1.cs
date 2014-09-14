using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorting;

[TestClass]
public class SortingTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Test_SelectionNull()
    {
        new SelectionSorter<int>().Sort(null);
    }

    [TestMethod]
    public void Test_Selection0()
    {
        var array = TestHelpers.GenerateIntArray(ArrayOptions.Random, 0);
        var list = array.ToList();

        new SelectionSorter<int>().Sort(list);

        Assert.IsTrue(list.IsSorted());        
        Assert.IsTrue(list.SameContents(array));
    }

    [TestMethod]
    public void Test_Selection1()
    {
        var array = TestHelpers.GenerateIntArray(ArrayOptions.Random, 1);
        var list = array.ToList();

        new SelectionSorter<int>().Sort(list);

        Assert.IsTrue(list.IsSorted());
        Assert.IsTrue(list.SameContents(array));
    }

    [TestMethod]
    public void Test_SelectionRandom1000()
    {
        var array = TestHelpers.GenerateIntArray(ArrayOptions.Random, 1000);
        var list = array.ToList();

        new SelectionSorter<int>().Sort(list);

        Assert.IsTrue(list.IsSorted());
        Assert.IsTrue(list.SameContents(array));
    }

    [TestMethod]
    public void Test_SelectionSorted1000()
    {
        var array = TestHelpers.GenerateIntArray(ArrayOptions.Sorted, 1000);
        var list = array.ToList();

        new SelectionSorter<int>().Sort(list);

        Assert.IsTrue(list.IsSorted());
        Assert.IsTrue(list.SameContents(array));
    }

    [TestMethod]
    public void Test_SelectionReversed1000()
    {
        var array = TestHelpers.GenerateIntArray(ArrayOptions.Reversed, 1000);
        var list = array.ToList();

        new SelectionSorter<int>().Sort(list);

        Assert.IsTrue(list.IsSorted());
        Assert.IsTrue(list.SameContents(array));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Test_QuickNull()
    {
        new QuickSorter<int>().Sort(null);
    }

    [TestMethod]
    public void Test_Quick0()
    {
        var array = TestHelpers.GenerateIntArray(ArrayOptions.Random, 0);
        var list = array.ToList();

        new QuickSorter<int>().Sort(list);

        Assert.IsTrue(list.IsSorted());
        Assert.IsTrue(list.SameContents(array));
    }

    [TestMethod]
    public void Test_Quick1()
    {
        var array = TestHelpers.GenerateIntArray(ArrayOptions.Random, 1);
        var list = array.ToList();

        new QuickSorter<int>().Sort(list);

        Assert.IsTrue(list.IsSorted());
        Assert.IsTrue(list.SameContents(array));
    }

    [TestMethod]
    public void Test_QuickRandom1000()
    {
        var array = TestHelpers.GenerateIntArray(ArrayOptions.Random, 1000);
        var list = array.ToList();

        new QuickSorter<int>().Sort(list);

        Assert.IsTrue(list.IsSorted());
        Assert.IsTrue(list.SameContents(array));
    }

    [TestMethod]
    public void Test_QuickSorted1000()
    {
        var array = TestHelpers.GenerateIntArray(ArrayOptions.Sorted, 1000);
        var list = array.ToList();

        new QuickSorter<int>().Sort(list);

        Assert.IsTrue(list.IsSorted());
        Assert.IsTrue(list.SameContents(array));
    }

    [TestMethod]
    public void Test_QuickReversed1000()
    {
        var array = TestHelpers.GenerateIntArray(ArrayOptions.Reversed, 1000);
        var list = array.ToList();

        new QuickSorter<int>().Sort(list);

        Assert.IsTrue(list.IsSorted());
        Assert.IsTrue(list.SameContents(array));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Test_MergeNull()
    {
        new MergeSorter<int>().Sort(null);
    }

    [TestMethod]
    public void Test_Merge0()
    {
        var array = TestHelpers.GenerateIntArray(ArrayOptions.Random, 0);
        var list = array.ToList();

        new MergeSorter<int>().Sort(list);

        Assert.IsTrue(list.IsSorted());
        Assert.IsTrue(list.SameContents(array));
    }

    [TestMethod]
    public void Test_Merge1()
    {
        var array = TestHelpers.GenerateIntArray(ArrayOptions.Random, 1);
        var list = array.ToList();

        new MergeSorter<int>().Sort(list);

        Assert.IsTrue(list.IsSorted());
        Assert.IsTrue(list.SameContents(array));
    }

    [TestMethod]
    public void Test_MergeRandom1000()
    {
        var array = TestHelpers.GenerateIntArray(ArrayOptions.Random, 1000);
        var list = array.ToList();

        new MergeSorter<int>().Sort(list);

        Assert.IsTrue(list.IsSorted());
        Assert.IsTrue(list.SameContents(array));
    }

    [TestMethod]
    public void Test_MergeSorted1000()
    {
        var array = TestHelpers.GenerateIntArray(ArrayOptions.Sorted, 1000);
        var list = array.ToList();

        new MergeSorter<int>().Sort(list);

        Assert.IsTrue(list.IsSorted());
        Assert.IsTrue(list.SameContents(array));
    }

    [TestMethod]
    public void Test_MergeReversed1000()
    {
        var array = TestHelpers.GenerateIntArray(ArrayOptions.Reversed, 1000);
        var list = array.ToList();

        new MergeSorter<int>().Sort(list);

        Assert.IsTrue(list.IsSorted());
        Assert.IsTrue(list.SameContents(array));
    }
}

internal enum ArrayOptions 
{
    Random,
    Sorted,
    Reversed
}

internal static class TestHelpers
{
    private static readonly Random Rand = new Random();

    public static bool IsSorted<T>(this IEnumerable<T> seq)
    {
        return seq.OrderBy(x => x, Comparer<T>.Default)
                  .SequenceEqual(seq);
    }

    public static bool SameContents<T>(this IEnumerable<T> seq1, IEnumerable<T> seq2)
    {
        return seq1.OrderBy(x => x, Comparer<T>.Default).SequenceEqual(
               seq2.OrderBy(x => x, Comparer<T>.Default));
    }

    public static int[] GenerateIntArray(ArrayOptions option, int length)
    {
        var arr = new int[length];
        for (var i = 0; i < length; ++i)
        {
            arr[i] = Rand.Next();
        }

        if (option == ArrayOptions.Sorted)
        {
            Array.Sort(arr);
        }

        if (option == ArrayOptions.Reversed)
        {
            Array.Sort(arr);
            Array.Reverse(arr);
        }

        return arr;
    }
}
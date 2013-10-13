using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework;

namespace UnitTestHomework
{
    [TestClass]
    public class TestGenericList
    {
        private GenericList<int> testListInt;
        private GenericList<double> testListDouble;

        [TestInitialize]
        public void Initialize()
        {
            testListInt = new GenericList<int>();
            testListDouble = new GenericList<double>(12);
        }

        [TestMethod]
        public void TestAddInZeroCapacity()
        {
            testListInt.Add(15);
            Assert.AreEqual(testListInt.Count,1,"Count is different then 1");
            Assert.AreEqual(testListInt[0], 15, "Element is not correctly passed to list");
        }

        [TestMethod]
        public void TestAddInInitialized()
        {
            testListInt.Add(15);
            testListInt.Add(25);
            Assert.AreEqual(testListInt.Count, 2, "Count is different then 2");
        }

        [TestMethod]
        public void TestAutoGrow()
        {
            for (int i = 0; i < 34; i++)
            {
                testListDouble.Add(i); 
            }
            Assert.AreEqual(testListDouble.Capacity, 48, "Capacity is different then 48");
        }

        [TestMethod]
        public void TestClear()
        {
            testListInt.Add(15);
            testListInt.Add(25);
            testListInt.ClearList();
            Assert.AreEqual(testListInt.Capacity, 0, "Capacity is not 0");
            Assert.AreEqual(testListInt.Count, 0, "Count is not 0");
        }

        [TestMethod]
        [ExpectedException(typeof(OutOfMemoryException))]
        public void TestAddWhenFull()
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                testListInt.Add(i);
            }

            testListInt.Add(-1);
        }
    }
}

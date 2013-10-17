using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RangeException;

namespace TestRangeException
{
    [TestClass]
    public class TestRangeException
    {
        const int intMinRange = 1;
        const int intMaxRange = 100;
        readonly DateTime dtMinRange = new DateTime(1980, 1, 1);
        readonly DateTime dtMaxRange = new DateTime(2013, 12, 31);

        
        public void TestRange<T> (T value, T minRange, T maxRange) where T : IComparable
        {
            string errorMessage = "Value is not in range [" + minRange + ".." + maxRange + "}";
            if (value.CompareTo(minRange)<0 || value.CompareTo(maxRange)>0 )
            {
                throw new InvalidRangeException<T>(errorMessage, minRange, maxRange);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRangeException<int>))]
        public void TestIntRangeBelow()
        {
            TestRange<int>(0,intMinRange,intMaxRange);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRangeException<int>))]
        public void TestIntRangeAbove()
        {
            TestRange<int>(175, intMinRange, intMaxRange);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRangeException<DateTime>))]
        public void TestDTRangeBelow()
        {
            TestRange<DateTime>(new DateTime(1975, 11, 23), dtMinRange,dtMaxRange);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRangeException<DateTime>))]
        public void TestDTRangeAbove()
        {
            TestRange<DateTime>(new DateTime(2014, 1, 1), dtMinRange, dtMaxRange);

        }
    }
}

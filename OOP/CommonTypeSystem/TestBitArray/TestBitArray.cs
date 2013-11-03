using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using P05BitArray64;

namespace TestBitArray
{
    [TestClass]
    public class TestBitArray
    {
        [TestMethod]
        public void TestGetAndSetByIndex()
        {
            BitArray64 array = new BitArray64();
            array[34] = 1;
            Assert.AreEqual(1, array[34], "Incorect internal state");       //ulong private array member should be = 17179869184
        }

        [TestMethod]
        public void TestEquals()
        {
            BitArray64 array1 = new BitArray64(4295495744);  // 100000000000010000001000001000000 binary representation
            BitArray64 array2 = new BitArray64();
            array2[6] = 1;
            array2[12] = 1;
            array2[19] = 1;
            array2[32] = 1;
            Assert.AreEqual(true, array1.Equals(array2),"Equality test failed");
        }

    }
}

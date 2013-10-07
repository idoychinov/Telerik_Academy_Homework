using System;
using Homework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestHomework
{
    [TestClass]
    public class TestPoint3D
    {
        // This can be removed. Properties generaly should not be tested if they are trivial (automatic or without any complex checks) and it's not best practice to have multiple asserts in one test.
        [TestMethod]
        public void TestPropertiesAndConstructor()
        {
            Point3D testPoint = new Point3D(Int32.MaxValue, 0, Int32.MinValue);
            Assert.AreEqual(Int32.MaxValue, testPoint.X, "X coordinate set as int32.MaxValue in the constructor is not int32.MaxValue when called by the Point3D.X property!");
            Assert.AreEqual(0, testPoint.Y, "Y coordinate set as 0 in the constructor is not 0 when called by the Point3D.Y property!");
            Assert.AreEqual(Int32.MinValue, testPoint.Z, "Z coordinate set as int32.MinValue in the constructor is not int32.MinValue when called by the Point3D.Z property!");
        }

        [TestMethod]
        public void TestToStringMethod()
        {
            Point3D testPoint = new Point3D(Int32.MaxValue, 0, Int32.MinValue);
            string testPointString = "{" + Int32.MaxValue + ", " + 0 + ", " + Int32.MinValue + "}";
            Assert.AreEqual(testPointString,testPoint.ToString(),"ToString() method does not return correctly formated string with point coordinates.");
        }

        [TestMethod]
        public void TestPointOCoordinates()
        {
            Assert.AreEqual("{0, 0, 0}", Point3D.PointO.ToString(), "Point0.ToString() does not return the center of the coordinate system {0, 0, 0}");

            // secondary test can be omitted. It test the same thing but it's not relaying on ToString() function.
            Point3D testPoint = new Point3D(0, 0, 0);
            Assert.AreEqual(testPoint, Point3D.PointO, "Point0 is not the same as point created with coordinates {0, 0, 0}");

        }
    }
}

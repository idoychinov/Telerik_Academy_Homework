using System;
using Homework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestHomework
{
    [TestClass]
    public class TestCalculations3DSpace
    {
        [TestMethod]
        public void TestXCoordinateDistance()
        {
            int x1 = 213;
            int x2 = -57;
            double preCalculatedDistance = Math.Sqrt(Math.Pow((x1 - x2), 2));
            double methodCalculatedDistance = Calculations3DSpace.Distance(new Point3D(x1, 34, 12), new Point3D(x2, 34, 12));
            Assert.AreEqual(preCalculatedDistance, methodCalculatedDistance, "X coordinates distance is not calculated correctly");
        }

        [TestMethod]
        public void TestYCoordinateDistance()
        {
            int y1 = -86;
            int y2 = -567;
            double preCalculatedDistance = Math.Sqrt(Math.Pow((y1 - y2), 2));
            double methodCalculatedDistance = Calculations3DSpace.Distance(new Point3D(0, y1, 0), new Point3D(0, y2, 0));
            Assert.AreEqual(preCalculatedDistance, methodCalculatedDistance, "Y coordinates distance is not calculated correctly");
        }

        [TestMethod]
        public void TestZCoordinateDistance()
        {
            int z1 = 0;
            int z2 = 59035;
            double preCalculatedDistance = Math.Sqrt(Math.Pow((z1 - z2), 2));
            double methodCalculatedDistance = Calculations3DSpace.Distance(new Point3D(-4345, 34512, z1), new Point3D(-4345, 34512, z2));
            Assert.AreEqual(preCalculatedDistance, methodCalculatedDistance, "Z coordinates distance is not calculated correctly");
        }

        [TestMethod]
        public void TestDistanceForNormalCase()
        {
            // point 1 coordinates
            int x1=23256;
            int y1 = -43562234;
            int z1= 0;

            // point 2 coordinates
            int x2= 6734545;
            int y2 = 32145;
            int z2 = -6523471;

            Point3D point1 = new Point3D(x1, y1, z1);
            Point3D point2 = new Point3D(x2, y2, z2);

            double preCalculatedDistance = Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2) + Math.Pow((z1 - z2), 2));
            double methodCalculatedDistance = Calculations3DSpace.Distance(point1,point2);
            Assert.AreEqual(preCalculatedDistance, methodCalculatedDistance, "Distance between two Normal case points is not calculated correctly");
        }

        [TestMethod]
        public void TestDistanceForBorderCase()
        {
            // point 1 coordinates
            int x1 = Int32.MaxValue;
            int y1 = Int32.MaxValue;
            int z1 = Int32.MaxValue;

            // point 2 coordinates
            int x2 = Int32.MinValue;
            int y2 = Int32.MinValue;
            int z2 = Int32.MinValue;

            Point3D point1 = new Point3D(x1, y1, z1);
            Point3D point2 = new Point3D(x2, y2, z2);

            long xDifference = (long)x1 - (long)x2;
            long yDifference = (long)y1 - (long)y2;
            long zDifference = (long)z1 - (long)z2;
            double preCalculatedDistance = Math.Sqrt(Math.Pow((xDifference), 2) + Math.Pow((yDifference), 2) + Math.Pow((zDifference), 2));
            double methodCalculatedDistance = Calculations3DSpace.Distance(point1, point2);
            Assert.AreEqual(preCalculatedDistance, methodCalculatedDistance, "Distance between two Border case points is not calculated correctly");
        }
    }
}

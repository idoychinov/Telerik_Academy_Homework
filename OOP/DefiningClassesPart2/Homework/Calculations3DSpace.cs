using System;
using System.Numerics;

namespace Homework
{
    // Problem 3. Write a static class with a static method to calculate the distance between two points in the 3D space.

    public static class Calculations3DSpace
    {
        public static double Distance(Point3D pointA, Point3D pointB)
        {
            BigInteger pointACoordinateX = pointA.X;
            BigInteger pointACoordinateY = pointA.Y;
            BigInteger pointACoordinateZ = pointA.Z;
            BigInteger pointBCoordinateX = pointB.X;
            BigInteger pointBCoordinateY = pointB.Y;
            BigInteger pointBCoordinateZ = pointB.Z;

            BigInteger differenceX = (pointACoordinateX - pointBCoordinateX) * (pointACoordinateX - pointBCoordinateX);
            BigInteger differenceY = (pointACoordinateY - pointBCoordinateY) * (pointACoordinateY - pointBCoordinateY);
            BigInteger differenceZ = (pointACoordinateZ - pointBCoordinateZ) * (pointACoordinateZ - pointBCoordinateZ);
            double sum = (double)(differenceX + differenceY + differenceZ);
            double distance = Math.Sqrt(sum);

            return distance;
        }
    }
}

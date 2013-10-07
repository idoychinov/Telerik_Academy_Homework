using System;

namespace Homework
{
    //Problem1. Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space. Implement the ToString() to enable printing a 3D point.

    public struct Point3D
    {
        //Problem2. Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}. Add a static property to return the point O.

        private static readonly Point3D pointO = new Point3D();

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public static Point3D PointO
        {
            get
            {
                return pointO;
            }
        }

        public Point3D(int x, int y, int z): this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override string ToString()
        {
            string result = "{" + X + ", " + Y + ", " + Z + "}";
            return result;
        }


    }
}

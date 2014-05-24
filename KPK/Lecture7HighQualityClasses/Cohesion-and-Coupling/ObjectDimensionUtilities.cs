namespace CohesionAndCoupling
{
    using System;
    
    public static class ObjectDimensionUtilities
    {
        public static double CalcVolume(I3Dimensional object3D)
        {
            double volume = object3D.Width * object3D.Height * object3D.Depth;
            return volume;
        }

        public static double CalcDiagonalXYZ(I3Dimensional object3D)
        {
            double distance = DistanceUtilities.CalcDistance3D(0, 0, 0, object3D.Width, object3D.Height, object3D.Depth);
            return distance;
        }

        public static double CalcDiagonalXY(I2Dimensional object2D)
        {
            double distance = DistanceUtilities.CalcDistance2D(0, 0, object2D.Width, object2D.Height);
            return distance;
        }

        public static double CalcDiagonalXZ(I3Dimensional object3D)
        {
            double distance = DistanceUtilities.CalcDistance2D(0, 0, object3D.Width, object3D.Depth);
            return distance;
        }

        public static double CalcDiagonalYZ(I3Dimensional object3D)
        {
            double distance = DistanceUtilities.CalcDistance2D(0, 0, object3D.Height, object3D.Depth);
            return distance;
        }
    }
}

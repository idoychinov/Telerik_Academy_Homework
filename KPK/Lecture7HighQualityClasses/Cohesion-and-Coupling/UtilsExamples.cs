namespace CohesionAndCoupling
{
    using System;

    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine(FileUtilities.GetFileExtension("example"));
            Console.WriteLine(FileUtilities.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtilities.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtilities.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtilities.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtilities.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine(
                "Distance in the 2D space = {0:f2}",
                DistanceUtilities.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine(
                "Distance in the 3D space = {0:f2}",
                DistanceUtilities.CalcDistance3D(5, 2, -1, 3, -6, 4));

            I3Dimensional objectIn3DSpace = new Object3D(5, 3, 4);
            Console.WriteLine("Volume = {0:f2}", ObjectDimensionUtilities.CalcVolume(objectIn3DSpace));
            Console.WriteLine("Diagonal XYZ = {0:f2}", ObjectDimensionUtilities.CalcDiagonalXYZ(objectIn3DSpace));
            Console.WriteLine("Diagonal XY = {0:f2}", ObjectDimensionUtilities.CalcDiagonalXY(objectIn3DSpace));
            Console.WriteLine("Diagonal XZ = {0:f2}", ObjectDimensionUtilities.CalcDiagonalXZ(objectIn3DSpace));
            Console.WriteLine("Diagonal YZ = {0:f2}", ObjectDimensionUtilities.CalcDiagonalYZ(objectIn3DSpace));

            I2Dimensional objectIn2DSpace = new Object2D(3, 4);
            Console.WriteLine("Diagonal XY = {0:f2}", ObjectDimensionUtilities.CalcDiagonalXY(objectIn2DSpace));
        }
    }
}

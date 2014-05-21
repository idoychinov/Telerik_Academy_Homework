using System;
using System.Linq;

public class Size
{
    public double Width { get; set; }
    public double Heigth { get; set; }
    public Size(double width, double heigth)
    {
        this.Width = width;
        this.Heigth = heigth;
    }

    public static Size GetRotatedSize(Size size, double angleOfRotation)
    {
        double width,highth;
        width= (Math.Abs(Math.Cos(angleOfRotation)) * size.Width) + (Math.Abs(Math.Sin(angleOfRotation)) * size.Heigth);
        highth = (Math.Abs(Math.Sin(angleOfRotation)) * size.Width) + (Math.Abs(Math.Cos(angleOfRotation)) * size.Heigth);
        Size rotatedSize = new Size(width,highth);
        return rotatedSize;
    }
}



using System;

namespace Shapes
{
    public class Rectangle :Shape
    {
        public Rectangle(int width, int height)
            : base(width,height)
        {
        }

        public override decimal CalculateSurface()
        {
            return (decimal)(this.height * this.width);
        }
    }
}

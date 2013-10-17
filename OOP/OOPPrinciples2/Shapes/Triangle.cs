using System;

namespace Shapes 
{
    public class Triangle : Shape 
    {
        public Triangle(int width, int height)
            : base(width,height)
        {
        }

        public override decimal CalculateSurface()
        {
            return (decimal)(this.height * this.width) / 2M;
        }
    }
}

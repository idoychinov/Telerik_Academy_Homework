using System;

namespace Shapes
{
    public abstract class Shape
    {
        protected int width;
        protected int height;
        
        public Shape(int width, int height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentOutOfRangeException("Parameter(s) must be positive integer");
            }
            this.width = width;
            this.height= height;
        }
        public abstract decimal CalculateSurface();
        

    }
}

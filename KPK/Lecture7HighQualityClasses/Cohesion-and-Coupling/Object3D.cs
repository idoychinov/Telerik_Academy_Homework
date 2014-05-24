namespace CohesionAndCoupling
{
    using System;

    public class Object3D : Object2D, I3Dimensional
    {
        private double depth;

        public Object3D(double depth, double width, double height) :
            base(width, height)
        {
            this.Depth = depth;
        }

        public double Depth
        {
            get
            {
                return this.depth;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Value must be positive number");
                }

                this.depth = value;
            }
        }
    }
}

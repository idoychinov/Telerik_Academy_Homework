namespace CohesionAndCoupling
{
    using System;

    public class Object2D : I2Dimensional
    {
        private double width;

        private double height;

        public Object2D(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
       
        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Value must be positive number");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Value must be positive number");
                }

                this.height = value;
            }
        }
    }
}

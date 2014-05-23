//-----------------------------------------------------------------------
// <copyright file="Point.cs" company="Test Company">
//      Style Cop is finaly happy... yey!
// </copyright>
//-----------------------------------------------------------------------
namespace Methods
{
    /// <summary>
    /// Represents point in Cartesian coordinate system
    /// </summary>
    public struct Point
    {
        /// <summary>
        /// X coordinate private field
        /// </summary>
        private double x;

        /// <summary>
        /// Y coordinate private field
        /// </summary>
        private double y;

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> struct.
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Gets or sets X coordinate
        /// </summary>
        public double X
        {
            get
            {
                return this.x;
            }

            set
            {
                this.x = value;
            }
        }

        /// <summary>
        /// Gets or sets Y coordinate
        /// </summary>
        public double Y
        {
            get
            {
                return this.y;
            }

            set
            {
                this.y = value;
            }
        }
    }
}

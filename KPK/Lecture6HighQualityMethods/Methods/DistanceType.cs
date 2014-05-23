//-----------------------------------------------------------------------
// <copyright file="DistanceType.cs" company="Test Company">
//      Style Cop is finaly happy... yey!
// </copyright>
//-----------------------------------------------------------------------
namespace Methods
{
    /// <summary>
    /// Describes what is the relative distance type between two points
    /// </summary>
    public enum DistanceType 
    {
        /// <summary>
        /// The Y coordinate of two or more points is the same and the distance between them is horizontal.
        /// </summary>
        Horizontal,

        /// <summary>
        /// The X coordinate of two or more points is the same and the distance between them is vertical.
        /// </summary>
        Vertical,

        /// <summary>
        /// Both X and Y coordinates of two or more points are the same and there is no distance between them.
        /// </summary>
        NoDistance,

        /// <summary>
        /// The distance between two or more points is neither horizontal nor vertical.
        /// </summary>
        Other 
    }
}

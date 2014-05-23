//-----------------------------------------------------------------------
// <copyright file="Methods.cs" company="Test Company">
//      Style Cop is finaly happy... yey!
// </copyright>
//-----------------------------------------------------------------------
namespace Methods
{
    using System;

    /// <summary>
    /// Methods class containing refactored high quality methods.
    /// </summary>
    public class Methods
    {
        /// <summary>
        /// Calculates the triangle area if the sides passed as arguments can form a triangle
        /// </summary>
        /// <param name="sideA">Length of the first side of the triangle</param>
        /// <param name="sideB">Length of the second side of the triangle</param>
        /// <param name="sideC">Length of the third side of the triangle</param>
        /// <exception cref="System.ArgumentException">Thrown when one or more sides are less then or equal
        /// to zero or one of the sides is equal or bigger than the other two.
        /// In both cases the passed sides cannot form a triangle</exception>
        /// <returns>Calculated Triangle Area</returns>
        public static double CalculateTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentException("All triangle sides should be positive numbers."); 
            }

            if ((sideA + sideB <= sideC) || (sideB + sideC <= sideA) || (sideA + sideC <= sideB))
            {
                throw new ArgumentException("Any two triangle side should be bigger than the third.");
            }

            double semiperimeter = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(semiperimeter * (semiperimeter - sideA) *
                (semiperimeter - sideB) * (semiperimeter - sideC));
            return area;
        }

        /// <summary>
        /// Returns the name of a single digit passed as integer as string. 
        /// </summary>
        /// <param name="digit">Single digit integer</param>
        /// <exception cref="System.ArgumentExeption">Thrown when the input integer is not a single digit
        /// (in the range from 0 to 9)</exception>
        /// <returns>Name of the digit in english.</returns>
        public static string ConvertDigitToString(int digit)
        {
            switch (digit)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new
                    ArgumentException("The input should be digit - integer number between 0 and 9");
            }
        }

        /// <summary>
        /// Returns the maximum number of the array of integer elements.
        /// </summary>
        /// <param name="elements">Array of integers passed as array or comma separated values</param>
        /// <exception cref="System.ArgumentException">Thrown if the input array is null or empty</exception>
        /// <returns>Maximum number. If the array contains single element it will be returned as result</returns>
        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("Input parameters array cannot be null or empty!");
            }

            int max = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }

            return max;
        }

        /// <summary>
        /// Prints object that can be represented as number, formatted based on the passed format parameter
        /// </summary>
        /// <param name="number">Object to be formatted and written to the console as number</param>
        /// <param name="format">Format in which the number to be written to the console</param>
        /// <exception cref="System.ArgumentException">Thrown if the input object number cannot be parsed to numeric 
        /// type.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown if the passed format is not supported.</exception>
        public static void PrintAsNumber(object number, string format)
        {
            double parsedNumber;
            if (!double.TryParse(number.ToString(), out parsedNumber))
            {
                throw new ArgumentException("Input number should be one of the numeric types.");
            }

            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }
            else if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }
            else if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
            else
            {
                throw new ArgumentOutOfRangeException(string.Format("Unknown format \"{0}\".", format));
            }
        }

        /// <summary>
        /// Calculates the distance between two points.
        /// </summary>
        /// <param name="firstPoint">First point</param>
        /// <param name="secondPoint">Second point</param>
        /// <returns>Distance between the two points</returns>
        public static double CalculateDistance(Point firstPoint, Point secondPoint)
        {
            double squareDistanceX = (secondPoint.X - firstPoint.X) * (secondPoint.X - firstPoint.X);
            double squareDistanceY = (secondPoint.Y - firstPoint.Y) * (secondPoint.Y - firstPoint.Y);
            double distance = Math.Sqrt(squareDistanceX + squareDistanceY);
            return distance;
        }

        /// <summary>
        /// Returns the type of distance between two points. 
        /// </summary>
        /// <param name="firstPoint">First point</param>
        /// <param name="secondPoint">Second point</param>
        /// <returns>If both points have the same X coordinate
        /// the type of distance is vertical, if both have same Y coordinate the distance type is horizontal,
        /// and if they don't have equal coordinates returns type Other.
        /// </returns>
        public static DistanceType FindDistanceType(Point firstPoint, Point secondPoint)
        {
            DistanceType distanceType;
            if (firstPoint.Y == secondPoint.Y)
            {
                distanceType = DistanceType.Horizontal;
            }
            else if (firstPoint.X == secondPoint.X)
            {
                distanceType = DistanceType.Vertical;
            }
            else
            {
                distanceType = DistanceType.Other;
            }

            return distanceType;
        }

        /// <summary>
        /// Main method for the program.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3.4, 5, 4.3));

            Console.WriteLine(ConvertDigitToString(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintAsNumber(1.3, "f");
            PrintAsNumber(0.75, "%");
            PrintAsNumber(2.30, "r");

            Point pointA = new Point(3, -1);
            Point pointB = new Point(3, 2.5);
            Console.WriteLine(CalculateDistance(pointA, pointB));
            DistanceType distanceType = FindDistanceType(pointA, pointB);
            bool horizontal = distanceType == DistanceType.Horizontal || distanceType == DistanceType.NoDistance;
            bool vertical = distanceType == DistanceType.Vertical || distanceType == DistanceType.NoDistance;
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student() 
            { FirstName = "Peter", LastName = "Ivanov", BirthDate = new DateTime(1992, 11, 03) };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() 
            { FirstName = "Stella", LastName = "Markova", BirthDate = new DateTime(1993, 11, 03) };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine(
                "{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}

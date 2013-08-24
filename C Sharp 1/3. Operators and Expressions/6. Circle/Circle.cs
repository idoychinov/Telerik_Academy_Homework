/*
 * Problem 6. Write an expression that checks if given point (x,  y) is within a circle K(O, 5).
 */


using System;

class Circle
{
    static void Main()
    {
        
        int circleRadius = 5;
        int pointX;
        int pointY;
        bool correctX;
        bool correctY;
        bool pointInside;
        string resultString;

        while (true)
        {
            // input of X and Y and check if both are correct.
            Console.Write("Enter an integer number for X coordinate of the point:"); 
            correctX = int.TryParse(Console.ReadLine(), out pointX);
            Console.Write("Enter an integer number for Y coordinate of the point:");
            correctY = int.TryParse(Console.ReadLine(), out pointY);

            if (correctX && correctY)
            {
                pointInside = ((pointX * pointX) + (pointY * pointY)) <= (circleRadius * circleRadius); // If the point is lies on the circle border or inside then the Pythagorean theorem dictates that 
                                                                                                        // a^2+b^2=<c^2 so we check this way to see if the point is inside.
                if (pointInside)
                {
                    resultString = "IS";
                }
                else
                {
                    resultString = "IS NOT";
                }
                Console.WriteLine("The point with coordinates ({0},{1}) " + resultString + " in the defined circle",pointX,pointY);
                break;
            }
            else
            {
                Console.WriteLine("\nPlease enter correct values for both X and Y\n");
            }
        }

    }
}


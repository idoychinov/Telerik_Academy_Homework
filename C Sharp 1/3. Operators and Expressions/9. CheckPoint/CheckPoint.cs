/*
 * Problem 9. Write an expression that checks for given point (x, y) if it is within the circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2).
 */

using System;

class CheckPoint
{
    static void Main()
    {
        int circleRadius = 3;
        int circleCenterX = 1;
        int circleCenterY = 1;
        int rTop=1;
        int rLeft=-1;
        int rWidth=6;
        int rHeight=2;
        int pointX;
        int pointY;
        bool correctX;
        bool correctY;

        while (true)
        {
            // input of X and Y and check if both are correct.
            Console.Write("Enter an integer number for X coordinate of the point:"); 
            correctX = int.TryParse(Console.ReadLine(), out pointX);
            Console.Write("Enter an integer number for Y coordinate of the point:");
            correctY = int.TryParse(Console.ReadLine(), out pointY);

            if (correctX && correctY)
            {
                if (((pointX - circleCenterX) * (pointX - circleCenterX)) + ((pointY - circleCenterY) * (pointY - circleCenterY)) <= circleRadius * circleRadius)  //we shift the point withe the circle center coordinates in order to make it the center of the coordinate system for this calculation
                {
                    if ((pointX < rLeft) | (pointX > rLeft + rWidth) | (pointY > rTop) | (pointY < rTop - rHeight)) // we check if the apropriate X and Y coordinates are outside of the dimensions of the rectangle. It is enough for one coordinate to be outside of the range for the point to be out. 
                                                                                                                    // for example if the X coordinate is greater than the left point of the rectangle plus its width, that means the point is outside. Same is true if the X coordinate of the point is less than the left point of the rectangle.
                    {
                        Console.WriteLine("The point is both in the circle and out of the rectangle");
                    }
                    else
                    {
                        Console.WriteLine("The point is in the rectangle");
                    }
                }
                else
                {
                    Console.WriteLine("The point is outside of the circle");
                }
                break;
            }
            else
            {
                Console.WriteLine("\nPlease enter correct values\n");
            }
        }
    }
}


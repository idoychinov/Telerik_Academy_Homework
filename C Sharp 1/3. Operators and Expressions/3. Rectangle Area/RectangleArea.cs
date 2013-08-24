/*
 * Problem 3. Write an expression that calculates rectangle’s area by given width and height.
 */

using System;

class RectangleArea
{
    static void Main()
    {
        uint width;
        uint height;
        bool correctWidth;
        bool correctHeight;
        ulong area;
        while (true)
        {
            // input of height and width with conversion to unsigned int and check if both are correct.
            Console.Write("Enter a positve integer number for Width:"); 
            correctWidth = uint.TryParse(Console.ReadLine(), out width);
            Console.Write("Enter a positve integer number for Height:");
            correctHeight = uint.TryParse(Console.ReadLine(), out height);

            if (correctWidth && correctHeight)
            {
                area = width * height;
                Console.WriteLine("The rectangle with width={0} and height={1} has area={2}.",width,height,area);
                break;
            }
            else
            {
                Console.WriteLine("\nPlease enter correct values for both height and width\n");
            }
        }
    }
}


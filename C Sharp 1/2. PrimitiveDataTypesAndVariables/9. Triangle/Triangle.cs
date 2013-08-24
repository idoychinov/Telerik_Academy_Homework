/* Problem 9.Write a program that prints an isosceles triangle of 9 copyright symbols ©. Use Windows Character Map to find the Unicode code of the © symbol. Note: the © symbol may be displayed incorrectly.
 */

using System;
using System.Text;

class Triangle
{
    static void Main()
    {
        char symbol = '\u00A9'; 
        string line;
        byte height;
        bool correct;

        Console.OutputEncoding = Encoding.UTF8; // used in order to correctly display the © symbol otherwise it displayes as "c"

        Console.Write("Please enter triangle height (a number between 1-40):");  // Enter height 3 for triangle consisting of 9 symbols. Entering large number (above 40) will cause incorect displey because of the console width.
        line=Console.ReadLine();
        correct=byte.TryParse(line, out height)&(height<=40);

        if (correct&(height!=0)) // checks if the input for height is correct
        {
            Console.WriteLine("The Triangle consists of {0} symbols\n", height*height);
            for (int i = 1; i <= height; i++) // loop for the rows
            {
                for (int j = 1; j < 2*height; j++) // loop used to write the symbols and empty spaces on single row. 
                {
                    if ((j <= height - i) | (j >= height + i))  // If the current symbol index (starting from 1 for the leftmost symbol) that must be writen is less then or equal of the height of the triangle
                                                                // minus current row index, or greater or equal of the height of the triangle plus current row index then the symbol we must write is 
                                                                // empty space. Otherwise we write the symbol
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(symbol);
                    }
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Height is incorrect");
        }

    }
}

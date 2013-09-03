/* Problem 11. Write a method that adds two polynomials. Represent them as arrays of their coefficients as in the example below:
 * x2 + 5 = 1x2 + 0x + 5 -> 5 0 1
*/

using System;

class AddPolynomials
{
    static int polyLength = 3;

    static void EnterPoly(int[] poly)
    {
        for (int i = 0; i < polyLength; i++)
        {
            Console.Write("Enter coeficient {0} = ",i+1);
            poly[i] = int.Parse(Console.ReadLine());
        }
    }

    static int[] AddPoly(int[] poly1, int[] poly2)
    {
        int[] result = new int[polyLength];
        for (int i = 0; i < polyLength; i++)
			{
                result[i] = poly1[i] + poly2[i];
			}
        return result;
    }

    static void PrintPoly(int[] poly)
    {
        for (int i = 0; i < polyLength; i++)
        {
            Console.WriteLine("Coeficient {0} = {1}",i+1,poly[i]);
        }
    }

    static void Main()
    {
        int[] poly1 = new int[polyLength];
        int[] poly2 = new int[polyLength];
        Console.WriteLine("Enter polynomial 1:");
        EnterPoly(poly1);
        Console.WriteLine("Enter polynomial 2:");
        EnterPoly(poly2);
        Console.WriteLine("The resulting polynomial is with coeficients: ");
        PrintPoly(AddPoly(poly1,poly2));
    }
}


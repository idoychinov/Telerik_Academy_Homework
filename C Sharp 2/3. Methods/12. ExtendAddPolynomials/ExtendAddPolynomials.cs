/* Problem 12. Extend the program (11) to support also subtraction and multiplication of polynomials.
*/

using System;

class ExtendAddPolynomials
{
    static int polyLength = 3;

    static void EnterPoly(int[] poly)
    {
        for (int i = 0; i < polyLength; i++)
        {
            Console.Write("Enter coeficient {0} = ", i + 1);
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

    static int[] SubstractPoly(int[] poly1, int[] poly2)
    {
        int[] result = new int[polyLength];
        for (int i = 0; i < polyLength; i++)
        {
            result[i] = poly1[i] - poly2[i];
        }
        return result;
    }

    static int[] MultiplayPoly(int[] poly1, int[] poly2)
    {
        int[] result = new int[polyLength+polyLength];
        for (int i = 0; i < result.Length; i++)
			{
			    result[i]=0;
			}
        for (int i = 0; i < poly1.Length; i++)
        {
            for (int j = 0; j < poly2.Length; j++)
            {
                result[i + j] = result[i + j] + (poly1[i] * poly2[j]);
            }
            
        }
        return result;
    }

    static void PrintPoly(int[] poly)
    {
    /*  for (int i = 0; i < poly.Length; i++)
        {
            Console.WriteLine("Coeficient {0} = {1}", i + 1, poly[i]);
        }
        Console.WriteLine("OR");
    */
        for (int i = poly.Length-1 ; i >= 0 ; i--)
        {

            PrintCoeficient(poly[i],i);
        }
        Console.WriteLine("\n");

    }

    static void PrintCoeficient(int c,int index)
    {
        string x="x";
        if (index == 0)
        {
            x = "";
        }
        else
        {
            x+=""+"^"+index.ToString();
        }
        if (c != 0)
        {
            if (c > 0)
            {
                Console.Write('+');
            }
            Console.Write("{0}{1}",c,x);
        }
    }

    static void Main()
    {
        int[] poly1 = new int[polyLength];
        int[] poly2 = new int[polyLength];
        int[] result = new int[polyLength];
        Console.WriteLine("Enter polynomial 1:");
        EnterPoly(poly1);
        Console.WriteLine("Enter polynomial 2:");
        EnterPoly(poly2);
        Console.Write("Polinomial 1: ");
        PrintPoly(poly1);
        Console.Write("Polinomial 2: ");
        PrintPoly(poly2);
        Console.WriteLine("The resulting polynomial from Addition is with coeficients: ");
        PrintPoly(AddPoly(poly1, poly2));

        Console.WriteLine("The resulting polynomial from Substraction is with coeficients: ");
        PrintPoly(SubstractPoly(poly1, poly2));

        Console.WriteLine("The resulting polynomial from Multiplication is with coeficients: ");
        PrintPoly(MultiplayPoly(poly1, poly2));
    }
}


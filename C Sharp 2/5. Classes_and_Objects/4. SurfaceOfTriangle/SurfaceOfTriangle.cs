/* Problem 4.Write methods that calculate the surface of a triangle by given:
Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.
 */
using System;
using System.Linq;
using System.Globalization;



class SurfaceOfTriangle
{
    static void Main()
    {
        
        bool active = true;
        while (active)
        {
            Console.WriteLine("Please chose the input data for calculationg the surface of the triangle:");
            Console.WriteLine("1. Side and altitude to this side.");
            Console.WriteLine("2. Three sides.");
            Console.WriteLine("3. Two sides and an angle between them.");
            Console.WriteLine("4. Exit the program.");
            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();
            switch (key.KeyChar)
            {
                case '1': Console.WriteLine("The surface is:{0}", CalculateSurface(Input("Input side:"), Input("Input altitude to side:"))); break;
                case '2': Console.WriteLine("The surface is:{0}", CalculateSurface(Input("Side 1:"), Input("Side 2:"), Input("Side 3:"))); break;
                case '3': Console.WriteLine("The surface is:{0}", CalculateSurface(Input("Side 1:"), Input("Side 2:"), InputAngle("Angle between sides:"))); break;
                case '4': active = false; break;
                default: Console.WriteLine("Incorect choise, please try again!"); break;
            }
            Console.WriteLine();
        }
    }

    static decimal Input(string message)
    {
        decimal output;
        Console.Write(message);
        while (true)
        {
            if(decimal.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,CultureInfo.InvariantCulture, out output))
            {
                break;
            }
            else
            {
                Console.Write("Incorect input, try again:");
            }
        }
        return output;
    }

    static int InputAngle(string message)
    {
        int output;
        Console.Write(message);
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out output)&&(output>0)&&(output<180))
            {
                break;
            }
            else
            {
                Console.Write("Incorect input, try again:");
            }
        }
        return output;
    }
    
    // i have defined one method with 2 overloads, instead of just one method with paramether for choosing what type of calculation should be used. Basicly it achieves the same result.
    static decimal CalculateSurface(decimal side, decimal alt)
    {
        return decimal.Multiply(decimal.Multiply(side,alt),0.5M);
    }

    static decimal CalculateSurface(decimal a, decimal b,decimal c)
    {
        decimal s = decimal.Multiply(0.5M, (a + b + c));//semi-perimeter

        return (decimal)Math.Sqrt((double)(s*(s-a)*(s-b)*(s-c)));
    }

    static decimal CalculateSurface(decimal a, decimal b, int angle)
    {
        double rad;
        rad = Math.PI * (double)angle / 180; // converting degrees to radians in order to use them in Math.Sin()
        return 0.5M*a*b*(decimal)Math.Sin(rad);
    }
}


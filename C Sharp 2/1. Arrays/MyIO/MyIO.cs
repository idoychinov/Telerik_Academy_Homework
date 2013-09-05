/* In this project we define a class with several methods that will be used  for inputing valules in variables from diferent types. This way after defining all the needed methods and reffering to this project
 * in any other project within the solution we can input value and make verification if the value is correct with only one method call instead of writing the code every time.
 * In order to do this for every project we want to use those methods we need to "Add Reference" for this project and then use the clause using with the namespace name.
 */

using System;

namespace MyIO
{
    public class MyIOClass
    {
        const string inMessageStart = "Please enter a value in the range ";
        const string ErrMessage = "The value you entered is incorect, please try again: ";

        static void Main()
        {
            
        }

        // This method is used to input byte variable. First we display a message (it can be the default message or massege sent as parameter). After that we check if the entered value is correct
        // and if not we display error message (again can be default or a message sent as a parameter) and wait for new value to be entered and do the check again.
        static public void Input(out byte output, string defaultInMessage = inMessageStart + "(0..255): ", string defautErrMessage = ErrMessage)
        {
            string inValue;
            Console.Write(defaultInMessage);
            while (true)
            {
                inValue=Console.ReadLine();
                if (byte.TryParse(inValue, out output))
                {
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.Write(defautErrMessage);
                }
            }
        }
        // Each method after the first is generaly the same with the different input type and the appropriate TryParse method for this type. Depending of the variable type that is used in calling the method
        // the apropriate method will be used since all are with the same name but with diferent parameters (this is called Overloading).
        static public void Input(out sbyte output, string defaultInMessage = inMessageStart + "(-128..127): ", string defautErrMessage = ErrMessage)
        {
            string inValue;
            Console.Write(defaultInMessage);
            while (true)
            {
                inValue = Console.ReadLine();
                if (sbyte.TryParse(inValue, out output))
                {
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.Write(defautErrMessage);
                }
            }
        }

        static public void Input(out short output, string defaultInMessage = inMessageStart + "(-32,768..32,767): ", string defautErrMessage = ErrMessage)
        {
            string inValue;
            Console.Write(defaultInMessage);
            while (true)
            {
                inValue = Console.ReadLine();
                if (short.TryParse(inValue, out output))
                {
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.Write(defautErrMessage);
                }
            }
        }

        static public void Input(out ushort output, string defaultInMessage = inMessageStart + "(0 .. 65,535): ", string defautErrMessage = ErrMessage)
        {
            string inValue;
            Console.Write(defaultInMessage);
            while (true)
            {
                inValue = Console.ReadLine();
                if (ushort.TryParse(inValue, out output))
                {
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.Write(defautErrMessage);
                }
            }
        }

        static public void Input(out int output, string defaultInMessage = inMessageStart + "(-2,147,483,648 .. 2,147,483,647): ", string defautErrMessage = ErrMessage)
        {
            string inValue;
            Console.Write(defaultInMessage);
            while (true)
            {
                inValue = Console.ReadLine();
                if (int.TryParse(inValue, out output))
                {
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.Write(defautErrMessage);
                }
            }
        }

        static public void Input(out uint output, string defaultInMessage = inMessageStart + "(0 .. 4,294,967,295): ", string defautErrMessage = ErrMessage)
        {
            string inValue;
            Console.Write(defaultInMessage);
            while (true)
            {
                inValue = Console.ReadLine();
                if (uint.TryParse(inValue, out output))
                {
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.Write(defautErrMessage);
                }
            }
        }

        static public void Input(out long output, string defaultInMessage = inMessageStart + "(-9,223,372,036,854,775,808 .. 9,223,372,036,854,775,807): ", string defautErrMessage = ErrMessage)
        {
            string inValue;
            Console.Write(defaultInMessage);
            while (true)
            {
                inValue = Console.ReadLine();
                if (long.TryParse(inValue, out output))
                {
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.Write(defautErrMessage);
                }
            }
        }

        static public void Input(out ulong output, string defaultInMessage = inMessageStart + "(0 .. 18,446,744,073,709,551,615): ", string defautErrMessage = ErrMessage)
        {
            string inValue;
            Console.Write(defaultInMessage);
            while (true)
            {
                inValue = Console.ReadLine();
                if (ulong.TryParse(inValue, out output))
                {
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.Write(defautErrMessage);
                }
            }
        }

        static public void Input(out float output, string defaultInMessage = inMessageStart + "(-3.402823e38 .. 3.402823e38): ", string defautErrMessage = ErrMessage)
        {
            string inValue;
            Console.Write(defaultInMessage);
            while (true)
            {
                inValue = Console.ReadLine();
                if (float.TryParse(inValue, out output))
                {
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.Write(defautErrMessage);
                }
            }
        }

        static public void Input(out double output, string defaultInMessage = inMessageStart + "(-1.79769313486232e308 .. 1.79769313486232e308): ", string defautErrMessage = ErrMessage)
        {
            string inValue;
            Console.Write(defaultInMessage);
            while (true)
            {
                inValue = Console.ReadLine();
                if (double.TryParse(inValue, out output))
                {
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.Write(defautErrMessage);
                }
            }
        }

        static public void Input(out decimal output, string defaultInMessage = inMessageStart + "(-79228162514264337593543950335 .. 79228162514264337593543950335): ", string defautErrMessage = ErrMessage)
        {
            string inValue;
            Console.Write(defaultInMessage);
            while (true)
            {
                inValue = Console.ReadLine();
                if (decimal.TryParse(inValue, out output))
                {
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.Write(defautErrMessage);
                }
            }
        }
    }
}
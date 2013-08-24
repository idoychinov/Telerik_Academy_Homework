/* Problem 4. Declare an integer variable and assign it with the value 254 in hexadecimal format. Use Windows Calculator to find its hexadecimal representation.
 * Problem 5. Declare a character variable and assign it with the symbol that has Unicode code 72. Hint: first use the Windows Calculator to find the hexadecimal representation of 72.
 * Problem 6. Declare a boolean variable called isFemale and assign an appropriate value corresponding to your gender.
 * Problem 7.Declare two string variables and assign them with “Hello” and “World”. Declare an object variable and assign it with the concatenation of the first two variables (mind adding an interval). 
 * Declare a third string variable and initialize it with the value of the object variable (you should perform type casting).
 * Problem 8.Declare two string variables and assign them with following value: The "use" of quotations causes difficulties.
 * Do the above in two different ways: with and without using quoted strings.
 */

using System;

class Variables
{
    static void Main()
    {
        int intVariable = 0xFE; 
        char charVariable = '\u0048'; 
        bool isFemale = false;          
        string string1 = "Hello";
        string string2= "World";
        object concatenation = string1 + " " + string2;
        string string3 = (string)concatenation;

        string unquotedString = "The \"use\" of quotations causes difficulties";
        string quotedString = @"The ""use"" of quotations causes difficulties";

        Console.WriteLine("Integer variable: {0};\nCharacter variable: {1};\nBoolean variable: {2};\nString concatenation: {3};\nUnquoted String: {4};\nQuoted String: {5};", intVariable, charVariable, isFemale, string3, unquotedString, quotedString);
    }
}


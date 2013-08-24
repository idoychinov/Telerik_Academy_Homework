/* Problem 12. Find online more information about ASCII (American Standard Code for Information Interchange) and write a program that prints the entire ASCII table of characters on the console.
 */

using System;

class PrintASCIITable
{
    static void Main(string[] args)
    {
        for (int i = 32; i < 127; i++)  // displays all printable characters (The characters that have correct visual representation. The last one with index 127 is not printable so the loop is defined with condition i <127.
        {
            Console.WriteLine("{0} : {1}",i,(char) i);
        }
    }
}

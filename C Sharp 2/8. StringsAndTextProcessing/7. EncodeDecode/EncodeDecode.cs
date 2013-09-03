/* Problem 7.Write a program that encodes and decodes a string using given encryption key (cipher). The key consists of a sequence of characters. The encoding/decoding is done by performing XOR  
 * (exclusive or) operation over the first letter of the string with the first of the key, the second – with the second, etc. When the last key character is reached, the next is the first.
 */

using System;
using System.Text;

class EncodeDecode
{
    static void Main()
    {
        Console.WriteLine("Enter string:");
        string text = Console.ReadLine();
        Console.WriteLine("Enter cipher:");
        string cipher = Console.ReadLine();
        string encoded = EncodeDecodeString(text,cipher);
        Console.WriteLine("The encoded string is: {0}", encoded);
        Console.WriteLine("The decoded string is: {0}", EncodeDecodeString(encoded,cipher));
    }  

    private static string EncodeDecodeString(string text, string cipher)
    {
        int clen = cipher.Length;
        int tlen = text.Length;
        StringBuilder result=new StringBuilder(tlen);
        for (int i = 0; i < tlen; i++)
        {
            result.Append((char)(text[i] ^ cipher[i % clen]));
        }
        return result.ToString();
    }
}


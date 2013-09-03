/* Problem 11. Write a program that deletes from a text file all words that start with the prefix "test". Words contain only the symbols 0...9, a...z, A…Z, _. 
 */
using System;
using System.IO;

class DeleteWords
{
    static void Main()
    {
        StreamReader read = null;
        string text;
        string prefix = "test";
        try
        {
            read = new StreamReader(@"..\..\File.txt");
            Console.WriteLine("Reading from file...");
            text = read.ReadToEnd();
            Console.WriteLine("Reading complete!");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: {0}", e.Message);
            return;
        }
        finally
        {
            if (read != null)
            {
                read.Dispose();
            }
        }

        text = RemoveWords(text, prefix);


        StreamWriter write = null;
        try
        {
            write = new StreamWriter(@"..\..\File.txt");
            Console.WriteLine("Writing to file...");
            write.Write(text);
            Console.WriteLine("Writing complte!");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: {0}", e.Message);
            return;
        }
        finally
        {
            if (write != null)
            {
                write.Dispose();
            }
        }
    }

    private static string RemoveWords(string text, string prefix)
    {
        int index, current = 0; 
        index = text.IndexOf(prefix);
        
        // zaciklq

        while ((index != -1)&&(index<text.Length))
        {
            int wordlen = 0;
            if ((index != 0 && !WordSymbol(text[index - 1])) || index == 0)
            {
                while (true)
                {
                    current = index + prefix.Length + wordlen;
                    if (current >= text.Length)
                    {
                        break;
                    }
                    if (WordSymbol(text[current]))
                    {
                        wordlen++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (wordlen > 0)
                {
                    text = text.Substring(0, index) + text.Substring(current);
                }
                else
                {
                    index = index + prefix.Length;
                }
            }
            else
            {
                index = index + prefix.Length;
            }
            index = text.IndexOf(prefix,index);
        }
        return text;
    }

    private static bool WordSymbol(char c)
    {
        if ((c >= '0' && c <= '9') || (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || c == '_')
        {
            return true;
        }
        return false;
    }
}

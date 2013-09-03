/* Problem 10. Write a program that extracts from given XML file all the text without the tags. 
 */
using System;
using System.IO;



class ExtractXML
{
    static void Main()
    {
        StreamReader read = null;
        string text;
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

        text = ExtractTextFromXml(text);
        Console.WriteLine("The text in the XLM file is:\n{0}", text);
    }

    private static string ExtractTextFromXml(string text)
    {
        while (true)
        {
            int indexStart = 0;
            int indexEnd = 0;
            indexStart = text.IndexOf('<', indexEnd);
            if (indexStart != -1)
            {
                indexEnd = text.IndexOf('>', indexStart);
                if (indexEnd != -1)
                {
                    text = text.Substring(0, indexStart) + text.Substring(indexEnd + 1);
                }
            }
            else
            {
                break;
            }
        }
        return text;
    }


}

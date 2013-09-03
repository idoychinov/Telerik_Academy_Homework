/* Problem 25.Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags. Example:
 * <html>
 * <head><title>News</title></head>
 * <body><p><a href="http://academy.telerik.com">Telerik
 * Academy</a>aims to provide free real-world practical
 * training for young people who want to turn into
 * skillful .NET software engineers.</p></body>
 * </html>
 */
using System;
using System.IO;
using System.Text.RegularExpressions;

class ExtractFromHTML
{
    static void Main()
    {
        string text="";
        try
        {
            using(StreamReader read = new StreamReader(@"..\..\file.html"))
            {
                Console.WriteLine("Reading from file...");
                text=read.ReadToEnd();
                Console.WriteLine("Reading compleate");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("Error: {0}",e.Message);
        }
        MatchCollection match = Regex.Matches(text,@"<title>(.*?)</title>");
        text = Regex.Replace(text, @"<title>(.*?)</title>","");
        foreach(var item in match)
        {
            Console.WriteLine("Title = {0}",RemoveTags(item.ToString()));
        }

        text=RemoveTags(text);
        Console.WriteLine("Body:\n{0}",text);
    }

    private static string RemoveTags(string text)
    {
        //return Regex.Replace(text, @"<.*?>", "").Trim(); 
        return Regex.Replace(Regex.Replace(text, @"<.*?>", ""),"\n"," ").Trim();
    }

}


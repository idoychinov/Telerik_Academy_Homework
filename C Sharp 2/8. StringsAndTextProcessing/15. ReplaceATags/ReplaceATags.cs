/* Problem 15. Write a program that replaces in a HTML document given as string all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL]. Sample HTML fragment:
 * <p>Please visit <a href="http://academy.telerik. com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>
 * to
 * <p>Please visit [URL=http://academy.telerik. com]our site[/URL] to choose a training course. Also visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p>
 */

using System;
using System.Text.RegularExpressions;

class ReplaceATags
{
    static void Main()
    {
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();
        Console.WriteLine("The processed text is:\n{0}",ReplaceTags(text));
    }

    private static string ReplaceTags(string text)
    {
        string searchPattern = "<a\\s*?href\\s*?=\\s*?\"(.*?)\"\\s*?>\\s*?(.*?)\\s*?</a>";  // the \\s*? - pattern allows for withespaces
        string replacePattern = "[URL=$1]$2[/URL]";
        text=Regex.Replace(text, searchPattern, replacePattern); 
        return text;
    }
}


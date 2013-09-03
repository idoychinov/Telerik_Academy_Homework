/* Problem 12. Write a program that parses an URL address given in the format:[protocol]://[server]/[resource]
 * and extracts from it the [protocol], [server] and [resource] elements. For example from the URL http://www.devbg.org/forum/index.php the following information should be extracted:
 * [protocol] = "http"
 * [server] = "www.devbg.org"
 * [resource] = "/forum/index.php" 
 */

using System;

class ParseURL
{
    static void Main()
    {
        Console.WriteLine("Enter URL:");
        string url=Console.ReadLine();
        int protocolIndex = url.IndexOf("://");
        int serverIndex = url.IndexOf("/", protocolIndex + 3);
        Console.WriteLine("[protocol] = \"{0}\"\n[server] = \"{1}\"\n[resource] = \"{2}\"", url.Substring(0, protocolIndex), url.Substring(protocolIndex+3,serverIndex-protocolIndex-3),url.Substring(serverIndex));
    }

}


// 11. Describe the difference between C# and .NET Framework.

using System;
using System.IO;

class Differences
{
    static void Main()
    {
        string fileContent = "";
        try
        {
            StreamReader r = new StreamReader(@"..\..\DifferenceBetweenC#And.NET.txt");
            using (r)
            {
                fileContent = r.ReadToEnd();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: {0}", e.Message);
        }
        Console.WriteLine(fileContent);
    }
}

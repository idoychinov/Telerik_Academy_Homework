// 10. Provide a short list with information about the most popular programming languages. How do they differ from C#?

using System;
using System.IO;

class ProgrammingLanguagesList
{
    static void Main()
    {
        string fileContent="";
        try
        {
            StreamReader r = new StreamReader(@"..\..\PopularProgrammingLanguages.txt");
            using (r)
            {
                fileContent = r.ReadToEnd();
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("Error: {0}",e.Message);
        }
        Console.WriteLine(fileContent);
    }
}

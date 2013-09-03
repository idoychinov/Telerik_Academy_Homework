/* Problem 7. Write a program that replaces all occurrences of the substring "start" with the substring "finish" in a text file. Ensure it will work with large files (e.g. 100 MB).
 * Problem 8. Modify the solution of the previous problem to replace only whole words (not substrings).
 */
using System;
using System.Collections.Generic;
using System.IO;



class StringReplace
{
    static void Main()
    {
        string path1 = @"..\..\file.txt";
        string path2 = @"..\..\file1.txt";
        string path3 = @"..\..\file2.txt";
        string find = "start";
        string replacement = "finish";
        using (FileStream fs1 = File.Open(path1, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        using (FileStream fs2 = File.Open(path2, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
        using (FileStream fs3 = File.Open(path3, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
        using (BufferedStream bs1 = new BufferedStream(fs1))  // using buffered stream improves read spead a lot and can be very helpfull for large files
        using (StreamReader sr = new StreamReader(bs1))   // source:  http://stackoverflow.com/questions/2161895/reading-large-text-files-with-streams-in-c-sharp
        using (BufferedStream bs2 = new BufferedStream(fs2))
        using (StreamWriter swFile2 = new StreamWriter(bs2))
        using (BufferedStream bs3 = new BufferedStream(fs3))
        using (StreamWriter swFile3 = new StreamWriter(bs3))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                swFile2.WriteLine(line.Replace(find, replacement)); // replace substring.
                swFile3.WriteLine(ReplaceWord(line, find, replacement)); // replace only whole words.
            }
            Console.WriteLine("Done!");
        }
    }

    private static string ReplaceWord(string line, string find, string replacement)
    {
        int currentIndex = 0;
        currentIndex = line.IndexOf(find, currentIndex);
        if (currentIndex != -1)
        {
            if (CheckWord(line, currentIndex, find.Length))
            {
                line = line.Substring(0, currentIndex) + replacement + line.Substring(currentIndex + find.Length);
            }
        }
        return line;
    }

    private static bool CheckWord(string line, int currentIndex, int len)
    {
        if (currentIndex == 0)
        {
            if (line[len] == ' ' || line[len] == '.' || line[len] == '!' || line[len] == '?')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if (line[currentIndex - 1] == ' ')
            {
                if (line[currentIndex + len] == ' ' || line[currentIndex + len] == '.' || line[currentIndex + len] == '!' || line[currentIndex+len] == '?')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        return false;
    }


}

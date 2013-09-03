/* Problem 3. Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the console. 
 * Find in MSDN how to use System.IO.File.ReadAllText(…). Be sure to catch all possible exceptions and print user-friendly error messages.
 */
using System;
using System.IO;

class ReadFile
{
    static void Main()
    {
        Console.Write("Enter file path and name:");
        string path = Console.ReadLine();
        try
        {
            Console.WriteLine("File contents:\n", ReadFileContents(path));
        }
        catch(Exception e)
        {
            Console.WriteLine("Error: {0}", e.Message);
        }
    }

    static string ReadFileContents(string path)
    {
        string contents = "";
        try
        {
            contents = System.IO.File.ReadAllText(path);
        }
        catch (ArgumentNullException e)
        {
            throw new System.ArgumentNullException("File path is null!");
        }
        catch (ArgumentException e)
        {
            throw new System.ArgumentException("File path is zero, contains only whitespace, or one or more invalid characters!");
        }
        catch (PathTooLongException e)
        {
            throw new System.IO.PathTooLongException("File path, name or both are too long!");
        }
        catch (DirectoryNotFoundException e)
        {
            throw new System.IO.DirectoryNotFoundException("The specified path is invalid!");
        }
        catch (FileNotFoundException e)
        {
            throw new System.IO.FileNotFoundException("File specifiet in the path is invalid!");
            
        }
        catch (IOException e)
        {
            throw new System.IO.IOException("An I/O error occured while opening the file!");
        }
        catch (UnauthorizedAccessException e)
        {
            throw new System.UnauthorizedAccessException("Path or file is read-only, or you don't have permition!");
        }
        catch (NotSupportedException e)
        {
            throw new System.NotSupportedException("Invalid format for the path!");
        }
        catch (Exception e)
        {
            throw new System.Exception("System Error! The operation cannot be compleated.");

        }

        return contents;
    }
}


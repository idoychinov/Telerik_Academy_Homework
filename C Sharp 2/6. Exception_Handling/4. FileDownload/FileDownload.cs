/* Problem 4. Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg) and stores it the current directory. Find in Google how to download files in C#. 
 * Be sure to catch all exceptions and to free any used resources in the finally block.
 */
using System;
using System.IO;
using System.Net;

class FileDownload
{
    static void Main()
    {
        Console.Write("Enter file URL:");
        string uri = Console.ReadLine();
        Console.Write("Enter file name:");
        string fileName = Console.ReadLine();
        try
        {
            DownloadFile(uri, fileName);
            Console.WriteLine("Download Compleate!");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: {0}", e.Message);
        }

        

    }

    static void DownloadFile(string uri, string file)
    {
        WebClient client = new WebClient();
        try
        {
            Console.WriteLine("Downloading...");
            client.DownloadFile(uri, file);
        }
        catch (ArgumentNullException e)
        {
            throw new System.ArgumentNullException("The adress parameter is null!");
        }
        catch (WebException e)
        {
            throw new System.ArgumentException("The URI is invalid, filename is null, file does not exists or error occured while downloading data!");
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
            throw new System.NotSupportedException("Method called on multiple threads simultaneously!");
        }
        catch (Exception e)
        {
            throw new System.Exception("System Error! The operation cannot be compleated.");

        }
        finally
        {
            client.Dispose();
        }
    }
}


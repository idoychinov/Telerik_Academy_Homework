namespace Task02WindowsFolderTraversal
{
    using System;
    using System.IO;

    /// <summary>
    /// Write a program to traverse the directory C:\WINDOWS and all its subdirectories recursively and to display 
    /// all files matching the mask *.exe. Use the class System.IO.Directory.
    /// </summary>
    class Task02WindowsFolderTraversal
    {
        static void Main()
        {
            const string rootDirectory = @"C:\Windows";
            const string filesToSearch = @"*.exe";
            TraverseDirectories(rootDirectory, filesToSearch);
        }

        private static void TraverseDirectories(string rootDirectory, string filesToSearch)
        {
            try
            {
                var directories = Directory.EnumerateDirectories(rootDirectory);

                foreach (var currentDirectory in directories)
                {
                    TraverseDirectories(currentDirectory, filesToSearch);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            var files = Directory.EnumerateFiles(rootDirectory, filesToSearch);
            foreach (string currentFile in files)
            {
                Console.WriteLine(currentFile);
            }
        }
    }
}

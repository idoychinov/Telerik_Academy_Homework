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
            const string rootFolder = @"C:\Windows";
            const string filesToSearch = @"*.exe";
            TraverseFolders(rootFolder, filesToSearch);
        }

        private static void TraverseFolders(string rootFolder, string filesToSearch)
        {
            try
            {
                var folders = Directory.EnumerateDirectories(rootFolder);

                foreach (var currentDirectory in folders)
                {
                    TraverseFolders(currentDirectory, filesToSearch);
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }

            var files = Directory.EnumerateFiles(rootFolder, filesToSearch);
            foreach (string currentFile in files)
            {
                Console.WriteLine(currentFile);
            }
        }
    }
}

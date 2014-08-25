namespace Task03FileStructure
{
    using System;
    using System.IO;

    /// <summary>
    /// Define classes File { string name, int size } and Folder { string name, File[] files, Folder[] childFolders }
    /// and using them build a tree keeping all files and folders on the hard drive starting from C:\WINDOWS.
    /// Implement a method that calculates the sum of the file sizes in given subtree of the tree and test it accordingly. 
    /// Use recursive DFS traversal.
    /// </summary>
    class Task03FileStructure
    {
        static void Main()
        {
            const string rootDirectory = @"C:\Windows";
            TraverseDirectories(rootDirectory);
            //Directory.GetDirectories();
        }

        private static void TraverseDirectories(string rootDirectory)
        {
            try
            {
                var directories = Directory.EnumerateDirectories(rootDirectory);

                foreach (var currentDirectory in directories)
                {
                    TraverseDirectories(currentDirectory);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            var files = Directory.EnumerateFiles(rootDirectory);
            foreach (string currentFile in files)
            {
                Console.WriteLine(currentFile);
            }
        }
    }
}

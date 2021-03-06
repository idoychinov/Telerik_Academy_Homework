﻿namespace Task03FileStructure
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
            const string rootFolder = @"C:\Windows";
            Console.WriteLine("Building Folder tree...");
            var root = BuildDirectoryTree(rootFolder);
            Console.WriteLine("Folder Tree Build");
            var active = true;
            while (active)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(@"Enter sub folder path in C:\Windows (example \Fonts or Enter for root folder C:\Windows) or type exit to quit: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    var subFolderPath = Console.ReadLine();
                    if(subFolderPath == "exit")
                    {
                        break;
                    }
                    var folderPath =  @"C:\Windows" + subFolderPath;
                    var subfolderTree = GetSubTree(root, folderPath);
                    var fileSizeInBites = GetFileSizeInFolderTree(subfolderTree);
                    Console.WriteLine("{0} folder size in bytes is {1} or {2:0.00} GigaBytes", folderPath, fileSizeInBites, (decimal)fileSizeInBites / (1024 * 1024 * 1024));
                    Console.WriteLine(@"This does not include access denied folders! If you want full file size try starting the .exe from bin\debug with administrator rights");
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static Folder GetSubTree(Folder root, string folderName)
        {
            if (root.Name.ToLower() == folderName.ToLower())
            {
                return root;
            }
            var folderNameLenght = folderName.Length;
            foreach (var child in root.ChildFolders)
            {
                if (child.Name.Length <= folderNameLenght)
                {
                    var folderNameStart = folderName.Substring(0, child.Name.Length);
                    if (child.Name.ToLower() == folderNameStart.ToLower())
                    {
                        return GetSubTree(child, folderName);
                    }
                }
            }
            throw new DirectoryNotFoundException("Specified folder not found");
        }

        private static long GetFileSizeInFolderTree(Folder currentFolder)
        {
            var currentFileSize = 0L;
            foreach (var file in currentFolder.Files)
            {
                currentFileSize += file.Size;
            }

            foreach (var childFolder in currentFolder.ChildFolders)
            {
                currentFileSize += GetFileSizeInFolderTree(childFolder);
            }
            return currentFileSize;
        }

        private static Folder BuildDirectoryTree(string rootFolders)
        {
            try
            {
                var childFolders = Directory.GetDirectories(rootFolders);
                var filesInFolder = Directory.GetFiles(rootFolders);
                var currentFolder = new Folder(rootFolders, filesInFolder.Length, childFolders.Length);


                for (var i = 0; i < childFolders.Length; i++)
                {
                    currentFolder.ChildFolders[i] = BuildDirectoryTree(childFolders[i]);
                }


                for (var i = 0; i < filesInFolder.Length; i++)
                {
                    var filename = filesInFolder[i].Substring(rootFolders.Length + 1);
                    var fileInfo = new FileInfo(filesInFolder[i]);
                    currentFolder.Files[i] = new File(filename, fileInfo.Length);
                }
                return currentFolder;
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
                return new Folder(e.Message);
            }
        }
    }
}

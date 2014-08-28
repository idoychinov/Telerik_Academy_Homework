namespace Task03FileStructure
{
    using System;

    class Folder
    {
        public string Name { get; set; }

        /// <summary>
        /// It's better to implement it with list but since the task instruction says array I've done it with array.
        /// </summary>
        public File[] Files { get; set; }

        /// <summary>
        /// It's better to implement it with list but since the task instruction says array I've done it with array.
        /// </summary>
        public Folder[] ChildFolders { get; set; }

        public Folder(string name, int filesCount, int childFoldersCount)
        {
            this.Name = name;
            this.Files = new File[filesCount];
            this.ChildFolders = new Folder[childFoldersCount];
        }

        public Folder(string name)
            : this(name,0,0)
        {
        }
    }
}

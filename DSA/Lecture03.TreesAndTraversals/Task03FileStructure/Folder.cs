namespace Task03FileStructure
{
    using System;

    class Folder
    {
        public string Name { get; set; }

        public File[] Files { get; set; }

        public Folder[] ChildFolders { get; set; }

        public Folder(string name, File[] files, Folder[] childFolders)
        {
            this.Name = name;
            this.Files = files;
            this.ChildFolders = childFolders;
        }
    }
}

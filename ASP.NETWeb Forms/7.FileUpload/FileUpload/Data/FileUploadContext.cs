namespace FileUpload.Data
{

    using System;
    using System.Data.Entity;

    public class FileUploadContext : DbContext
    {
        public FileUploadContext()
            : base("UploadFilesDb")
        {

        }

        public DbSet<File> Files { get; set; }
    }
}
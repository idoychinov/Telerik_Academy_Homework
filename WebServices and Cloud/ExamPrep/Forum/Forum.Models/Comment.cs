namespace Forum.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }

        public string AuthorId { get; set; }

        public ForumUser Author { get; set; }
    }
}

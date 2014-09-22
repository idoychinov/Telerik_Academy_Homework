namespace Forum.Data
{
    using System;
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Forum.Models;
    using Forum.Data.Migrations;

    public class ForumDbContext : IdentityDbContext<ForumUser>
    {
        public ForumDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ForumDbContext, Configuration>());
        }

        public static ForumDbContext Create()
        {
            return new ForumDbContext();
        }

        public IDbSet<Alert> Alerts { get; set; }

        public IDbSet<Article> Articles { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Like> Likes { get; set; }

        public IDbSet<Tag> Tags { get; set; }

    }
}

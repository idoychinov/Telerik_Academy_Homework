namespace StudentSystem.DataLayer
{
    using System.Data.Entity;

    using System.Data.Entity.Infrastructure;
    using StudentSystem.Model;

    public class StudentsSystemDbContext : DbContext, IStudentSystemDbContext
    {
        // TODO: Ref-factor this
        static string appConnection;
        public StudentsSystemDbContext()
            : base(appConnection)
        {
           Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentsSystemDbContext, StudentSystem.DataLayer.Migrations.Configuration>());
        }
        public StudentsSystemDbContext(string connectionStringName)
            : base(connectionStringName)
        {
            appConnection = connectionStringName;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentsSystemDbContext, StudentSystem.DataLayer.Migrations.Configuration>());
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> Homeworks { get; set; }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public int SaveChanges()
        {
            return this.SaveChanges();
        }
    }
}

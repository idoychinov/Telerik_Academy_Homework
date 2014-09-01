namespace StudentSystem.DataLayer
{
    using System;
    using System.Data.Entity;

    using System.Data.Entity.Infrastructure;
    using StudentSystem.Model;

    public interface IStudentSystemDbContext
    {
        
        DbSet<Student> Students { get; set; }

        DbSet<Course> Courses { get; set; }

        DbSet<Homework> Homeworks { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();

    }
}

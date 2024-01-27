using Lumina.Data.Configurations;
using Lumina.Data.Helpers;
using Lumina.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lumina.Data.DbContexts;
public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options):base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<UserCourse> UserCourses { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<UserCode> UserCodes { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<StudyCenter> StudyCenters { get; set; }
    public DbSet<Subject> Subjects { get; set; }    
    public DbSet<Teacher> Teachers { get; set; }
   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        QueryFilterHelper.AddQueryFilters(modelBuilder);
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasQueryFilter(user => user.IsVerified);

        modelBuilder.ApplyConfiguration(new StudyCenterConfiguration());
    }
}

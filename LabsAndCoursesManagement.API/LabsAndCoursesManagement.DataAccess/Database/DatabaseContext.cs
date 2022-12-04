using LabsAndCoursesManagement.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace LabsAndCoursesManagement.DataAccess.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Lab> Labs => Set<Lab>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Teacher> Teachers => Set<Teacher>();
        public DbSet<User> Users => Set<User>();

        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
            this.Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lab>()
                .HasMany(l => l.Students)
                .WithMany(student => student.Labs);

            modelBuilder.Entity<Lab>()
                .HasOne(lab => lab.Teacher)
                .WithMany(teacher => teacher.Labs)
                .HasForeignKey(lab => lab.TeacherId);
            
            modelBuilder.Entity<User>()
                .HasOne(u => u.Student)
                .WithOne()
                .HasForeignKey<User>(u => u.StudentID);
        }
        
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
        //                  .EnableSensitiveDataLogging();
        //}
    }
}

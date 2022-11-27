using LabsAndCoursesManagement.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LabsAndCoursesManagement.DataAccess.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Lab> Labs => Set<Lab>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Teacher> Teachers => Set<Teacher>();

        public DatabaseContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lab>()
                .HasOne(lab => lab.Teacher)
                .WithMany(teacher => teacher.Labs)
                .HasForeignKey(lab => lab.TeacherId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=LabsAndCoursesManagement")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .EnableSensitiveDataLogging();
        }
    }
}

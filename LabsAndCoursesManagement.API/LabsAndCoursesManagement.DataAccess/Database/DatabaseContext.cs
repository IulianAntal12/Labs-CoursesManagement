using LabsAndCoursesManagement.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LabsAndCoursesManagement.DataAccess.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Lab> Labs;
        public DbSet<Student> Students;
        public DbSet<Teacher> Teachers;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lab>().HasMany(p => p.Students).WithMany();
            modelBuilder.Entity<Teacher>().HasMany(t => t.Labs).WithOne();
            modelBuilder.Entity<Lab>().HasOne(t => t.Teacher).WithMany().HasForeignKey(p => p.TeacherId).OnDelete(DeleteBehavior.NoAction);
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

﻿using LabsAndCoursesManagement.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LabsAndCoursesManagement.DataAccess.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Lab> Labs;
        public DbSet<Student> Students;
        public DbSet<Teacher> Teachers;
        public DbSet<User> Users => Set<User>();
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lab>().HasMany(p => p.Students).WithMany();
            modelBuilder.Entity<Teacher>().HasMany(t => t.Labs).WithMany();
            modelBuilder.Entity<User>().HasOne(u => u.Student).WithOne().HasForeignKey<User>(u => u.StudentID);
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

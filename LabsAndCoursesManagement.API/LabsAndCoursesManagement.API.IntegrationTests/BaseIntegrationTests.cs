using LabsAndCoursesManagement.DataAccess.Database;
using LabsAndCoursesManagement.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;

namespace LabsAndCoursesManagement.API.IntegrationTests
{
    public class BaseIntegrationTests
    {
        private DbContextOptions<DatabaseContext> options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlite("Data Source = MyTests.db").Options;

        protected HttpClient HttpClient { get; private set; }

        private DatabaseContext databaseContext;

        protected BaseIntegrationTests()
        {
            var application = new WebApplicationFactory<TeachersController>()
                .WithWebHostBuilder(builder => { });
            HttpClient = application.CreateClient();
            databaseContext = new DatabaseContext(options);
            // CleanDatabases();
        }

        protected void CleanDatabases()
        {
            databaseContext.Teachers.RemoveRange(databaseContext.Teachers.ToList());
            databaseContext.Labs.RemoveRange(databaseContext.Labs.ToList());
            databaseContext.Students.RemoveRange(databaseContext.Students.ToList());
            databaseContext.SaveChanges();
            databaseContext.Database.EnsureDeleted();
        }
    }
}

using LabsAndCoursesManagement.DataAccess.Database;
using LabsAndCoursesManagement.DataAccess.Repositories;
using LabsAndCoursesManagement.DataAccess.Repositories.GenericRepositories;
using LabsAndCoursesManagement.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LabsAndCoursesManagement.DataAccess
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastrutureServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRepository<Course>, CourseRepository>();
            services.AddScoped<IRepository<Lab>, LabRepository>();
            services.AddScoped<IRepository<Student>, StudentRepository>();
            services.AddScoped<IRepository<Teacher>, TeacherRepository>();
            services.AddScoped<IRepository<Report>, ReportRepository>();
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRepository<Homework>, HomeworkRepository>();

            services.
                AddDbContext<DatabaseContext>
                (m => m.UseSqlServer(
                    configuration.GetConnectionString("LabsAndCoursesDb")),
                    ServiceLifetime.Singleton);
            return services;
        }
    }
}

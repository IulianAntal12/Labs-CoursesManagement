using FluentValidation;
using FluentValidation.AspNetCore;
using LabsAndCoursesManagement.BusinessLogic.Interfaces;
using LabsAndCoursesManagement.BusinessLogic.Multitenancy.Middleware;
using LabsAndCoursesManagement.BusinessLogic.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LabsAndCoursesManagement.BusinessLogic
{
    public static class ConfigureService
    {
        public static IServiceCollection AddApplicationServices
            (this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ILabService, LabService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMiddleware, TenantMiddleware>();
            services.AddTransient<TenantMiddleware>();
            return services;
        }

        public static IApplicationBuilder UseMultitenancy(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TenantMiddleware>();
        }
    }
}

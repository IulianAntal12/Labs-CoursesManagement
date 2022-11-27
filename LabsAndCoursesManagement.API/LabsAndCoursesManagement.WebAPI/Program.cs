using LabsAndCoursesManagement.BusinessLogic.Interfaces;
using LabsAndCoursesManagement.BusinessLogic.Services;
using LabsAndCoursesManagement.DataAccess.Database;
using LabsAndCoursesManagement.DataAccess.Repositories;
using LabsAndCoursesManagement.DataAccess.Repositories.GenericRepositories;
using LabsAndCoursesManagement.Models.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DatabaseContext>();
builder.Services.AddScoped<IRepository<Teacher>, TeacherRepository>();
builder.Services.AddScoped<IRepository<Lab>, LabRepository>();
builder.Services.AddScoped<IRepository<Student>, StudentRepository>();


builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ILabService, LabService>();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddDbContext<DatabaseContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("LabsAndCoursesDb"),
    b => b.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName))
    .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
        .EnableSensitiveDataLogging()
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

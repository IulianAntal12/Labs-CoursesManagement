using LabsAndCoursesManagement.BusinessLogic.Interfaces;
using LabsAndCoursesManagement.BusinessLogic.Services;
using LabsAndCoursesManagement.DataAccess.Database;
using LabsAndCoursesManagement.DataAccess.Repositories;
using LabsAndCoursesManagement.DataAccess.Repositories.GenericRepositories;
using LabsAndCoursesManagement.Models.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DatabaseContext>();
builder.Services.AddScoped<IRepository<Teacher>, TeacherRepository>();    
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IRepository<Lab>, LabRepository>();
builder.Services.AddScoped<ILabService, LabService>();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
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

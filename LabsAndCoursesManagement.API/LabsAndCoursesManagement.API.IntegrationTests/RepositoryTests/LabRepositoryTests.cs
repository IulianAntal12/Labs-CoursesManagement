using AutoMapper;
using LabsAndCoursesManagement.API.IntegrationTests.Setup;
using LabsAndCoursesManagement.BusinessLogic.Mappers;
using LabsAndCoursesManagement.DataAccess.Database;
using LabsAndCoursesManagement.DataAccess.Repositories.GenericRepositories;
using LabsAndCoursesManagement.Models.Dtos;
using LabsAndCoursesManagement.Models.Models;
using Microsoft.Extensions.DependencyInjection;

namespace LabsAndCoursesManagement.API.IntegrationTests.RepositoryTests
{
    public class LabRepositoryTests : BaseIntegrationTests
    {
        private readonly LabRepository labRepo;
        private Teacher teacher;
        private CreateTeacherDto teacherDto;
        private Lab lab;
        private CreateLabDto labDto;
        private IMapper mapper;
        public LabRepositoryTests(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
            using var scope = factory.Services.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<DatabaseContext>();
            labRepo = new LabRepository(db);

            mapper = new AutoMapperBuilder().Build();

            teacherDto = new CreateTeacherDto
            {
                FullName = "Test test",
                Email = "Test@test.com",
                Role = "Test",
                Cabinet = "c100",
                PhoneNumber = "0766727859",
            };
            teacher = mapper.Map<Teacher>(teacherDto);

            labDto = new CreateLabDto
            {
                Description = "Test",
                Name = "Test",
                Year = 3,
                Semester = 1,
                Group = "B4"
            };
            lab = mapper.Map<Lab>(labDto);
        }
    }
}

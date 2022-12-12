using FluentAssertions;
using LabsAndCoursesManagement.API.IntegrationTests.Setup;
using LabsAndCoursesManagement.DataAccess.Database;
using LabsAndCoursesManagement.Models.Dtos;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;

namespace LabsAndCoursesManagement.API.IntegrationTests
{
    public class StudentsControllerTests : BaseIntegrationTests
    {
        private const string ApiURL = "/api/Students";
        private readonly List<Guid> studentIds;

        public StudentsControllerTests(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
            using (var scope = factory.Services.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<DatabaseContext>();
                studentIds = Utilities.SeedStudents(db);
            }
        }

        [Fact]
        public async void When_CreatedStudent_Then_ShouldReturnStudentInTheGetRequest()
        {
            // Arrange
            CreateStudentDto studentDto = CreateSUT();
            // Act
            var createTeacherResponse = await HttpClient.PostAsJsonAsync(ApiURL, studentDto);
            var getStudentResult = await HttpClient.GetAsync(ApiURL);
            // Assert
            createTeacherResponse.EnsureSuccessStatusCode();
            createTeacherResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            getStudentResult.EnsureSuccessStatusCode();
        }

        [Fact]
        public async void When_DeletedStudent_Then_ShouldReturnOk()
        {
            // Arrange
            // Act
            string ApiDeleteURL = $"{ApiURL}/{studentIds[0]}";
            var deleteTeacherResult = await HttpClient.DeleteAsync(ApiDeleteURL);
            // Assert
            deleteTeacherResult.EnsureSuccessStatusCode();
            deleteTeacherResult.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async void When_UpdatedStudent_Then_ShouldReturnNoContent()
        {
            // Arrange
            CreateStudentDto studentDto = CreateSUT();
            // Act
            string ApiUpdateURL = $"{ApiURL}/{studentIds[1]}";
            studentDto.Email = "george.smoc@gmail.com";
            var updateStudentResult = await HttpClient.PutAsJsonAsync(ApiUpdateURL, studentDto);
            // Assert
            updateStudentResult.EnsureSuccessStatusCode();
            updateStudentResult.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        }


        private static CreateStudentDto CreateSUT()
        {
            return new CreateStudentDto
            {
                FullName = "George Smoc",
                Email = "george.smoc13@gmail.com",
                Year = 2,
                Group = "B4",
                IdentificationNumber = "123456789RSL123456",
            };
        }
    }
}

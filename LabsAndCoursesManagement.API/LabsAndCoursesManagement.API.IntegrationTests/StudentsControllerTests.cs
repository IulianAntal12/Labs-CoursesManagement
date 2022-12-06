using FluentAssertions;
using LabsAndCoursesManagement.API.IntegrationTests.Setup;
using LabsAndCoursesManagement.DataAccess.Database;
using LabsAndCoursesManagement.Models.Dtos;
using LabsAndCoursesManagement.Models.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;

namespace LabsAndCoursesManagement.API.IntegrationTests
{
    public class StudentsControllerTests : BaseIntegrationTests
    {
        private const string ApiURL = "/api/Students";
        private readonly Guid teacherId;
        private readonly List<Guid> studentIds;

        public StudentsControllerTests(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
            using (var scope = factory.Services.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<DatabaseContext>();
                teacherId = Utilities.SeedTeachers(db);
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
            var students = await getStudentResult.Content
                .ReadFromJsonAsync<List<Teacher>>();
            students.Count.Should().Be(1 + studentIds.Count());
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
            studentDto.Email = "new email";
            var updateStudentResult = await HttpClient.PutAsJsonAsync(ApiUpdateURL, studentDto);
            // Assert
            updateStudentResult.EnsureSuccessStatusCode();
            updateStudentResult.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        }


        private CreateStudentDto CreateSUT()
        {
            return new CreateStudentDto
            {
                FullName = "George Smoc",
                Email = "george.smoc13@gmail.com",
                Year = 2,
                Group = "B4",
                IdentificationNumber = "some data that needs validation",
            };
        }
    }
}

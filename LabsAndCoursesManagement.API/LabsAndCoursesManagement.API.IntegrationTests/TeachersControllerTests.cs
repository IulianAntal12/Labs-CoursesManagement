using FluentAssertions;
using LabsAndCoursesManagement.API.IntegrationTests.Setup;
using LabsAndCoursesManagement.DataAccess.Database;
using LabsAndCoursesManagement.Models.Dtos;
using LabsAndCoursesManagement.Models.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;

namespace SM.API.IntegrationTests
{
    public class TeachersControllerTests : BaseIntegrationTests
            
    {
        private const string ApiURL = "/api/Teachers";
        private const string ID = "id";
        private Guid teacherId;

        public TeachersControllerTests(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
            using (var scope = factory.Services.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<DatabaseContext>();
                teacherId = Utilities.SeedTeachers(db);
            }
        }

        [Fact]
        public async void When_CreatedTeacher_Then_ShouldReturnTeacherInTheGetRequest()
        {
            // Arrange
            var teacherDto = CreateSUT();
            // Act
            var createTeacherResponse = await HttpClient.PostAsJsonAsync(ApiURL, teacherDto);
            var getTeacherResult = await HttpClient.GetAsync(ApiURL);
            // Assert
            createTeacherResponse.EnsureSuccessStatusCode();
            createTeacherResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            getTeacherResult.EnsureSuccessStatusCode();
            var teachers = await getTeacherResult.Content
                .ReadFromJsonAsync<List<Teacher>>();
        }

        [Fact]
        public async void When_DeletedTeacher_Then_ShouldReturnOk()
        {
            // Arrange
            var teacherDto = CreateSUT();
            // Act
            var createTeacherResponse = await HttpClient.PostAsJsonAsync(ApiURL, teacherDto);
            var data = await createTeacherResponse.Content.ReadAsStringAsync();
            var container = JToken.Parse(data);
            Guid guid = Guid.Parse(container[ID].ToString());
            string ApiDeleteURL = $"{ApiURL}/{container[ID].ToString()}";
            var deleteTeacherResult = await HttpClient.DeleteAsync(ApiDeleteURL);
            // Assert
            createTeacherResponse.EnsureSuccessStatusCode();
            createTeacherResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            deleteTeacherResult.EnsureSuccessStatusCode();
            deleteTeacherResult.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async void When_UpdatedTeacher_Then_ShouldReturnNoContent()
        {
            // Arrange
            var teacherDto = CreateSUT();
            // Act
            var createTeacherResponse = await HttpClient.PostAsJsonAsync(ApiURL, teacherDto);
            var data = await createTeacherResponse.Content.ReadAsStringAsync();
            var container = JToken.Parse(data);
            Guid guid = Guid.Parse(container[ID].ToString());
            

            string ApiUpdateURL = $"{ApiURL}/{guid.ToString()}";
            teacherDto.Email = "new email";
            var updateTeacherResult = await HttpClient.PutAsJsonAsync(ApiUpdateURL, teacherDto);
            // Assert
            createTeacherResponse.EnsureSuccessStatusCode();
            createTeacherResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            updateTeacherResult.EnsureSuccessStatusCode();
            updateTeacherResult.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        }

        [Fact]
        public async void When_GetAllTeachers_Then_ShouldReturnTeachersInResponse()
        {
            // Arrange
            // Act
            var getAllTeachersResponse = await HttpClient.GetAsync(ApiURL);
            // Assert
            getAllTeachersResponse.EnsureSuccessStatusCode();
            getAllTeachersResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var teachers = await getAllTeachersResponse.Content
                .ReadFromJsonAsync<List<Teacher>>();
            teachers.Should().NotBeEmpty();
        }

        private static CreateTeacherDto CreateSUT()
        {
            return new CreateTeacherDto
            {
                FullName = "Mr.Cinnamon",
                Email = "cinnamon@gmail.com",
                Role = "Lecturer",
                PhoneNumber = "0756789456",
                Cabinet = "C210"
            };
        }
    }
}

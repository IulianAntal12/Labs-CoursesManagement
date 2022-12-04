using FluentAssertions;
using LabsAndCoursesManagement.API.IntegrationTests.Setup;
using LabsAndCoursesManagement.Models.Dtos;
using LabsAndCoursesManagement.Models.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;

namespace SM.API.IntegrationTests
{
    public class TeachersControllerTests : BaseIntegrationTests
            
    {
        private const string ApiURL = "/api/Teachers";
        private const string ID = "id";

        public TeachersControllerTests(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
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
            teachers.Count.Should().Be(1);
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

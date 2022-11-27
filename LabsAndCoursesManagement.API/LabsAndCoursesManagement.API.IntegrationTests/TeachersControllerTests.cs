using FluentAssertions;
using LabsAndCoursesManagement.API.IntegrationTests;
using LabsAndCoursesManagement.Models.Dtos;
using LabsAndCoursesManagement.Models.Models;
using System.Net.Http.Json;

namespace SM.API.IntegrationTests
{
    public class TeachersControllerTests : BaseIntegrationTests, IDisposable
    {
        private const string ApiURL = "/v1/api/teachers";

        [Fact]
        public async void When_CreatedTeacher_Then_ShouldReturnTeacherInTheGetRequest()
        {
            CreateTeacherDto teacherDto = CreateSUT();
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

        private static CreateTeacherDto CreateSUT()
        {
            // Arrange
            return new CreateTeacherDto
            {
                FullName = "Mr.Cinnamon",
                Email = "cinnamon@gmail.com",
                Role = "Lecturer",
                PhoneNumber = "0756789456",
                Cabinet = "C210"
            };
        }

        public void Dispose()
        {
            CleanDatabases();
        }
    }
}

using FluentAssertions;
using LabsAndCoursesManagement.API.IntegrationTests.Setup;
using LabsAndCoursesManagement.DataAccess.Database;
using LabsAndCoursesManagement.Models.Dtos;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;

namespace LabsAndCoursesManagement.API.IntegrationTests
{
    public class LabsControllerTests : BaseIntegrationTests
    {
        private readonly string ApiURL = "/api/labs";

        private readonly Guid teacherId;
        private readonly List<Guid> labIds;

        public LabsControllerTests(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
            using (var scope = factory.Services.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<DatabaseContext>();
                teacherId = Utilities.SeedTeachers(db);
                labIds = Utilities.SeedLabs(db);
            }
        }

        [Fact]
        public async void When_CreatedLab_Then_ShouldReturnLabInTheGetRequest()
        {
            // Arrange
            var labDto = CreateSUT();
            // Act
            var createLabResponse = await HttpClient.PostAsJsonAsync(ApiURL, labDto);
            // Assert
            createLabResponse.EnsureSuccessStatusCode();
            createLabResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
        }

        [Fact]
        public async void When_DeletedLab_Then_ShouldReturnOk()
        {
            //Arrange
            string ApiDeleteURL = $"{ApiURL}/{labIds[0]}";
            // Act
            var deleteLabResponse = await HttpClient.DeleteAsync(ApiDeleteURL);
            // Assert
            deleteLabResponse.EnsureSuccessStatusCode();
            deleteLabResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async void When_UpdatedLab_Then_ShouldReturnNoContent()
        {
            //Arrange
            var labDto = CreateSUT();
            string ApiUpdateURL = $"{ApiURL}/{labIds[1]}";
            // Act
            var updateLabResponse = await HttpClient.PutAsJsonAsync(ApiUpdateURL, labDto);
            // Assert
            updateLabResponse.EnsureSuccessStatusCode();
            updateLabResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        }

        [Fact]
        public async void When_UpdatedLabWithBadTeacherId_Then_ShouldReturnBadRequest()
        {
            //Arrange
            var labDto = CreateSUT();
            labDto.TeacherId = Guid.NewGuid();
            string ApiUpdateURL = $"{ApiURL}/{labIds[1]}";
            // Act
            var updateLabResponse = await HttpClient.PutAsJsonAsync(ApiUpdateURL, labDto);
            // Assert
            updateLabResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }


        private CreateLabDto CreateSUT()
        {
            return new CreateLabDto
            {
                Name = "FAI Lab",
                Group = "B4",
                Description = "Applied maths",
                Semester = 2,
                Year = 2,
                TeacherId = teacherId
            };
        }
    }
}

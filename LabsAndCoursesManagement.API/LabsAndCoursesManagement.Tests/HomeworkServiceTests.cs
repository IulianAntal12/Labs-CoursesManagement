using LabsAndCoursesManagement.BusinessLogic.Handlers;
using LabsAndCoursesManagement.BusinessLogic.Services;
using LabsAndCoursesManagement.DataAccess.Repositories;
using LabsAndCoursesManagement.Models.Models;
using Moq;

namespace LabsAndCoursesManagement.Tests
{
    public class HomeworkServiceTests
    {
        private readonly Mock<IRepository<Homework>> repository = new();
        private CreateHomeworkCommandHelper createHelper;

        [SetUp]
        public void Setup()
        {
            createHelper = new CreateHomeworkCommandHelper(repository.Object);
        }

        //[Test]
        //public async Task When_AddedNewCourse_Then_ShouldHaveIsSuccessTrue()
        //{
        //    // Arrange
        //    var homeworkDto = CreateSUT();
        //    // Act
        //    repository.Setup(x => x.Add(course)).Returns(Task.FromResult(course));
        //    var response = await service.Add(homeworkDto);
        //    // Assert
        //    response.IsFailure.Should().BeTrue();
        //}
    }
}

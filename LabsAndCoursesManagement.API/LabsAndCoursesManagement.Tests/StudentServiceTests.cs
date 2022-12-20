using LabsAndCoursesManagement.BusinessLogic.Services;
using LabsAndCoursesManagement.DataAccess.Repositories;
using LabsAndCoursesManagement.Models.Models;
using Moq;
using LabsAndCoursesManagement.Models.Dtos;
using FluentAssertions;
using AutoMapper;
using LabsAndCoursesManagement.BusinessLogic.Mappers;

namespace LabsAndCoursesManagement.Tests
{
    public class StudentServiceTests
    {
        private readonly Mock<IRepository<Student>> repository = new();
        private readonly Mock<IRepository<Lab>> labRepository = new();
        private StudentService service;

        [SetUp]
        public void Setup()
        {
            service = new StudentService(repository.Object, labRepository.Object);
        }

        [Test]
        public async Task When_AddedNewStudent_Then_ShouldHaveIsSuccessTrueInResponse()
        {
            // Arrange
            var studentDto = CreateSUT();
            // Act
            //repository.Setup(x => x.Add(student)).Returns(Task.FromResult(student));
            var result = await service.Add(studentDto);
            // Assert 
            result.IsFailure.Should().BeTrue();
        }

        //[Test]
        //public async Task When_AddedNewStudentWithEmptyFullName_Then_ShouldReturnUnprocessableEntity()
        //{
        //    // Arrange
        //    var student = CreateSUT();
        //    student.FullName = "";
        //    // Act
        //    var result = await service.Add(student);
        //    // Assert 
        //    result.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        //}

        //[Test]
        //public async Task When_AddedNewStudentWithTooLongFullName_Then_ShouldReturnUnprocessableEntity()
        //{
        //    // Arrange
        //    var student = CreateSUT();
        //    student.FullName = string.Concat(Enumerable.Repeat("Hello", 100));
        //    // Act
        //    var result = await service.Add(student);
        //    // Assert 
        //    result.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        //}


        //[Test]
        //public async Task When_AddedNewStudentWithInvalidFullName_Then_ShouldReturnUnprocessableEntity()
        //{
        //    // Arrange
        //    var student = CreateSUT();
        //    student.FullName = "InvalidFullName";
        //    // Act
        //    var result = await service.Add(student);
        //    // Assert 
        //    result.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        //}

        //[Test]
        //public async Task When_AddedNewStudentWithEmptyEmail_Then_ShouldReturnUnprocessableEntity()
        //{
        //    // Arrange
        //    var student = CreateSUT();
        //    student.Email = "";
        //    // Act
        //    var result = await service.Add(student);
        //    // Assert 
        //    result.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        //}

        //[Test]
        //public async Task When_AddedNewStudentWithInvalidEmail_Then_ShouldReturnUnprocessableEntity()
        //{
        //    // Arrange
        //    var student = CreateSUT();
        //    student.Email = "InvalidEmail";
        //    // Act
        //    var result = await service.Add(student);
        //    // Assert 
        //    result.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        //}
        //[Test]
        //public async Task When_AddedNewStudentWithDefaultValueForYear_Then_ShouldReturnUnprocessableEntity()
        //{
        //    // Arrange
        //    var student = CreateSUT();
        //    student.Year = 0;
        //    // Act
        //    var result = await service.Add(student);
        //    // Assert 
        //    result.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        //}
        //[Test]
        //public async Task When_AddedNewStudentWithTooHighValueForYear_Then_ShouldReturnUnprocessableEntity()
        //{
        //    // Arrange
        //    var student = CreateSUT();
        //    student.Year = 7;
        //    // Act
        //    var result = await service.Add(student);
        //    // Assert 
        //    result.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        //}
        //[Test]
        //public async Task When_AddedNewStudentWithEmptyIdentificationNumber_Then_ShouldReturnUnprocessableEntity()
        //{
        //    // Arrange
        //    var student = CreateSUT();
        //    student.IdentificationNumber = "";
        //    // Act
        //    var result = await service.Add(student);
        //    // Assert 
        //    result.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        //}
        //[Test]
        //public async Task When_AddedNewStudentWithInvalidIdentificationNumber_Then_ShouldReturnUnprocessableEntity()
        //{
        //    // Arrange
        //    var student = CreateSUT();
        //    student.IdentificationNumber = "InvalidIdentificationNumber";
        //    // Act
        //    var result = await service.Add(student);
        //    // Assert 
        //    result.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        //}
        //[Test]
        //public async Task When_AddedNewStudentWithEmptyGroup_Then_ShouldReturnUnprocessableEntity()
        //{
        //    // Arrange
        //    var student = CreateSUT();
        //    student.Group = "";
        //    // Act
        //    var result = await service.Add(student);
        //    // Assert 
        //    result.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        //}
        //[Test]
        //public async Task When_AddedNewStudentWithInvalidGroup_Then_ShouldReturnUnprocessableEntity()
        //{
        //    // Arrange
        //    var student = CreateSUT();
        //    student.Group = "InvalidGroup";
        //    // Act
        //    var result = await service.Add(student);
        //    // Assert 
        //    result.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        //}
        private static CreateStudentDto CreateSUT()
        {
            return new CreateStudentDto
            {
                FullName = "George Smoc",
                Email = "george.smoc13@gmail.com",
                Year = 1,
                IdentificationNumber = "123456789RSL123456",
                Group = "B4"
            };
        }
    }
}

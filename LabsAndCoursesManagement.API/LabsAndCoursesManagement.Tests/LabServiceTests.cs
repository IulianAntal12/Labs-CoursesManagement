﻿using LabsAndCoursesManagement.BusinessLogic.Interfaces;
using LabsAndCoursesManagement.BusinessLogic.Services.Validators;
using LabsAndCoursesManagement.DataAccess.Repositories;
using LabsAndCoursesManagement.Models.Dtos;
using LabsAndCoursesManagement.Models.Models;
using Moq;
using FluentAssertions;

namespace LabsAndCoursesManagement.Tests
{
    public class LabServiceTests
    {
        private readonly Mock<IRepository<Lab>> repository = new();
        private readonly Mock<IRepository<Teacher>> teacherRepository = new();
        private readonly LabValidator validator = new();
        private LabService service;

        [SetUp]
        public void Setup()
        {
            service = new LabService(repository.Object, teacherRepository.Object, validator);
        }

        [Test]
        public async Task When_AddedNewLab_Then_ShouldHaveIsSuccessTrue()
        {
            // Arrange
            var lab = CreateSUT();
            // Act
            var response = await service.Add(lab);
            // Assert
            response.IsSuccess.Should().BeTrue();
        }


        [Test]
        public async Task When_AddedNewLabWithEmptyName_Then_ShouldHaveUnprocessableEntityAsResponse()
        {
            // Arrange
            var lab = CreateSUT();
            lab.Name = "";
            // Act
            var response = await service.Add(lab);
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        }

        [Test]
        public async Task When_AddedNewLabWithTooLongName_Then_ShouldHaveUnprocessableEntityAsResponse()
        {
            // Arrange
            var lab = CreateSUT();
            lab.Name = string.Concat(Enumerable.Repeat("Hello", 100));
            // Act
            var response = await service.Add(lab);
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        }
        [Test]
        public async Task When_AddedNewLabWithEmptyGroup_Then_ShouldHaveUnprocessableEntityAsResponse()
        {
            // Arrange
            var lab = CreateSUT();
            lab.Group = "";
            // Act
            var response = await service.Add(lab);
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        }

        [Test]
        public async Task When_AddedNewLabWithGroupNotMatchingRegex_Then_ShouldHaveUnprocessableEntityAsResponse()
        {
            // Arrange
            var lab = CreateSUT();
            lab.Group = "B4 best group";
            // Act
            var response = await service.Add(lab);
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        }

        [Test]
        public async Task When_AddedNewLabWithEmptyDescription_Then_ShouldHaveUnprocessableEntityAsResponse()
        {
            // Arrange
            var lab = CreateSUT();
            lab.Description = "";
            // Act
            var response = await service.Add(lab);
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        }

        [Test]
        public async Task When_AddedNewLabWithTooLongDescription_Then_ShouldHaveUnprocessableEntityAsResponse()
        {
            // Arrange
            var lab = CreateSUT();
            lab.Description = string.Concat(Enumerable.Repeat("Hello", 100));
            // Act
            var response = await service.Add(lab);
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        }

        [Test]
        public async Task When_AddedNewLabWithDefaultValueForYear_Then_ShouldHaveUnprocessableEntityAsResponse()
        {
            // Arrange
            var lab = CreateSUT();
            lab.Year = 0;
            // Act
            var response = await service.Add(lab);
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        }

        [Test]
        public async Task When_AddedNewLabWithTooHighValueForYear_Then_ShouldHaveUnprocessableEntityAsResponse()
        {
            // Arrange
            var lab = CreateSUT();
            lab.Year = 7;
            // Act
            var response = await service.Add(lab);
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        }

        [Test]
        public async Task When_AddedNewLabWithDefaultValueForSemester_Then_ShouldHaveUnprocessableEntityAsResponse()
        {
            // Arrange
            var lab = CreateSUT();
            lab.Semester = 0;
            // Act
            var response = await service.Add(lab);
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        }
        [Test]
        public async Task When_AddedNewLabWithTooHighValueForSemester_Then_ShouldHaveUnprocessableEntityAsResponse()
        {
            // Arrange
            var lab = CreateSUT();
            lab.Semester = 3;
            // Act
            var response = await service.Add(lab);
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        }

        [Test]
        public async Task When_AddedNewLabWithEmptyTeacherField_Then_ShouldHaveUnprocessableEntityAsResponse()
        {
            // Arrange
            var lab = CreateSUT();
            lab.TeacherId = Guid.Empty;
            // Act
            var response = await service.Add(lab);
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        }
        private static CreateLabDto CreateSUT()
        {
            return new CreateLabDto
            {
                Name = "New Name",
                Group = "B4",
                Description = "Description",
                Semester = 1,
                Year = 1,
                TeacherId = Guid.NewGuid()
            };
        }
    }
}
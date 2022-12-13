using AutoMapper;
using FluentAssertions;
using LabsAndCoursesManagement.BusinessLogic.Mappers;
using LabsAndCoursesManagement.BusinessLogic.Services;
using LabsAndCoursesManagement.BusinessLogic.Services.Validators;
using LabsAndCoursesManagement.DataAccess.Repositories;
using LabsAndCoursesManagement.Models.Dtos;
using LabsAndCoursesManagement.Models.Models;
using Moq;

namespace LabsAndCoursesManagement.Tests
{
    public class TeacherServiceTests
    {
        private readonly Mock<IRepository<Teacher>> teacherRepositoryMoq = new();
        private readonly Mock<IRepository<Lab>> labRepositoryMoq = new();
        private readonly TeacherValidator? validator = new();
        private TeacherService service;
        private IMapper mapper; 

        [SetUp]
        public void Setup()
        {
            service = new TeacherService(teacherRepositoryMoq.Object, labRepositoryMoq.Object, validator);
            mapper = new AutoMapperBuilder().Build();
        }

        [Test]
        public void AddTeacher_NotNullEntity_IsSuccessShouldBeTrue()
        {
            //arrange
            var teacherDto = new CreateTeacherDto()
            {
                FullName = "Test Name",
                Cabinet = "111",
                Email = "a@a.a",
                PhoneNumber = "0711111111",
                Role = "Assistant"
            };
            var teacher = mapper.Map<Teacher>(teacherDto);

            //act
            teacherRepositoryMoq.Setup(x => x.Add(teacher)).Returns(Task.FromResult(teacher));
            var result = service.Add(teacherDto);

            //assert
            Assert.That(result.Result.IsFailure, Is.True);
        }

        [Test]
        public void DeleteTeacher_ExistingEntity_IsSuccessShouldBeTrue()
        {
            //arrange
            var TeacherDto = new CreateTeacherDto()
            {
                FullName = "TestName",
                Cabinet = "111",
                Email = "a@a.a",
                PhoneNumber = "0711111111",
                Role = "Assistant"
            };
            var Teacher = mapper.Map<Teacher>(TeacherDto);

            //act
            Moq.Language.Flow.IReturnsResult<IRepository<Teacher>> returnsResult = teacherRepositoryMoq.Setup(x => x.Get(Teacher.Id)).Returns(Task.FromResult(Teacher));
            var result = service.Delete(Teacher.Id);

            //assert
            Assert.That(result.Result.IsSuccess, Is.True);
        }

        [Test]
        public void DeleteTeacher_NotexistingEntity_IsSuccessShouldBeFalse()
        {
            //arrange
            var TeacherDto = new CreateTeacherDto()
            {
                FullName = "TestName",
                Cabinet = "111",
                Email = "a@a.a",
                PhoneNumber = "0711111111",
                Role = "Assistant"
            };
            var Teacher = mapper.Map<Teacher>(TeacherDto);

            //act
            var result = service.Delete(Teacher.Id);

            //assert
            Assert.That(result.Result.IsSuccess, Is.False);
        }

        [Test]
        public void GetAll_ShouldReturnAListOfTeachers()
        {
            //arrange
            var TeacherDto = new CreateTeacherDto()
            {
                FullName = "TestName",
                Cabinet = "111",
                Email = "a@a.a",
                PhoneNumber = "0711111111",
                Role = "Assistant"
            };
            var Teacher = mapper.Map<Teacher>(TeacherDto);
            IEnumerable<Teacher> Teachers = new List<Teacher>() { Teacher};

            //act
            teacherRepositoryMoq.Setup(x => x.All()).Returns(Task.FromResult(Teachers));
            var result = service.GetAll();

            //assert
            Assert.That(Teachers.AsEnumerable<Teacher?>, Is.EqualTo(result.Result.Entity));
        }

        [Test]
        public void GetBy_ExistingTeacher_IsSuccessShouldBeTrue()
        {
            //arrange
            var TeacherDto = new CreateTeacherDto()
            {
                FullName = "TestName",
                Cabinet = "111",
                Email = "a@a.a",
                PhoneNumber = "0711111111",
                Role = "Assistant"
            };
            var Teacher = mapper.Map<Teacher>(TeacherDto);

            //act
            teacherRepositoryMoq.Setup(x => x.Get(Teacher.Id)).Returns(Task.FromResult(Teacher));
            var result = service.GetById((Guid)Teacher.Id);

            //assert
            Assert.That(result.Result.IsSuccess, Is.True);
        }

        [Test]
        public void GetBy_ExistingTeacher_IsSuccessShouldBeFalse()
        {
            //act
            var result = service.GetById(new Guid());

            //assert
            Assert.That(result.Result.IsSuccess, Is.False);
        }

        [Test]
        public void AddTeacher_NotValidEntity_IsFailureShouldBeTrue()
        {
            //arrange
            var teacherDto = new CreateTeacherDto()
            {
                FullName = "TestName",
                Cabinet = "111",
                Email = "a@a.a",
                PhoneNumber = "0711111111",
                Role = "Assistant"
            };

            //act
            var result = service.Add(teacherDto);


            //assert
            result.Result.IsFailure.Should().BeTrue();
            result.Result.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        }


        [Test]
        public void UpdateTeacher_NotValidEntity_IsFailureShouldBeTrue()
        {
            //arrange
            var teacherDto = new CreateTeacherDto()
            {
                FullName = "TestName",
                Cabinet = "111",
                Email = "a@a.a",
                PhoneNumber = "0711111111",
                Role = "Assistant"
            };

            //act
            var result = service.Update(Guid.NewGuid(), teacherDto);

            //assert
            result.Result.IsFailure.Should().BeTrue();
            result.Result.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        }

        [Test]
        public async Task When_AddedNewTeacher_Then_ShouldHaveIsSuccessTrueInResponse()
        {
            // Arrange
            var teacherDto = CreateSUT();
            var teacher = mapper.Map<Teacher>(teacherDto);

            //act
            teacherRepositoryMoq.Setup(x => x.Get(teacher.Id)).Returns(Task.FromResult(teacher));
            var response = await service.Add(teacherDto);
            // Assert
            response.IsFailure.Should().BeTrue();
        }

        [Test]
        public async Task When_AddedNewTeacherWithEmptyFullName_Then_ShouldReturnUnprocessableEntity()
        {
            // Arrange
            var teacher = CreateSUT();
            teacher.FullName = "";
            // Act
            var response = await service.Add(teacher);
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        }

        [Test]
        public async Task When_AddedNewTeacherWithInvalidFullName_Then_ShouldReturnUnprocessableEntity()
        {
            // Arrange
            var teacher = CreateSUT();
            teacher.FullName = "InvalidFullName";
            // Act
            var response = await service.Add(teacher);
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        }

        [Test]
        public async Task When_AddedNewTeacherWithTooLongFullName_Then_ShouldReturnUnprocessableEntity()
        {
            // Arrange
            var teacher = CreateSUT();
            teacher.FullName = string.Concat(Enumerable.Repeat("Hello", 100));
            // Act
            var response = await service.Add(teacher);
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        } 
        
        [Test]
        public async Task When_AddedNewTeacherWithEmptyEmail_Then_ShouldReturnUnprocessableEntity()
        {
            // Arrange
            var teacher = CreateSUT();
            teacher.Email = "";
            // Act
            var response = await service.Add(teacher);
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        }
        
        [Test]
        public async Task When_AddedNewTeacherWithInvalidEmail_Then_ShouldReturnUnprocessableEntity()
        {
            // Arrange
            var teacher = CreateSUT();
            teacher.Email = "george.george";
            // Act
            var response = await service.Add(teacher);
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        }
        [Test]
        public async Task When_AddedNewTeacherWithEmptyRole_Then_ShouldReturnUnprocessableEntity()
        {
            // Arrange
            var teacher = CreateSUT();
            teacher.Role = "";
            // Act
            var response = await service.Add(teacher);
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        }
        [Test]
        public async Task When_AddedNewTeacherWithTooLongRole_Then_ShouldReturnUnprocessableEntity()
        {
            // Arrange
            var teacher = CreateSUT();
            teacher.Role = string.Concat(Enumerable.Repeat("Hello", 100));
            // Act
            var response = await service.Add(teacher);
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        } 
        
        [Test]
        public async Task When_AddedNewTeacherWithEmptyPhoneNumber_Then_ShouldReturnUnprocessableEntity()
        {
            // Arrange
            var teacher = CreateSUT();
            teacher.PhoneNumber = "";
            // Act
            var response = await service.Add(teacher);
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        }
        [Test]
        public async Task When_AddedNewTeacherWithInvalidPhoneNumber_Then_ShouldReturnUnprocessableEntity()
        {
            // Arrange
            var teacher = CreateSUT();
            teacher.PhoneNumber = "07noidoi";
            // Act
            var response = await service.Add(teacher);
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        }
        
        [Test]
        public async Task When_AddedNewTeacherWithTooLongCabiner_Then_ShouldReturnUnprocessableEntity()
        {
            // Arrange
            var teacher = CreateSUT();
            teacher.Cabinet = "C4111";
            // Act
            var response = await service.Add(teacher);
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        }

        public CreateTeacherDto CreateSUT()
        {
            return new CreateTeacherDto()
            {
                FullName = "Full Name",
                Email = "email@gmail.com",
                Role = "Assistant",
                PhoneNumber = "0770444999",
                Cabinet = "C410"
            };
        }
    }
}
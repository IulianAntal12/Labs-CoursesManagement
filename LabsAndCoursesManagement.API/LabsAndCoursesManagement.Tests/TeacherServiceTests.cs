using AutoMapper;
using FluentAssertions;
using FluentValidation;
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
        private readonly TeacherValidator validator = new();
        private TeacherService teacherService;
       
        private IMapper mapper; 

        [SetUp]
        public void Setup()
        {
            teacherService = new TeacherService(teacherRepositoryMoq.Object, labRepositoryMoq.Object, validator);
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

            //act
            var result = teacherService.Add(teacherDto);


            //assert
            Assert.That(result.Result.IsSuccess, Is.True);
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
            teacherRepositoryMoq.Setup(x => x.Get(Teacher.Id)).Returns(Task.FromResult(Teacher));
            var result = teacherService.Delete((Guid)Teacher.Id);

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
            var result = teacherService.Delete((Guid)Teacher.Id);

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
            var result = teacherService.GetAll();

            //assert
            Assert.That(Teachers.AsEnumerable<Teacher>, Is.EqualTo(result.Result.Entity));
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
            var result = teacherService.GetById((Guid)Teacher.Id);

            //assert
            Assert.That(result.Result.IsSuccess, Is.True);
        }

        [Test]
        public void GetBy_ExistingTeacher_IsSuccessShouldBeFalse()
        {
            //act
            var result = teacherService.GetById(new Guid());

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
            var result = teacherService.Add(teacherDto);


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
            var result = teacherService.Update(Guid.NewGuid(), teacherDto);

            //assert
            result.Result.IsFailure.Should().BeTrue();
            result.Result.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        }
    }
}
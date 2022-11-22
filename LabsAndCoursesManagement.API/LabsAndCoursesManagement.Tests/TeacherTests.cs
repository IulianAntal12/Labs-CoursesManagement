using AutoMapper;
using LabsAndCoursesManagement.BusinessLogic.Mappers;
using LabsAndCoursesManagement.BusinessLogic.Services;
using LabsAndCoursesManagement.DataAccess.Repositories;
using LabsAndCoursesManagement.Models.Dtos;
using LabsAndCoursesManagement.Models.Models;
using Moq;

namespace LabsAndCoursesManagement.Tests
{
    public class TeacherTests
    {
        private readonly Mock<IRepository<Teacher>> teacherRepositoryMoq = new();
        private readonly Mock<IRepository<Lab>> labRepositoryMoq = new();
        private TeacherService teacherService;
        private IMapper mapper; 

        [SetUp]
        public void Setup()
        {
            teacherService = new TeacherService(teacherRepositoryMoq.Object, labRepositoryMoq.Object);
            mapper = new AutoMapperBuilder().Build();
        }

        [Test]
        public void AddTeacher_NotNullEntity_IsSuccessShouldBeTrue()
        {
            //arrange
            var TeacherDto = new CreateTeacherDto()
            {
                Name = "TestName",
                Cabinet = "111",
                Email = "a@a.a",
                PhoneNumber = "0711111111",
                Role = "Assistant"
            };

            //act
            var result = teacherService.Add(TeacherDto);


            //assert
            Assert.That(result.Result.IsSuccess, Is.True);
        }

        [Test]
        public void DeleteTeacher_ExistingEntity_IsSuccessShouldBeTrue()
        {
            //arrange
            var TeacherDto = new CreateTeacherDto()
            {
                Name = "TestName",
                Cabinet = "111",
                Email = "a@a.a",
                PhoneNumber = "0711111111",
                Role = "Assistant"
            };
            var Teacher = mapper.Map<Teacher>(TeacherDto);

            //act
            teacherRepositoryMoq.Setup(x => x.Get(Teacher.Id)).Returns(Task.FromResult(Teacher));
            var result = teacherService.Delete(Teacher.Id);

            //assert
            Assert.That(result.Result.IsSuccess, Is.True);
        }

        [Test]
        public void DeleteTeacher_NotexistingEntity_IsSuccessShouldBeFalse()
        {
            //arrange
            var TeacherDto = new CreateTeacherDto()
            {
                Name = "TestName",
                Cabinet = "111",
                Email = "a@a.a",
                PhoneNumber = "0711111111",
                Role = "Assistant"
            };
            var Teacher = mapper.Map<Teacher>(TeacherDto);

            //act
            var result = teacherService.Delete(Teacher.Id);

            //assert
            Assert.That(result.Result.IsSuccess, Is.False);
        }

        [Test]
        public void GetAll_ShouldReturnAListOfTeachers()
        {
            //arrange
            var TeacherDto = new CreateTeacherDto()
            {
                Name = "TestName",
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
                Name = "TestName",
                Cabinet = "111",
                Email = "a@a.a",
                PhoneNumber = "0711111111",
                Role = "Assistant"
            };
            var Teacher = mapper.Map<Teacher>(TeacherDto);

            //act
            teacherRepositoryMoq.Setup(x => x.Get(Teacher.Id)).Returns(Task.FromResult(Teacher));
            var result = teacherService.GetById(Teacher.Id);

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
    }
}
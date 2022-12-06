using AutoMapper;
using LabsAndCoursesManagement.BusinessLogic.Mappers;
using LabsAndCoursesManagement.Models.Dtos;
using LabsAndCoursesManagement.Models.Helpers;
using LabsAndCoursesManagement.Models.Models;
using System.Net;

namespace LabsAndCoursesManagement.Tests
{
    public class ResultTests
    {
        private IMapper mapper;
        private CreateTeacherDto teacherDto;
        private Teacher teacher;
        private Result<Teacher> result;
        private HttpStatusCode statusCode = HttpStatusCode.BadRequest;

        [SetUp]
        public void Setup()
        {
            mapper = new AutoMapperBuilder().Build();
            teacherDto = new CreateTeacherDto
            {
                FullName = "Test",
                Email = "Test",
                Role = "Test",
                Cabinet = "Test",
                PhoneNumber = "Test",
            };
            teacher = mapper.Map<Teacher>(teacherDto);
            result = new Result<Teacher>();
        }

        [Test]
        public void Success_ResultEntityShouldBeTeacher_AndResultIsSuccessShouldBeTrue()
        {
            result = Result<Teacher>.Success(teacher);

            Assert.Multiple(() =>
            {
                Assert.That(result.IsSuccess, Is.True);
                Assert.That(result.Entity, Is.EqualTo(teacher));
            });
        }

        [Test]
        public void SuccessNoEntity_ResultEntityShouldBeNull_AndResultIsSuccessShouldBeTrue()
        {
            result = Result<Teacher>.SuccessNoEntity();

            Assert.Multiple(() =>
            {
                Assert.That(result.IsSuccess, Is.True);
                Assert.That(result.Entity, Is.Null);
            });
        }

        [Test]
        public void Failure_ErrorShouldBeError_StatusCodeShouldBe404_AndResultIsFailureShouldBeTrue()
        {
            result = Result<Teacher>.Failure(statusCode, "Error");

            Assert.Multiple(() =>
            {
                Assert.That(result.IsFailure, Is.True);
                Assert.That(result.Error, Is.EqualTo("Error"));
                Assert.That(result.StatusCode, Is.EqualTo(statusCode));
            });
        }
    }
}

using AutoMapper;
using LabsAndCoursesManagement.BusinessLogic.Mappers;
using LabsAndCoursesManagement.Models.Dtos;
using LabsAndCoursesManagement.Models.Models;

namespace LabsAndCoursesManagement.Tests
{
    public class LabTests
    {
        private IMapper mapper;
        private CreateStudentDto studentDto;
        private Student student;
        private CreateLabDto labDto;
        private Lab lab;
        private CreateTeacherDto teacherDto;
        private Teacher teacher;

        [SetUp]
        public void Setup()
        {
            mapper = new AutoMapperBuilder().Build();

            studentDto = new CreateStudentDto
            {
                FullName = "Test test",
                Email = "test@test.test",
                Year = 3,
                IdentificationNumber = "123456789RSL123456",
                Group = "B4",
            };
            student = mapper.Map<Student>(studentDto);

            teacherDto = new CreateTeacherDto
            {
                FullName = "Test test",
                Email = "test@test.test",
                Role = "Test",
                Cabinet = "Test",
                PhoneNumber = "076652123",
            };
            teacher = mapper.Map<Teacher>(teacherDto);

            labDto = new CreateLabDto
            {
                Description = "Test",
                Name = "Test",
                Year = 3,
                Semester = 1,
                Group = "B4"
            };
            lab = mapper.Map<Lab>(labDto);
        }

        [Test]
        public void EnrollTeacher_TeacherShouldNotBeNull_AndTeacherIdShouldNotBeNull()
        {
            lab.EnrollTeacher(teacher);

            Assert.Multiple(() =>
            {
                Assert.That(teacher.Id, Is.EqualTo(lab.TeacherId));
                Assert.That(teacher, Is.EqualTo(lab.Teacher));
            });
        }

        [Test]
        public void EnrollStudent_StudentsShouldContainTheStudent()
        {
            lab.EnrollStudent(student);

            Assert.Multiple(() =>
            {
                Assert.That(lab.Students, Has.Count.EqualTo(1));
                Assert.That(lab.Students, Does.Contain(student));
            });
        }
    }
}

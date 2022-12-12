using AutoMapper;
using LabsAndCoursesManagement.BusinessLogic.Mappers;
using LabsAndCoursesManagement.Models.Dtos;
using LabsAndCoursesManagement.Models.Models;

namespace LabsAndCoursesManagement.Tests
{
    public class TeacherTests
    {
        private IMapper mapper;
        private CreateTeacherDto teacherDto;
        private Teacher teacher;
        private CreateLabDto labDto;
        private Lab lab;
        private List<Lab?> labs;

        [SetUp]
        public void Setup()
        {
            mapper = new AutoMapperBuilder().Build();
            teacherDto = new CreateTeacherDto {
                FullName= "Test",
                Email= "Test",
                Role = "Test",
                Cabinet= "Test",
                PhoneNumber= "Test",
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
            labs = new List<Lab?>
            {
                lab
            };
        }

        [Test]
        public void EnrollToLabs_TeacherShouldHaveOneLab_AndLabShouldHaveTeacherId()
        {
            teacher.EnrollToLabs(labs);

            Assert.Multiple(() =>
            {
                Assert.That(teacher.Labs, Has.Count.EqualTo(1));
                Assert.That(teacher.Id, Is.EqualTo(lab.TeacherId));
            });
        }
    }
}

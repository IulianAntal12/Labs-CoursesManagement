using AutoMapper;
using LabsAndCoursesManagement.BusinessLogic.Mappers;
using LabsAndCoursesManagement.Models.Dtos;
using LabsAndCoursesManagement.Models.Models;

namespace LabsAndCoursesManagement.Tests
{
    public class StudentTests
    {
        private IMapper mapper;
        private CreateStudentDto studentDto;
        private Student student;
        private CreateLabDto labDto;
        private Lab lab;
        private List<Lab?> labs;

        [SetUp]
        public void Setup()
        {
            mapper = new AutoMapperBuilder().Build();
            studentDto = new CreateStudentDto
            {
                FullName = "Test",
                Email = "Test",
                Year = 3,
                IdentificationNumber = "Test",
                Group = "B4",
            };
            student = mapper.Map<Student>(studentDto);
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
        public void EnrollToLabs_StudentShouldHaveOneLab_AndLabShouldHaveTheStudent()
        {
            student.EnrollToLabs(labs);

            Assert.Multiple(() =>
            {
                Assert.That(student.Labs, Has.Count.EqualTo(1));
                Assert.That(lab.Students, Does.Contain(student));
            });
        }

        [Test]
        public void EnrollToLabs_WithEmptyList_StudentShouldHaveZeroLabs()
        {
            var emptyList = new List<Lab?>();
            student.EnrollToLabs(emptyList);

            Assert.That(student.Labs, Has.Count.EqualTo(0));
        }
    }
}

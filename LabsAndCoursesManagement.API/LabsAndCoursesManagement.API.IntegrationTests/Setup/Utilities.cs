using LabsAndCoursesManagement.BusinessLogic.Mappers;
using LabsAndCoursesManagement.DataAccess.Database;
using LabsAndCoursesManagement.Models.Dtos;
using LabsAndCoursesManagement.Models.Models;

namespace LabsAndCoursesManagement.API.IntegrationTests.Setup
{
    public class Utilities
    {
        public static Guid SeedTeachers(DatabaseContext context)
        {
            AutoMapperBuilder autoMapperBuilder = new AutoMapperBuilder();
            var mapper = autoMapperBuilder.Build();
            var dto = new CreateTeacherDto
            {
                FullName = "Mr.Cinnamon",
                Email = "cinnamon@gmail.com",
                Role = "Lecturer",
                PhoneNumber = "0756789456",
                Cabinet = "C210"
            };
            var teacher = mapper.Map<CreateTeacherDto, Teacher>(dto);
            context.Teachers.Add(teacher);
            context.SaveChanges();
            return teacher.Id;
        }

        public static List<Guid> SeedLabs(DatabaseContext context)
        {
            var teacherId = SeedTeachers(context);
            AutoMapperBuilder autoMapperBuilder = new AutoMapperBuilder();
            var mapper = autoMapperBuilder.Build();
            var labIds = new List<Guid>();
            for (var studentIndex = 0; studentIndex < 2; studentIndex++)
            {
                var dto = new CreateLabDto
                {
                    Name = "Maths",
                    Group = "B4",
                    Year = 1,
                    Semester = 1,
                    Description = "Just maths",
                    TeacherId = teacherId,
                };
                var lab = mapper.Map<CreateLabDto, Lab>(dto);
                context.Labs.Add(lab);
                context.SaveChanges();
                labIds.Add(lab.Id);
            }
            return labIds;
        }

        public static List<Guid> SeedStudents(DatabaseContext context)
        {
            AutoMapperBuilder autoMapperBuilder = new AutoMapperBuilder();
            var mapper = autoMapperBuilder.Build();
            var studentIds = new List<Guid>();
            for (var studentIndex = 0; studentIndex < 2; studentIndex++) 
            {
                var dto = new CreateStudentDto
                {
                    FullName = "George Smoc",
                    Email = "george.smoc13@gmail.com",
                    Year = 3,
                    IdentificationNumber = "Some string that is not yet validated",
                    Group = "B4"
                };
                var student = mapper.Map<CreateStudentDto, Student>(dto);
                context.Students.Add(student);
                context.SaveChanges();
                studentIds.Add(student.Id);
            }
            return studentIds;
        }
    }
}


using AutoMapper;
using LabsAndCoursesManagement.Models.Dtos;
using LabsAndCoursesManagement.Models.Models;

namespace LabsAndCoursesManagement.BusinessLogic.Mappers
{
    public class StudentMapper: Profile
    {
        public StudentMapper()
        {
            CreateMap<Student, CreateStudentDto>().ReverseMap();
        }
    }
}

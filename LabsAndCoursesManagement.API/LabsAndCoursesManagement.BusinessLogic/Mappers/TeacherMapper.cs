using AutoMapper;
using LabsAndCoursesManagement.Models.Models;
using LabsAndCoursesManagement.Models.Dtos;

namespace LabsAndCoursesManagement.BusinessLogic.Mappers
{
    public class TeacherMapper : Profile
    {
        public TeacherMapper()
        {
            CreateMap<Teacher, CreateTeacherDto>().ReverseMap();
        }
    }
}

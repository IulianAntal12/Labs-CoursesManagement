using AutoMapper;
using LabsAndCoursesManagement.Models.Dtos;
using LabsAndCoursesManagement.Models.Models;

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

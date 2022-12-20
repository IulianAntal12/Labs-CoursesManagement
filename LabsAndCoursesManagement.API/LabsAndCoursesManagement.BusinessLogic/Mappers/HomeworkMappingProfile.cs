using AutoMapper;
using LabsAndCoursesManagement.BusinessLogic.Commands;
using LabsAndCoursesManagement.Models.Dtos;
using LabsAndCoursesManagement.Models.Models;

namespace LabsAndCoursesManagement.BusinessLogic.Mappers
{
    public class HomeworkMappingProfile : Profile
    {
        public HomeworkMappingProfile()
        {
            CreateMap<CreateHomeworkCommand, Homework>().ReverseMap();
        }
    }
}

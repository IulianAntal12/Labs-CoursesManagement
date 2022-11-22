using AutoMapper;
using LabsAndCoursesManagement.Models.Dtos;
using LabsAndCoursesManagement.Models.Models;

namespace LabsAndCoursesManagement.BusinessLogic.Mappers
{
    public class LabMapper : Profile
    {
        public LabMapper()
        {
            CreateMap<Lab, CreateLabDto>().ReverseMap();
        }
    }
}

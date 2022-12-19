using AutoMapper;
using LabsAndCoursesManagement.BusinessLogic.Commands;
using LabsAndCoursesManagement.Models.Models;

namespace LabsAndCoursesManagement.BusinessLogic.Mappers
{
    public class ReportMappingProfile : Profile
    {
        public ReportMappingProfile()
        {
            CreateMap<CreateReportCommand, Report>().ReverseMap();
        }
    }
}

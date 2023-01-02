using AutoMapper;
using LabsAndCoursesManagement.Models.Dtos;
using LabsAndCoursesManagement.Models.Models;

namespace LabsAndCoursesManagement.BusinessLogic.Mappers
{
    public class TenantMapperProfile: Profile
    {
        public TenantMapperProfile()
        {
            CreateMap<Tenant, CreateTenantDto>().ReverseMap();
        }
    }
}

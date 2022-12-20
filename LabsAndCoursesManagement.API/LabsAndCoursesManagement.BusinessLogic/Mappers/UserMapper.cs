using AutoMapper;
using LabsAndCoursesManagement.Models.Models;
using LabsAndCoursesManagement.WebAPI.Dtos;

namespace LabsAndCoursesManagement.BusinessLogic.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<UserRegistrationDTO, User>().ReverseMap();
    }
}
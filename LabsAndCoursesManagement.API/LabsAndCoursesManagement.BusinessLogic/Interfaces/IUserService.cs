using LabsAndCoursesManagement.BusinessLogic.Base;
using LabsAndCoursesManagement.Models.Models;
using LabsAndCoursesManagement.WebAPI.Dtos;
using Microsoft.AspNetCore.Identity;

namespace LabsAndCoursesManagement.BusinessLogic.Interfaces;

public interface IUserService : IBaseService<User, UserRegistrationDto>
{
    Task<Result<User>> RegisterUserAsync(UserRegistrationDto userRegistration);
}
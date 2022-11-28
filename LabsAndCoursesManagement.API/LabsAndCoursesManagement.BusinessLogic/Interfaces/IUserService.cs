using LabsAndCoursesManagement.BusinessLogic.Base;
using LabsAndCoursesManagement.Models.Models;
using LabsAndCoursesManagement.WebAPI.Dtos;
using Microsoft.AspNetCore.Identity;

namespace LabsAndCoursesManagement.BusinessLogic.Interfaces;

public interface IUserService : IBaseService<User, UserRegistrationDTO>
{
    Task<Result<User>> RegisterUserAsync(UserRegistrationDTO userRegistration);
}
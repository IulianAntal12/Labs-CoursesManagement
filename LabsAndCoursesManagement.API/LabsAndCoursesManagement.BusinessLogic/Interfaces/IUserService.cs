using LabsAndCoursesManagement.BusinessLogic.Base;
using LabsAndCoursesManagement.Models.Helpers;
using LabsAndCoursesManagement.Models.Models;
using LabsAndCoursesManagement.WebAPI.Dtos;

namespace LabsAndCoursesManagement.BusinessLogic.Interfaces;

public interface IUserService : IBaseService<User, UserRegistrationDto>
{
    Task<Result<User>> RegisterUserAsync(UserRegistrationDto userRegistration);
}
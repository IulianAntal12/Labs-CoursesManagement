using LabsAndCoursesManagement.BusinessLogic.Base;
using LabsAndCoursesManagement.Models.Helpers;
using LabsAndCoursesManagement.Models.Models;
using LabsAndCoursesManagement.WebAPI.Dtos;

namespace LabsAndCoursesManagement.BusinessLogic.Interfaces;

public interface IUserService : IBaseService<User, UserRegistrationDTO>
{
    Task<Result<User>> RegisterUserAsync(UserRegistrationDTO userRegistration);
}
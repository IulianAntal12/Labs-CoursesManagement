using LabsAndCoursesManagement.Models.Dtos;
using LabsAndCoursesManagement.WebAPI.Dtos;
using Microsoft.AspNetCore.Identity;

namespace LabsAndCoursesManagement.BusinessLogic.Interfaces;

public interface IUserAuthentication
{
    Task<IdentityResult> RegisterUserAsync(UserRegistrationDto userForRegistration);

    Task<bool> ValidateUserAsync(UserLoginDto loginDto);

    Task<string> CreateTokenAsync();
}
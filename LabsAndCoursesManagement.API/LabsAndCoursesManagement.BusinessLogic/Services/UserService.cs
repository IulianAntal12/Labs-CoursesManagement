using LabsAndCoursesManagement.BusinessLogic.Base;
using LabsAndCoursesManagement.BusinessLogic.Interfaces;
using LabsAndCoursesManagement.DataAccess.Repositories;
using LabsAndCoursesManagement.DataAccess.Repositories.GenericRepositories;
using LabsAndCoursesManagement.Models.Helpers;
using LabsAndCoursesManagement.Models.Models;
using LabsAndCoursesManagement.WebAPI.Dtos;
using System.Net;

namespace LabsAndCoursesManagement.BusinessLogic.Services;

public class UserService : BaseService<User, UserRegistrationDTO>, IUserService
{

    private readonly IUserRepository userRepository;

    public UserService(IRepository<User> repository, IUserRepository userRepository)
        : base(repository)
    {
        this.userRepository = userRepository;
    }

    public async Task<Result<User>> RegisterUserAsync(UserRegistrationDTO userRegistrationDto)
    {
        var user = mapper.Map<User>(userRegistrationDto);
        var userFromDb = await userRepository.GetByEmail(userRegistrationDto.Email);

        if (userFromDb != null)
        {
            return Result<User>.Failure(HttpStatusCode.Conflict, "User has laready been registered");
        }

        var createdUser = mapper.Map(userRegistrationDto, user);

        await userRepository.Add(createdUser);
        await userRepository.SaveChanges();

        return Result<User>.Success(createdUser);
    }
}
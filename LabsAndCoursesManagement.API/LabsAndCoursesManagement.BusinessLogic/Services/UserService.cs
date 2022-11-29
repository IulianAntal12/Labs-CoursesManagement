using AutoMapper;
using LabsAndCoursesManagement.BusinessLogic.Base;
using LabsAndCoursesManagement.BusinessLogic.Interfaces;
using LabsAndCoursesManagement.DataAccess.Repositories;
using LabsAndCoursesManagement.DataAccess.Repositories.GenericRepositories;
using LabsAndCoursesManagement.Models.Models;
using LabsAndCoursesManagement.WebAPI.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LabsAndCoursesManagement.BusinessLogic.Services;

public class UserService : BaseService<User, UserRegistrationDto>, IUserService
{

    private readonly IUserRepository userRepository;
    private readonly IMapper mapper;

    public UserService(IRepository<User> repository, IUserRepository userRepository) : base(repository)
    {
        this.userRepository = userRepository;
    }

    public async Task<Result<User>> RegisterUserAsync(UserRegistrationDto userRegistrationDto)
    {
        var user = mapper.Map<User>(userRegistrationDto);
        var userFromDb = await userRepository.GetByEmail(userRegistrationDto.Email);
        
        if (userFromDb != null)
        {
            return Result<User>.Failure("User already registered");
        }

        var createdUser = mapper.Map(userRegistrationDto, user); 
        
        await userRepository.Add(createdUser);
        await userRepository.SaveChanges();

        return Result<User>.Success(createdUser);
    }
}
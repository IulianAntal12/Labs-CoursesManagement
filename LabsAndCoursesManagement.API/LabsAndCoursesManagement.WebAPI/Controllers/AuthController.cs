using LabsAndCoursesManagement.BusinessLogic.Interfaces;
using LabsAndCoursesManagement.WebAPI.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LabsAndCoursesManagement.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserService _userService;


    public AuthController(ILogger<AuthController> logger, IAuthorizationService authorizationService,
        IUserService userService)
    {
        _logger = logger;
        _authorizationService = authorizationService;
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDTO userRegistrationDto)
    {
        var response = await _userService.RegisterUserAsync(userRegistrationDto);
        if (response.IsFailure)
        {
            return StatusCode(409, response.Error);
        }

        return StatusCode(201, response.Entity);
    }
}
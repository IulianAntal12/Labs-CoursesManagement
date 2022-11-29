using LabsAndCoursesManagement.BusinessLogic.Filters;
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

    
    //TODO:
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto userRegistrationDto)
    {
        return Ok();
    }
}
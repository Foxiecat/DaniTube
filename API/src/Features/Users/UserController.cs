using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.Features.Users.DTOs;
using src.Features.Users.Entities;
using src.Features.Users.Interfaces;
using src.Services.Interfaces;

namespace src.Features.Users;

[Route("[controller]")]
[ApiController]
public class UserController(
    IUserService userService,
    ITokenService tokenService, 
    ILogger<UserController> logger) : ControllerBase
{
    
    
}
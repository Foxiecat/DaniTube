using Microsoft.AspNetCore.Mvc;
using src.Services.Interfaces;

namespace src.Features.Users;

[Route("[controller]")]
public class UserController(ITokenService tokenService, ILogger<UserController> logger) : ControllerBase
{
    
}